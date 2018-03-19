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
	public partial class CheckOut : ContentPage
	{
        public bool OneStart = false;
        public bool TwoStart = false;
        public bool ThreeStart = false;

        public bool OneDone = false;
        public bool TwoDone = false;
        public bool ThreeDone = false;

        public CheckOut ()
		{
			InitializeComponent ();
            OneStart = true;
            Container.Content =new StepOne();

            #region for the first Step
            SOne.BackgroundColor = Color.White;
            SOneContener.BackgroundColor = Color.Black;
            STwo.BackgroundColor = Color.White;
            STwoContener.BackgroundColor = Color.Gray;
            SThree.BackgroundColor = Color.White;
            SThreeContener.BackgroundColor = Color.Gray;
            TextOne.TextColor = Color.Black;
            TextTwo.TextColor = Color.Gray;
            TextConfirm.TextColor = Color.Gray;
            #endregion

        }

        #region for passing from step to another step
        void NextStep(object sender, EventArgs e)
        {
            if (OneStart == true && TwoStart == false)
            {
                OneDone = true;
                Container.Content = new StepTwo();
                TwoStart = true;

                // for the coloring of the first cercle
                SOne.BackgroundColor = Color.FromHex("#443E43");
                SOneContener.BackgroundColor = Color.FromHex("#443E43");
                STwo.BackgroundColor = Color.White;
                STwoContener.BackgroundColor = Color.Black;
                SThree.BackgroundColor = Color.White;
                SThreeContener.BackgroundColor = Color.Gray;
                TextOne.TextColor = Color.Black;
                TextTwo.TextColor = Color.Black;
                TextConfirm.TextColor = Color.Gray;

            }
            else if (TwoStart == true)
            {
                Container.Content = new StepThree();
                TwoDone = true;
                ThreeStart = true;
                // for the coloring of the Second cercle
                SOne.BackgroundColor = Color.FromHex("#443E43");
                SOneContener.BackgroundColor = Color.FromHex("#443E43");
                STwo.BackgroundColor = Color.FromHex("#443E43");
                STwoContener.BackgroundColor = Color.FromHex("#443E43");
                SThree.BackgroundColor = Color.White;
                SThreeContener.BackgroundColor = Color.Black;
                TextOne.TextColor = Color.Black;
                TextTwo.TextColor = Color.Black;
                TextConfirm.TextColor = Color.Black;
                BtnNext.Text = "Pay";

            }
        }
        #endregion

        #region for going back to the previeous step
        void BackStep(object sender, EventArgs e)
        {
            if (ThreeStart == true)
            {
                ThreeStart = false;
                TwoDone = false;
                Container.Content = new StepTwo();
                TwoDone = false;

                // for the coloring of the first cercle
                SOne.BackgroundColor = Color.FromHex("#443E43");
                SOneContener.BackgroundColor = Color.FromHex("#443E43");
                STwo.BackgroundColor = Color.White;
                STwoContener.BackgroundColor = Color.Black;
                SThree.BackgroundColor = Color.White;
                SThreeContener.BackgroundColor = Color.Gray;
                TextOne.TextColor = Color.Black;
                TextTwo.TextColor = Color.Black;
                TextConfirm.TextColor = Color.Gray;
                BtnNext.Text = "Next";

            }
            else if (TwoStart == true)
            {
                Container.Content = new StepOne();
                TwoDone = false;
                TwoStart = false;
                OneDone = false;
                // for the coloring of the Second cercle
                SOne.BackgroundColor = Color.White;
                SOneContener.BackgroundColor = Color.Black;
                STwo.BackgroundColor = Color.White;
                STwoContener.BackgroundColor = Color.Gray;
                SThree.BackgroundColor = Color.White;
                SThreeContener.BackgroundColor = Color.Gray;
                TextOne.TextColor = Color.Black;
                TextTwo.TextColor = Color.Gray;
                TextConfirm.TextColor = Color.Gray;

            }



        }

        #endregion


        #region for going to the search page
        void GoToSearchPage(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ShopSearch());
        }
        #endregion

        #region for going to the search page
        void GoToHomePage(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new HomePage());
        }
        #endregion

    }
}