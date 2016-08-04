using System;

namespace TodoLocalized
{
	public interface ILocale
	{
		string GetCurrent();

		void SetLocale();
	}
}

