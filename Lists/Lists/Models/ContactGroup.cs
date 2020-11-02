using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lists.Models
{
    class ContactGroup : List<Contact>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public ContactGroup(string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }

        public ObservableCollection<Contact> FilterByName(string searchedName)
        {
            return new ObservableCollection<Contact>(this.Where(c => c.Name.ToLower().StartsWith(searchedName.ToLower())));
        }
    }
}
