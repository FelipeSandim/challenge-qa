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

        /// <summary>
        /// Clica em um elemento. Por padrão, usa CSS Selector. Se isXPath = true, usa XPath.
        /// </summary>
        public void Clicar(string seletor, bool isXPath = false)
        {
            var by = isXPath ? By.XPath(seletor) : By.CssSelector(seletor);
            var elemento = _wait.Until(ExpectedConditions.ElementToBeClickable(by));
            elemento.Click();
        }

        /// <summary>
        /// Preenche um campo localizado por CSS Selector.
        /// </summary>
        public void PreencherCampo(string seletor, string valor)
        {
            var elemento = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(seletor)));
            elemento.Clear();
            elemento.SendKeys(valor);
        }

        /// <summary>
        /// Aguarda até que um elemento esteja visível. Por padrão, usa CSS Selector. Se isXPath = true, usa XPath.
        /// </summary>
        public void AguardarVisibilidade(string seletor, int timeoutSegundos, bool isXPath = false)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSegundos));
            var by = isXPath ? By.XPath(seletor) : By.CssSelector(seletor);
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
