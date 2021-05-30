using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace stresstest.Views
{
    public partial class ApisPage : ContentPage
    {
        public ApisPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.Out.Write("ola");
        }

    }
}
