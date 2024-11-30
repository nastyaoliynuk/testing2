using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[Binding]
public class BankingManagerSteps
{
    private IWebDriver driver;
    private BankManagerPage bankManagerPage;

    [Given(@"the banking manager page is open")]
    public void GivenTheBankingManagerPageIsOpen()
    {
        driver = new ChromeDriver();
        bankManagerPage = new BankManagerPage(driver);
        bankManagerPage.OpenLoginPage("https://www.globalsqa.com/angularJs-protractor/BankingProject");
    }

    [Given(@"the manager logs in")]
    public void GivenTheManagerLogsIn()
    {
        bankManagerPage.LoginAsManager();
    }

    [When(@"the manager adds a new customer with first name ""(.*)"", last name ""(.*)"", and postal code ""(.*)""")]
    public void WhenTheManagerAddsANewCustomerWithDetails(string firstName, string lastName, string postalCode)
    {
        bankManagerPage.AddCustomer(firstName, lastName, postalCode);
    }

    [Then(@"a success alert is displayed with message ""(.*)""")]
    public void ThenASuccessAlertIsDisplayedWithMessage(string expectedMessage)
    {
        string alertText = bankManagerPage.GetAlertText();
        Assert.That(alertText, Does.StartWith(expectedMessage), "The alert message after adding a customer is incorrect.");
        bankManagerPage.AcceptAlert();
    }


    [AfterScenario]
    public void CloseBrowser()
    {
        bankManagerPage?.CloseDriver();
    }
}
