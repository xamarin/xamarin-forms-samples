using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Todo.Models;
using Todo.Utils;
using Todo.Exceptions;

namespace Todo.Services
{
	public class FaceRecognitionService : IFaceRecognitionService, IDisposable
	{
		HttpClient _client;

		static JsonSerializerSettings s_settings = new JsonSerializerSettings()
		{
			DateFormatHandling = DateFormatHandling.IsoDateFormat,
			NullValueHandling = NullValueHandling.Ignore,
			ContractResolver = new CamelCasePropertyNamesContractResolver()
		};

		public FaceRecognitionService()
		{
			_client = new HttpClient();
			_client.DefaultRequestHeaders.Add("ocp-apim-subscription-key", Constants.FaceApiKey);

		}

		~FaceRecognitionService()
		{
			Dispose(false);
		}

		string GetAttributeString(IEnumerable<FaceAttributeType> types)
		{
			return string.Join(",", types.Select(a =>
			{
				string attrStr = a.ToString();
				return char.ToLowerInvariant(attrStr[0]) + attrStr.Substring(1);
			}).ToArray());
		}
        
		public async Task<Face[]> DetectAsync(Stream imageStream, bool returnFaceId, bool returnFaceLandmarks, IEnumerable<FaceAttributeType> returnFaceAttributes)
		{
			var requestUrl = $"{Constants.FaceEndpoint}/detect?returnFaceId={returnFaceId}&returnFaceLandmarks={returnFaceLandmarks}&returnFaceAttributes={GetAttributeString(returnFaceAttributes)}";
			return await SendRequestAsync<Stream, Face[]>(HttpMethod.Post, requestUrl, imageStream);
		}

		async Task<TResponse> SendRequestAsync<TRequest, TResponse>(HttpMethod httpMethod, string requestUrl, TRequest requestBody)
		{
			var request = new HttpRequestMessage(httpMethod, Constants.FaceEndpoint);
			request.RequestUri = new Uri(requestUrl);
			if (requestBody != null)
			{
				if (requestBody is Stream)
				{
					request.Content = new StreamContent(requestBody as Stream);
					request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
				}
				else
				{
					// If the image is supplied via a URL
					request.Content = new StringContent(JsonConvert.SerializeObject(requestBody, s_settings), Encoding.UTF8, "application/json");
				}
			}

			HttpResponseMessage responseMessage = await _client.SendAsync(request);
			if (responseMessage.IsSuccessStatusCode)
			{
				string responseContent = null;
				if (responseMessage.Content != null)
				{
					responseContent = await responseMessage.Content.ReadAsStringAsync();
				}
				if (!string.IsNullOrWhiteSpace(responseContent))
				{
					return JsonConvert.DeserializeObject<TResponse>(responseContent, s_settings);
				}
				return default(TResponse);
			}
			else
			{
				if (responseMessage.Content != null && responseMessage.Content.Headers.ContentType.MediaType.Contains("application/json"))
				{
					string error = await responseMessage.Content.ReadAsStringAsync();
					ClientError ex = JsonConvert.DeserializeObject<ClientError>(error);
					if (ex.Error != null)
					{
						throw new FaceAPIException(ex.Error.ErrorCode, ex.Error.Message, responseMessage.StatusCode);
					}
					else
					{
						ServiceError serviceEx = JsonConvert.DeserializeObject<ServiceError>(error);
						if (ex != null)
						{
							throw new FaceAPIException(serviceEx.ErrorCode, serviceEx.Message, responseMessage.StatusCode);
						}
						else
						{
							throw new FaceAPIException("Unknown", "Unknown Error", responseMessage.StatusCode);
						}
					}
				}
				responseMessage.EnsureSuccessStatusCode();
			}
			return default(TResponse);
		}

		#region IDisposable

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_client != null)
				{
					_client.Dispose();
					_client = null;
				}
			}
		}

		#endregion
	}
}
