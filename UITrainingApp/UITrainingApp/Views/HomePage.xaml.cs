using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UITrainingApp.Model;

namespace UITrainingApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : MasterDetailPage
	{
        private List<Pages> pageList;
        public List<Pages> PageList
        {
            get { return pageList; }
            set
            {
                pageList = value;
                OnPropertyChanged();
            }
        }

        List<Pages> _menu = new List<Pages>();

        public HomePage ()
		{
            Detail = new NavigationPage(new DetailPage());
            InitializeComponent();
            IsPresented = true;

            PageList = LoadTheListOfPages();
            ListView1.ItemsSource = PageList;
            


        }

        void GoToPage(object sender, EventArgs e)
        {
            var Page = ListView1.SelectedItem as Pages;

            if (Page.Id == "1")
            {
                Detail = new NavigationPage(new MyAccountPage());
                IsPresented = false;
            }
        
            else if (Page.Id == "2")
            {
                Detail = new NavigationPage(new ShopPage());
                IsPresented = false;
            }

            else if (Page.Id == "3")
            {
                Detail = new NavigationPage(new FAQpage());
                IsPresented = false;
            }

            else
            {
                Detail = new NavigationPage(new Notification());
                IsPresented = false;
            }

            DisplayAlert("Item Selected", Page.Id , "Ok");
        }

        #region Class to load the menu list
        public List<Pages> LoadTheListOfPages()
        {
            _menu.Add(new Pages() { Id = "1", Title = "MY ACCOUNT", Number = "   " });
            _menu.Add(new Pages() { Id = "2", Title = "SHOP", Number = "   " });
            _menu.Add(new Pages() { Id = "3", Title = "FAQ", Number = "   " });
            _menu.Add(new Pages() { Id = "4", Title = "NOTIFICATIONS", Number = "2  " });
            return _menu;
        }
        #endregion

    }
}