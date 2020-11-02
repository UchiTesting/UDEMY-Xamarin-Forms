using SQLite;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactBook.Models
{
    public class Contact : INotifyPropertyChanged
    {
        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;
        int id;
        string firstName;
        string lastName;
        int age;
        string phone;
        string email;
        bool isBlocked;
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value == id) return;

                id = value;
                OnPropertyChanged();
            }
        }
        [MaxLength(100)]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == lastName) return;

                lastName = value;
                OnPropertyChanged();
            }
        }
        [MaxLength(100)]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == firstName) return;

                firstName = value;
                OnPropertyChanged();
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value == age) return;

                age = value;
                OnPropertyChanged();
            }
        }
        [MaxLength(20)]
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (value == phone) return;

                phone = value;
                OnPropertyChanged();
            }
        }
        [MaxLength(100)]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value == email) return;

                email = value;
                OnPropertyChanged();
            }
        }
        public bool IsBlocked
        {
            get
            {
                return isBlocked;
            }
            set
            {
                if (value == isBlocked) return;

                isBlocked = value;
                OnPropertyChanged();
            }
        }
        public string FullName { get => $"{FirstName} {LastName}"; }
        #endregion

        #region Constructors
        public Contact() { }

        #endregion

        #region Methods
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}