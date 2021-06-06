using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;

namespace stresstest.Services
{
    public class PhotoService
    {
        public PhotoService()
        {
        }

        public async Task<string> TakePhoto()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                Console.WriteLine("No Camera available");
                return string.Empty;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return string.Empty;

            Console.WriteLine(file.Path);
            return file.Path;
        }

        public async Task<bool> PickPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Console.WriteLine("No Camera available");
                return false;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return false;

            return true;

        }
    }
}
