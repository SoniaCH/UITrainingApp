using Menu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StepThree : ContentView
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

        public List<Item> LoadTheListOfItems()
        {
            _item.Add(new Item() { Id = "1", Image = "handbag.png", Name = "Gucci hand bag light brown", Description = "New Prada", Price = "3000.00 SAR", Close= "closemark.png" });
            _item.Add(new Item() { Id = "2", Image = "glasses.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR", Close = "closemark.png" });
            _item.Add(new Item() { Id = "3", Image = "holder.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR", Close = "closemark.png" });

            return _item;
        }



        public StepThree ()
		{
			InitializeComponent ();
            ItemList = LoadTheListOfItems();
            ListItems.ItemsSource = ItemList;
        }


        #region deleting item from the cart list

        //DeleteItem
        void DeleteItem(object sender, EventArgs e)
        {
            var Deleted = new Item();
            

            

        }
         #endregion
        }
}