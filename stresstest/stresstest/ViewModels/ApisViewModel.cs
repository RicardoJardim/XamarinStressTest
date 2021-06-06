using System;
using System.Threading.Tasks;
using System.Windows.Input;
using stresstest.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace stresstest.ViewModels
{
    public class ApisViewModel: BaseViewModel
    {
        private static GpsService gpsService = new GpsService();
        private static PhotoService photoService = new PhotoService();
        private static ContactsService contactsService = new ContactsService();

        public ApisViewModel()
        {
            Title = "Apis";

        }
        public ICommand GetCamera
        {
            get
            {

                return new Command(async () => await getCamera());
            }
        }
        public ICommand GetGallery
        {
            get
            {

                return new Command(async () => await getGallery());
            }
        }


        public ICommand GetGPS
        {
            get
            {

                return new Command(async () => await getLocation());
            }
        }

        public ICommand GetContacts
        {
            get
            {

                return new Command(async () => await getContacts());
            }
        }

       
        private async Task getCamera()
        {
            await photoService.TakePhoto();
        }

        private async Task getGallery()
        {
            await photoService.PickPhoto();
        }

        private async Task getLocation()
        {
            await gpsService.GetCurrentLocation();
        }
        private async Task getContacts()
        {
            await contactsService.GetContacs();
        }
    }
}
