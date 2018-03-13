using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITrainingApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITrainingApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShopSearch : ContentPage
	{
        private List<Item> itemList;
        public List<Item> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged();
            }
        }

        List<Item> _item = new List<Item>();


        public ShopSearch ()
		{
			InitializeComponent ();
            ItemList = LoadTheListOfPages();
            ListItems.ItemsSource = ItemList;
        }

        public List<Item> LoadTheListOfPages()
        {
            _item.Add(new Item() { Id = "1", Image = "handbag.png", Name = "Gucci hand bag light brown", Description="Almost new",Price="3000.00 SAR"  });
            _item.Add(new Item() { Id = "2", Image = "Leather.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR" });
            _item.Add(new Item() { Id = "3", Image = "holder.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR" });

            return _item;
        }


        #region for the search bar 

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
              
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ListItems.ItemsSource = ItemList;
            }

            else
            {
                ListItems.ItemsSource = ItemList.Where(x => x.Name.StartsWith(e.NewTextValue));
            }
        }
        #endregion


    }
}