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

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using EmployeeDirectory.Utilities;

namespace EmployeeDirectory.iOS
{
	/// <summary>
	/// A specialized ImageDownloader that uses the Library/Caches directory
	/// of iOS and that loads UIImages from files.
	/// </summary>
	public class UIKitImageDownloader : ImageDownloader
	{
		string cachePath;

		public UIKitImageDownloader ()
		{
			cachePath = Environment.GetFolderPath (Environment.SpecialFolder.InternetCache);
		}

		protected override DateTime? GetLastWriteTimeUtc (string fileName)
		{
			return File.GetLastWriteTimeUtc (Path.Combine (cachePath, fileName));
		}

		protected override Stream OpenStorage (string fileName, FileMode mode)
		{
			return File.Open (Path.Combine (cachePath, fileName), mode);
		}

		protected override object LoadImage (Stream stream)
		{
			return UIImage.LoadFromData (NSData.FromStream (stream), 2);
		}
	}
}

