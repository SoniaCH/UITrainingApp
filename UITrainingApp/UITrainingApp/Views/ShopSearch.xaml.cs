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
            _item.Add(new Item() { Id = "1", Image = "logo.png", Name = "Gucci hand bag light brown", Description="Almost new",Price="3000.00 SAR"  });
            _item.Add(new Item() { Id = "2", Image = "logo.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR" });
            _item.Add(new Item() { Id = "3", Image = "logo.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR" });

            return _item;
        }


    }
}