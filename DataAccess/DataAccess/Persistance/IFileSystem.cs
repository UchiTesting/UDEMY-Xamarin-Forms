using System.Threading.Tasks;

namespace DataAccess.Persistance
{
	public interface IFileSystem
	{
		string[] GetFiles(string path);
		void WriteText(string fileName, string text);

		Task WriteTextAsync(string fileName, string text);
	}
}
