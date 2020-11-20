using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactBookMVVM.Models
{
	public class Contact : INotifyPropertyChanged
	{
		private int id;
		private string firstName;
		private string lastName;
		private string phone;
		private string email;
		private bool isBlocked;

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
		public string FirstName
		{
			get => firstName;
			set
			{
				if (value == firstName) return;

				firstName = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FullName));
			}
		}

		public string FullName => $"{FirstName} {LastName}";
		public string LastName
		{
			get => lastName;
			set
			{
				if (value == lastName) return;

				lastName = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FullName));
			}
		}
		public string Phone
		{
			get => phone;
			set
			{
				if (value == phone) return;

				phone = value;
				OnPropertyChanged();
			}
		}
		public string Email
		{
			get => email;
			set
			{
				if (value == email) return;

				email = value;
				OnPropertyChanged();
			}
		}
		public bool IsBlocked
		{
			get => isBlocked;
			set
			{
				if (value == isBlocked) return;

				isBlocked = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string property = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}

		public override string ToString()
		{
			return $"{Id} {FirstName} {LastName} {Phone} {Email} {IsBlocked}";
		}
	}
}
