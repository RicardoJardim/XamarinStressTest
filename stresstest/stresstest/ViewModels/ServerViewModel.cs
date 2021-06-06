using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using stresstest.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace stresstest.ViewModels
{
    public class ServerViewModel: BaseViewModel
    {
        //private List<BoxView> items = new List<BoxView>();

        //public List<BoxView> Items
        //{
        //    get => items;
        //    set
        //    {

        //        items = value;
        //        OnPropertyChanged(nameof(Items));

        //    }
        //}
        private static FileService fileService = new FileService();

        public ICommand CreateViews
        {
            get
            {

                return new Command(async () => await FetchData());
            }
        }

        public ICommand CreateBtns
        {
            get
            {

                return new Command(async () => await FetchData());
            }
        }


        public ICommand GetData
        {
            get
            {

                return new Command(async () => await FetchData());
            }
        }

        public ServerViewModel()
        {
           
        }

        private void AddViews()
        {
            var view = new BoxView {
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand

            };
           


        }

        private async Task<bool> FetchData()
        {
            Console.WriteLine(new DateTime());

            RestService restService = RestService.GetInstance();

            _ = Task.Run(async () =>
              {
                  var response = await restService.GetItemAsync("users/random_user?size=100");
                  ProcessResponse("users",response);
              });

           _ =  Task.Run(async () =>
            {
                var response = await restService.GetItemAsync("bank/random_bank?size=100");
                ProcessResponse("bank",response);
            });

            return await Task.FromResult(true);
        }
        private void ProcessResponse(string from,string response)
        {
            _ = Task.Run(async () =>
            {
                bool res = await fileService.WriteFile(from, response);
                Console.WriteLine($"From {from} on {new DateTime()} result {res}");

            });
            
        }
    }
}


