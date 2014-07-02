using System;
using System.Threading.Tasks;

namespace WorkingWithFiles
{
	public interface ISaveAndLoad
	{
		void SaveText (string filename, string text);
		string LoadText (string filename);
	}
}

