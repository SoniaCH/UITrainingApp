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
	public partial class StepOne : ContentView
	{
		public StepOne ()
		{
			InitializeComponent ();
		}


        void SelectingPay(object sender, EventArgs e)
        {
            if (sender.Equals(Credit))
            {
                BankContener.BackgroundColor = Color.White;
                CreditContener.BackgroundColor = Color.Black;
            }
            else
            {
                BankContener.BackgroundColor = Color.Black;
                CreditContener.BackgroundColor = Color.White;
            }

        }
        void SelectingDeliver(object sender, EventArgs e)
        {
            if (sender.Equals(Express))
            {
                ExpressContener.BackgroundColor = Color.Black;
                NormalContener.BackgroundColor = Color.White;
            }
            else
            {
                ExpressContener.BackgroundColor = Color.White;
                NormalContener.BackgroundColor = Color.Black;
            }


        }
    }
}