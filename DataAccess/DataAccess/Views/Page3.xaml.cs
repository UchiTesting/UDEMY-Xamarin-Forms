using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Models;

using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page3 : ContentPage
	{
		const string URL = "https://jsonplaceholder.typicode.com/posts";
		private HttpClient _client = new HttpClient();
		private ObservableCollection<Post> _posts;
		public Page3()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var content = await _client.GetStringAsync(URL);
			var posts = JsonConvert.DeserializeObject<List<Post>>(content);

			_posts = new ObservableCollection<Post>(posts);
			postsListView.ItemsSource = _posts;

			base.OnAppearing();
		}

		async void OnAdd(object sender, System.EventArgs e)
		{
			var post = new Post { Title = $"Title {DateTime.Now.Ticks}" };

			var content = JsonConvert.SerializeObject(post);
			await _client.PostAsync(URL, new StringContent(content));

			_posts.Insert(0, post);
		}

		async void OnUpdate(object sender, System.EventArgs e)
		{
			if (_posts.Count <= 0) return;

			var post = _posts[0];
			post.Title += " UPDATED";

			var content = JsonConvert.SerializeObject(post);
			await _client.PutAsync($"{URL}/{post.Id}", new StringContent(content));
		}

		async void OnDelete(object sender, System.EventArgs e)
		{
			if (_posts.Count <= 0) return;
			var post = _posts[0];

			await _client.DeleteAsync($"{URL}/{post.Id}");
			_posts.Remove(post);
		}
	}
}