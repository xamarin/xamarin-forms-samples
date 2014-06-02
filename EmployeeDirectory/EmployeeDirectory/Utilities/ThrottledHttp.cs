//
//  Copyright 2012, Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using System;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace EmployeeDirectory.Utilities
{
	/// <summary>
	/// This class only allows a specific number of WebRequests to execute
	/// simultaneously.
	/// </summary>
	public class ThrottledHttp
	{
		Semaphore throttle;

		public ThrottledHttp (int maxConcurrent)
		{
			throttle = new Semaphore (maxConcurrent, maxConcurrent);
		}

		/// <summary>
		/// Get the specified resource. Blocks the thread until
		/// the throttling logic allows it to execute.
		/// </summary>
		/// <param name='uri'>
		/// The URI of the resource to get.
		/// </param>
		public Stream Get (Uri uri)
		{
			throttle.WaitOne ();

			var req = WebRequest.Create (uri);

			var getTask = Task.Factory.FromAsync<WebResponse> (
				req.BeginGetResponse, req.EndGetResponse, null);

			return getTask.ContinueWith (task => {
				throttle.Release ();
				var res = task.Result;
				return res.GetResponseStream ();
			}).Result;
		}
	}
}

