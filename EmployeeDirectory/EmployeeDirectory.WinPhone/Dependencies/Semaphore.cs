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

namespace System.Threading
{
	/// <summary>
	/// This is a partial implementation of the Semaphore class from .NET
	/// to make up for Silverlight's missing class.
	/// </summary>
	public class Semaphore
	{
		readonly int maximumCount;
		int freeCount;

		readonly object mutex = new object ();
		readonly AutoResetEvent releaseEvent = new AutoResetEvent (false);

		public Semaphore (int initialCount, int maximumCount)
		{
			this.maximumCount = maximumCount;
			this.freeCount = initialCount;
		}

		/// <summary>
		/// Waits until the freeCount is greater than one
		/// </summary>
		public void WaitOne ()
		{
			while (true) {

				var gotOne = false;

				lock (mutex) {
					if (freeCount > 0) {
						gotOne = true;
						freeCount--;
					}
				}

				if (gotOne) {
					return;
				}
				else {
					releaseEvent.WaitOne ();
				}
			}
		}

		/// <summary>
		/// Returns a free slot
		/// </summary>
		public void Release ()
		{
			lock (mutex) {
				freeCount++;
			}
			releaseEvent.Set ();
		}
	}
}
