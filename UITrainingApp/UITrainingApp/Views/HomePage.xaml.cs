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
            Detail = new NavigationPage(new Notification());
            InitializeComponent();
           IsPresented = true;

            PageList = LoadTheListOfPages();
            ListView1.ItemsSource = PageList;
            


        }

        #region Class to load the menu list
        public List<Pages> LoadTheListOfPages()
        {
            _menu.Add(new Pages() { Title = "MY ACCOUNT", Number = "" });
            _menu.Add(new Pages() { Title = "SHOP", Number = "" });
            _menu.Add(new Pages() { Title = "FAQ", Number = "" });
            _menu.Add(new Pages() { Title = "NOTIFICATIONS", Number = "2" });
            return _menu;
        }
        #endregion

    }
}