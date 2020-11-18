using DataAccess.Models;
using DataAccess.Persistance;

using SQLite;

using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
		private readonly SQLiteAsyncConnection _connection;
		private ObservableCollection<Recipe> _recipes;
		public Page2()
		{
			InitializeComponent();

			_connection = DependencyService.Get<ISQLiteDB>().GetConnection();
		}

		protected override async void OnAppearing()
		{
			await _connection.CreateTableAsync<Recipe>();

			var recipes = await _connection.Table<Recipe>().ToListAsync();
			_recipes = new ObservableCollection<Recipe>(recipes);
			recipesListView.ItemsSource = _recipes;

			base.OnAppearing();
		}

		public async void OnAdd(object sender, System.EventArgs e)
		{
			var recipe = new Recipe { Name = $"Recipe {DateTime.Now:G}" };
			await _connection.InsertAsync(recipe);
			_recipes.Add(recipe);

		}
		public async void OnUpdate(object sender, System.EventArgs e)
		{
			var recipe = _recipes[0];
			recipe.Name += " UPDATED";

			await _connection.UpdateAsync(recipe);
		}
		public async void OnDelete(object sender, System.EventArgs e)
		{
			if (_recipes.Count <= 0) return;

			var recipe = _recipes[0];


			await _connection.DeleteAsync(recipe);

			_recipes.Remove(recipe);
		}
	}
}