using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace stresstest.ViewModels
{
    public class CpuViewModel:BaseViewModel
    {
        private double label = 0;
        public double LabelText { get => label; set {

                label = value;
                OnPropertyChanged(nameof(LabelText));

            }
        }

        public ICommand RunTest
        {
            get
            {

                return new Command( () =>  test());
            }
        }

        private void test()
        {
            Console.WriteLine(new DateTime());
            LabelText = 0;
            double result = 0;
            for (int j = 1; j <= 5; j++)
            {
                for (int k = 1; k <= 100000; k++)
                {
                    result += Math.Log((double)k, (double)2) + (3 * k) / (2 * j) + Math.Sqrt(k) + Math.Pow(k, j - 1);
                }
            }
            LabelText = result;


            Console.WriteLine(new DateTime());

           
        }



    }
}
