using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace stresstest.ViewModels
{
    public class ApisViewModel: BaseViewModel
    {
        public ApisViewModel()
        {
            Title = "Apis";

        }

        public ICommand GetContacts {
            get {

                return new Command(async () => await Console.Out.WriteAsync("ola"));
            }
        }


    }
}
