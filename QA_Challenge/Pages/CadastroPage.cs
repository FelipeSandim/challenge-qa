using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using QA_Challenge.Utils;
using Bogus;

namespace QA_Challenge.Pages
{
    public class CadastroPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly Elements _elements;
        private readonly Faker _faker;

        public CadastroPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _elements = new Elements(driver);
            _faker = new Faker("pt_BR");
        }

        // ========================= SELETORES =========================
        public const string DropDownTipoDeGraduacao = "[data-testid='education-level-select']";
        public const string DropDownCurso = "[data-testid='graduation-combo']";
        public const string BotaoAvancar = "[data-testid='next-button']";

        public const string CPF = "cpf";
        public const string Nome = "name";
        public const string Sobrenome = "surname";
        public const string Email = "email";
        public const string Celular = "cellphone";
        public const string CEP = "cep";
        public const string Endereco = "address";
        public const string Complemento = "complement";
        public const string Bairro = "neighborhood";
        public const string Cidade = "city";
        public const string Estado = "state";
        public const string Pais = "country";

        public const string CampoUsuario = "[data-testid='username-input']";
        public const string CampoSenha = "[data-testid='password-input']";
        public const string BotaoEntrar = "[data-testid='login-button']";

        private static readonly Dictionary<string, string> MapeamentoCampos = new()
        {
            { "nome", Nome },
            { "sobrenome", Sobrenome },
            { "email", Email },
            { "cpf", CPF },
            { "celular", Celular },
            { "cep", CEP },
            { "endereco", Endereco },
            { "complemento", Complemento },
            { "bairro", Bairro },
            { "cidade", Cidade },
            { "estado", Estado },
            { "pais", Pais }
        };

        // ========================= MÉTODOS =========================

        public void AcessarPaginaDeCadastro()
        {
            _driver.Navigate().GoToUrl("https://developer.grupoa.education/subscription/");
        }

        public void SelecionarNivelEnsino(string nivel)
        {
            _elements.Clicar(DropDownTipoDeGraduacao);
            
            string xpath = nivel.ToLower() switch
            {
                "graduação" => "//*[@id='radix-vue-select-content-4']//div[normalize-space()='Graduação']",
                "pós-graduação" => "//*[@id='radix-vue-select-content-4']//div[normalize-space()='Pós-graduação']",
                _ => throw new ArgumentException("Opção de nível de ensino inválida!")
            };

            _elements.Clicar(xpath, true); // <- Aqui está o ajuste
        }

        public void SelecionarCurso(string curso)
        {
            _elements.Clicar(DropDownCurso); // esse pode continuar assim, pois é CSS

            string xpathCurso = $"//div[@role='option' and normalize-space()='{curso}']";
            _elements.AguardarVisibilidade(xpathCurso, 10, true); // ← agora sim
            _elements.Clicar(xpathCurso, true);                   // ← agora sim
        }

        public void PreencherFormularioCadastro()
        {
            PreencherFormularioComCampoVazio(string.Empty);
        }

        public void PreencherFormularioComCampoVazio(string? campoVazio)
        {
            // Traduz o nome vindo do .feature (ex: "nome") para o nome real do data-testid (ex: "name")
            if (!string.IsNullOrEmpty(campoVazio) &&
                MapeamentoCampos.TryGetValue(campoVazio.ToLower(), out var campoTestId))
            {
                campoVazio = campoTestId;
            }

            var dados = new Dictionary<string, string>
            {
                { Nome, DataFactory.GerarNomeAleatorio() },
                { Sobrenome, DataFactory.GerarSobrenomeAleatorio() },
                { Email, DataFactory.GerarEmailAleatorio() },
                { CPF, DataFactory.GerarCPF() },
                { Celular, DataFactory.GerarCelular() },
                { CEP, DataFactory.GerarCEP() },
                { Endereco, DataFactory.GerarEndereco() },
                { Complemento, DataFactory.GerarComplemento() },
                { Bairro, DataFactory.GerarBairro() },
                { Cidade, DataFactory.GerarCidade() },
                { Estado, DataFactory.GerarEstado() },
                { Pais, DataFactory.GerarPais() }
            };

            foreach (var campo in dados)
            {
                if (!campo.Key.Equals(campoVazio, StringComparison.OrdinalIgnoreCase))
                    _elements.PreencherCampo($"[data-testid='{campo.Key}-input']", campo.Value);
            }
        }

        public void ClicarAvancar()
        {
            _elements.Clicar(BotaoAvancar);
        }

        public void FazerLogin(string usuario, string senha)
        {
            _wait.Until(d => d.FindElement(By.CssSelector(CampoUsuario))).SendKeys(usuario);
            _driver.FindElement(By.CssSelector(CampoSenha)).SendKeys(senha);
            _driver.FindElement(By.CssSelector(BotaoEntrar)).Click();
        }

        public bool CampoEstaDestacadoComErro(string campo)
        {
            if (MapeamentoCampos.TryGetValue(campo.ToLower(), out var campoTestId))
            {
                var elemento = _driver.FindElement(By.CssSelector($"[data-testid='{campoTestId}-input']"));
                var classe = elemento.GetAttribute("class");
                return classe != null && (classe.Contains("border-destructive") || classe.Contains("border-red"));
            }
            return false;
        }

        public bool MensagemDeErroExibida(string campo, string mensagemEsperada)
        {
            if (MapeamentoCampos.TryGetValue(campo.ToLower(), out var campoTestId))
            {
                try
                {
                    var xpath = $"//input[@data-testid='{campoTestId}-input']/following-sibling::p[@role='alert']";
                    var elementoErro = _wait.Until(drv => drv.FindElement(By.XPath(xpath)));
                    return elementoErro.Text.Trim().Contains(mensagemEsperada);
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
