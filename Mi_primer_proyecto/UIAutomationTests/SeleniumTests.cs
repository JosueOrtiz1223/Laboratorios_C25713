using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationTests;

public class SeleniumTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();

        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [Test]
    public void CrearPais_DeberiaMostrarMensajeDeConfirmacion()
    {

        string url = "http://localhost:8080/";


        _driver.Navigate().GoToUrl(url);

        IWebElement titulo = _wait.Until(driver =>
            driver.FindElement(By.XPath("//*[contains(text(), 'Lista de países')]"))
        );

        Assert.That(titulo.Text, Does.Contain("Lista de países"));

        IWebElement botonAgregar = _wait.Until(driver =>
            driver.FindElement(By.XPath("//button[contains(text(), 'Agregar país') or contains(text(), 'Agregar pais')]"))
        );

        Assert.That(botonAgregar.Displayed, Is.True);

        botonAgregar.Click();

        var inputs = _wait.Until(driver =>
        {
            var elementos = driver.FindElements(By.CssSelector("input"));
            return elementos.Count >= 2 ? elementos : null;
        });

        Assert.That(inputs.Count, Is.GreaterThanOrEqualTo(2));


        inputs[0].Clear();
        inputs[0].SendKeys("Canadá");

        IWebElement dropdownContinente = _wait.Until(driver =>
            driver.FindElement(By.CssSelector("select"))
        );

        SelectElement selectContinente = new SelectElement(dropdownContinente);
        selectContinente.SelectByText("América");

        inputs[1].Clear();
        inputs[1].SendKeys("Inglés");
        
        Assert.That(inputs[0].GetAttribute("value"), Is.EqualTo("Canadá"));
        Assert.That(selectContinente.SelectedOption.Text, Is.EqualTo("América"));
        Assert.That(inputs[1].GetAttribute("value"), Is.EqualTo("Inglés"));

        IWebElement botonGuardar = _wait.Until(driver =>
            driver.FindElement(By.XPath("//button[contains(text(), 'Guardar')]"))
        );

        botonGuardar.Click();

        IWebElement mensajeConfirmacion = _wait.Until(driver =>
            driver.FindElement(By.XPath("//*[contains(text(), 'País agregado correctamente')]"))
        );

        Assert.That(mensajeConfirmacion.Displayed, Is.True);
        Assert.That(mensajeConfirmacion.Text, Does.Contain("País agregado correctamente"));

    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
