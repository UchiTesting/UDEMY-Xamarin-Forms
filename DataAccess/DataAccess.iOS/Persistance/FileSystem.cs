
using DataAccess.Persistance;

using System;
using System.IO;

using System.Threading.Tasks;

using Xamarin.Forms;

[assembly: Dependency(typeof(DataAccess.iOS.Persistance.FileSystem))]
namespace DataAccess.iOS.Persistance
{
	/// Same on Android
	/// 

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

			using (var writer = File.CreateText(path))
			{
				await writer.WriteAsync(text);
			}
		}
	}
}


/// Should there be a Windows implementation, it would look as below.

//using Windows.Storage;

//namespace DataAccess.Windows.Persistance
//{
//	public class FileSystem : IFileSystem
//	{
//		public string[] GetFiles(string path)
//		{
//			throw new NotImplementedException();
//		}

//		public void WriteText(string fileName, string text)
//		{
//			throw new NotImplementedException();
//		}

//		public Task WriteTextAsync(string fileName, string text)
//		{
//			var localFolder = ApplicationData.Current.LocalFolder;
//			var storageFile = await localFolder.CreateFileAsync(fileName);
//			await FileIO.WriteTextAsync(storageFile, text);
//		}
//	}
//}