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
        public List<Item> allItems;
        ItemListLoad items;
     

        List<Item> _item = new List<Item>();
        public StepThree ()
		{
            allItems = new List<Item>
            {
            new Item() { Id = "1", Image = "handbag.png", Name = "Gucci hand bag light brown", Description = "New Prada", Price = "3000.00 SAR" },
            new Item() { Id = "2", Image = "glasses.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR" },
           new Item() { Id = "3", Image = "holder.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR" },
            };

            InitializeComponent ();
            items = new ItemListLoad(allItems);
            ListItems.ItemsSource = items.Items;

           
        }


        #region deleting item from the cart list
        public void DeleteClicked(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            Item listitem = (from itm in items.Items where itm.Id == item.CommandParameter.ToString() select itm).FirstOrDefault<Item>();
            items.Items.Remove(listitem);
        }


        #endregion
    }
}