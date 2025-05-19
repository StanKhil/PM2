using System;
using App.Services.CurrencyRate;

namespace App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var task1 = new NbuCurrencyRate().GetCurrencyRatesAsync();
            var task2 = new MonoCurrencyRate().GetCurrencyRatesAsync();

            var rates1 = await task1;
            Console.WriteLine(rates1);
            /*PrintCurrencyRates(rates1);
            
            var rates2 = await task2;
            PrintCurrencyRates(rates2);*/

        }

        /*static void PrintCurrencyRates(List<CurrencyRate> rates)
        {
            foreach (var rate in rates)
            {
                Console.WriteLine($"({rate.ShortName}): {rate.RateBuy} / {rate.RateSell}");
            }
            Console.WriteLine("-------------------");
        }*/
    }
}
