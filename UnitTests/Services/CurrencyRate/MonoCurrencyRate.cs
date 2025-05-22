using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services.CurrencyRate;

namespace UnitTests.Services.CurrencyRate
{
    [TestClass]
    public sealed class MonoCurrencyRateTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var currencyRate = new MonoCurrencyRate();
            Assert.IsNotNull(currencyRate, "Default cons MUST create obj");
            //Assert.IsNull(currencyRate);
        }

        [TestMethod]
        public void InterfaceTest()
        {
            var currencyRate = new MonoCurrencyRate();
            Assert.IsInstanceOfType<ICurrencyRate>(currencyRate, "MUST implement ICurrencyRate");  Assert.IsNotInstanceOfType<App.Services.CurrencyRate.CurrencyRate>(currencyRate, "MUST NOT implement CurrencyRate");
        }

        [TestMethod]
        public void GetCurrencyRatesAsyncTest()
        {
            var currencyRate = new MonoCurrencyRate();
            var task = currencyRate.GetCurrencyRatesAsync();
            Assert.IsNotNull(task, "GetCurrencyRatesAsync MUST return Task");
            Assert.IsInstanceOfType<Task>(task, "GetCurrencyRatesAsync MUST return Task");

            var rates = task.Result;
            //List<App.Services.CurrencyRate.CurrencyRate> rates = null;
            Assert.IsNotNull(rates, "GetCurrencyRatesAsync MUST return List<CurrencyRate>"); 
//Assert.IsInstanceOfType<List<App.Services.CurrencyRate.CurrencyRate>>(rates, "GetCurrencyRatesAsync MUST return List<CurrencyRate>");
            Assert.IsTrue(rates.Any(), "GetCurrencyRatesAsync MUST return non-empty list");

        }
    }
}
