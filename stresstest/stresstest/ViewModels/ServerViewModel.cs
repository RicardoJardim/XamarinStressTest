using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using stresstest.Models;
using stresstest.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace stresstest.ViewModels
{
    public class ServerViewModel: BaseViewModel
    {
        
        public ObservableCollection<int> Views { get; set; }
        public ObservableCollection<int> Btns { get; set; }

        private static FileService fileService = new FileService();

        public ICommand GetData
        {
            get
            {

                return new Command(async () => await FetchData());
            }
        }

        public ICommand CreateViews
        {
            get
            {

                return new Command(() => AddViews());
            }
        }

        public ICommand CreateBtns
        {
            get
            {

                return new Command( () => AddBtns());
            }
        }

        public ServerViewModel()
        {
            Views = new ObservableCollection<int>();
            Btns = new ObservableCollection<int>();
        }

        private void AddViews()
        {
            for (int i = 1; i <= 500; i++)
            {
                Views.Add(i);

            }
            Console.WriteLine("ADD VIEWS: " + Views.Count);

        }

        private void AddBtns()
        {
            for (int i = 1; i <= 500; i++)
            {
                Btns.Add(i);

            }
            Console.WriteLine("ADD Btns: " + Btns.Count);
        }

        private async Task<bool> FetchData()
        {
            Console.WriteLine(new DateTime());

            RestService restService = RestService.GetInstance();

            _ = Task.Run(async () =>
              {
                  var response = await restService.GetItemAsync("users?size=100");
                  ProcessResponse("users",response);
              });

           _ =  Task.Run(async () =>
            {
                var response = await restService.GetItemAsync("banks?size=100");
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


