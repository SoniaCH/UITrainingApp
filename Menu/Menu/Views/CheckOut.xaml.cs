﻿using System;
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

        public CheckOut ()
		{
			InitializeComponent ();
            Container.Content =new StepThree();
		}


        void NextStep(object sender, EventArgs e) {
         


        }

    }
}