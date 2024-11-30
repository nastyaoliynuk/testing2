using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class BankManagerPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public BankManagerPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
    }

    // Метод для відкриття сторінки
    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    // Метод для входу як менеджер
    public void LoginAsManager()
    {
        IWebElement managerLoginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Bank Manager Login']")));
        managerLoginButton.Click();
    }

    // Метод для додавання нового клієнта
    public void AddCustomer(string firstName, string lastName, string postalCode)
    {
        IWebElement addCustomerButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Add Customer')]")));
        addCustomerButton.Click();

        IWebElement firstNameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='First Name']")));
        firstNameInput.SendKeys(firstName);

        IWebElement lastNameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Last Name']")));
        lastNameInput.SendKeys(lastName);

        IWebElement postCodeInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Post Code']")));
        postCodeInput.SendKeys(postalCode);

        IWebElement submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Add Customer']")));
        submitButton.Click();
    }

    // Метод для отримання тексту сповіщення
    public string GetAlertText()
    {
        IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
        return alert.Text;
    }

    // Метод для прийняття сповіщення
    public void AcceptAlert()
    {
        IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
        alert.Accept();
    }

    // Метод для закриття браузера
    public void CloseDriver()
    {
        driver.Quit();
    }
}
