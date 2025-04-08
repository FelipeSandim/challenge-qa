using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class DriverFactory
{
    private static IWebDriver? _driver;

    public static IWebDriver GetDriver()
    {
        if (_driver == null)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            _driver = new ChromeDriver(options);

            _driver.Manage().Window.Maximize();
        }

        return _driver;
    }

    public static void QuitDriver()
    {
        _driver?.Quit();
        _driver = null;
    }
}
