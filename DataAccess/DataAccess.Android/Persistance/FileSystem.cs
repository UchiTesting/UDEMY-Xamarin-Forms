
using DataAccess.Persistance;

using System;
using System.IO;
using System.Threading.Tasks;

using Xamarin.Forms;

[assembly: Dependency(typeof(DataAccess.Droid.Persistance.FileSystem))]
namespace DataAccess.Droid.Persistance
{
	class FileSystem : IFileSystem
	{
		public string[] GetFiles(string path)
		{
			throw new NotImplementedException();
		}

		public void WriteText(string fileName, string text)
		{
			throw new NotImplementedException();
		}

		public async Task WriteTextAsync(string fileName, string text)
		{
			var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(docsPath, fileName);

			using (var writer = File.AppendText(path))
			{
				await writer.WriteAsync(text);
			}

			using (var reader = File.OpenText(path))
			{
				var content = reader.ReadToEnd();

				Console.WriteLine($"TEXT FROM FILE {path}: {content}");
			}
		}
	}
}