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
using System.Net;
using System.Threading.Tasks;
using System.IO;
using PCLStorage;

namespace EmployeeDirectory.Utilities
{
	public abstract class ImageDownloader
	{
		readonly IFolder store;// = IsolatedStorageFile.GetUserStoreForApplication ();

		readonly ThrottledHttp http;

		readonly TimeSpan cacheDuration;

		public ImageDownloader (int maxConcurrentDownloads = 2)
			: this (TimeSpan.FromDays (1))
		{
			http = new ThrottledHttp (maxConcurrentDownloads);
		}

		public ImageDownloader (TimeSpan cacheDuration)
		{
			this.cacheDuration = cacheDuration;

			store = FileSystem.Current.LocalStorage;

			//HACK: move this somewhere...
//			if (!store.CheckExistsAsync ("ImageCache")) {
//				store.CreateFolderAsync ("ImageCache");
//			}
		}

		public bool HasLocallyCachedCopy (Uri uri)
		{
			var now = DateTime.UtcNow;

			var filename = Uri.EscapeDataString (uri.AbsoluteUri);

			var lastWriteTime = GetLastWriteTimeUtc (filename);

			return lastWriteTime.HasValue &&
				(now - lastWriteTime.Value) < cacheDuration;
		}

		public async Task<object> GetImageAsync (Uri uri)
		{
//			var exists = await store.CheckExistsAsync ("ImageCache");
//			if (exists != ExistenceCheckResult.FolderExists) {
				await store.CreateFolderAsync ("ImageCache", CreationCollisionOption.OpenIfExists);
//			}

			//return Task.Factory.StartNew (() => {
			return await GetImage (uri);
			//});
		}

		public async Task<object> GetImage (Uri uri)
		{
			var filename = Uri.EscapeDataString (uri.AbsoluteUri);

			if (HasLocallyCachedCopy (uri)) {
				using (var o = await OpenStorage (filename, FileAccess.Read)) {
					return LoadImage (o);
				}
			}
			else {
				using (var d = http.Get (uri)) {
					using (var o = await OpenStorage (filename, FileAccess.ReadAndWrite)) {
						d.CopyTo (o);
					}
				}
				using (var o = await OpenStorage (filename, FileAccess.Read)) {
					return LoadImage (o);
				}
			}
		}

		protected virtual DateTime? GetLastWriteTimeUtc (string fileName)
		{
//			var path = Path.Combine ("ImageCache", fileName);
			//HACK: todo fix this
//			if (store.FileExists (path)) {
//				return store.GetLastWriteTime (path).UtcDateTime;
//			} else {
//				return null;
//			}
			return null;
		}

		protected async virtual Task<Stream> OpenStorage (string fileName, FileAccess mode)
		{
			IFolder store = FileSystem.Current.LocalStorage;
			IFile file = await store.GetFileAsync (fileName);
			return await file.OpenAsync(FileAccess.ReadAndWrite);

			//return store.GetFileAsync (Path.Combine ("ImageCache", fileName));//, mode);
		}

		protected abstract object LoadImage (Stream stream);
	}
}

