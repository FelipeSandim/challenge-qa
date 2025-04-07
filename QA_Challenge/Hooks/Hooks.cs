using Reqnroll;
using QA_Challenge;

[Binding]
public class Hooks
{
    [AfterScenario]
    public void AfterScenario()
    {
        DriverFactory.QuitDriver();
    }
}
