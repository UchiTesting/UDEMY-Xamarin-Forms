using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Contact_Book_with_SQLite.Models
{
	public class Contact : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private int id;

		// Implemented with guard clause. Less nesting.
		public int Id
		{
			get => id;

			set
			{
				if (value == id) return;

				id = value;
				OnPropertyChanged();
			}
		}
		private string firstName;

		// Implemented as seen on MSDN. More nesting which means Robert C. Martin would kick some *ss, but simpler.
		public string FirstName
		{
			get => firstName;
			set
			{
				if (value != firstName)
				{
					firstName = value;

					OnPropertyChanged();
					OnPropertyChanged(nameof(FullName));
				}
			}
		}
		private string lastName;
		public string LastName
		{
			get => lastName;
			set
			{
				if (value != lastName)
				{
					lastName = value;

					OnPropertyChanged();
					OnPropertyChanged(nameof(FullName));
				}
			}
		}
		public string FullName => $"{FirstName} {LastName}";
		private string phone;
		public string Phone
		{
			get => phone;
			set
			{
				if (value != phone)
				{
					phone = value;

					OnPropertyChanged();
				}
			}
		}
		private string email;
		public string Email
		{
			get => email;
			set
			{
				if (value != email)
				{
					email = value;

					OnPropertyChanged();
				}
			}
		}

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
