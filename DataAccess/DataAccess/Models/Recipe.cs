using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;

using SQLite;

namespace DataAccess.Models
{
    [Table("Recipes")]
    class Recipe : INotifyPropertyChanged
    {
        #region Private members
        private int _id;
        private string _name;
        #endregion

        [PrimaryKey, AutoIncrement, Column("RecipeId")]
        public int Id {
            get 
            {
                return _id;
            }
            set
            {
                if (value == _id) return;

                _id = value;
                OnPropertyChanged();
            }
        }
        [MaxLength(255)]
        public string Name { get
            {
                return _name;
            }
            set {
                if (value == _name) return;

                _name = value;

                OnPropertyChanged();
            } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName= null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
