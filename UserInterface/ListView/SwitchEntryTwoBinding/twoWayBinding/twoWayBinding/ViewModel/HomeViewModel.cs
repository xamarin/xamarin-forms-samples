using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace twoWayBinding
{
	public static class HomeViewModel
	{
		
		public static ObservableCollection<light> lights { get; set; }

		static HomeViewModel ()
		{
			HomeViewModel.lights = DataSource.getLights ();
		}


	}
}

