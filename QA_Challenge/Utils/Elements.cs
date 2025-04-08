using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace QA_Challenge.Utils
{
    public class Elements
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Elements(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void Clicar(string seletor, bool isXPath = false)
        {
            var by = isXPath ? By.XPath(seletor) : By.CssSelector(seletor);
            var elemento = _wait.Until(ExpectedConditions.ElementToBeClickable(by));
            elemento.Click();
        }

        public void PreencherCampo(string seletor, string valor)
        {
            var elemento = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(seletor)));
            elemento.Clear();
            elemento.SendKeys(valor);
        }

        public void AguardarVisibilidade(string seletor, int timeoutSegundos, bool isXPath = false)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSegundos));
            var by = isXPath ? By.XPath(seletor) : By.CssSelector(seletor);
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
