using QA_Challenge.Pages;
using Reqnroll;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using QA_Challenge.Utils;

namespace QA_Challenge.Steps
{
    [Binding]
    public class CadastroSteps
    {
        private readonly CadastroPage _cadastroPage;
        private readonly IWebDriver _driver;
        private readonly Elements _elements;

        public CadastroSteps()
        {
            _driver = DriverFactory.GetDriver();
            _cadastroPage = new CadastroPage(_driver);
            _elements = new Elements(_driver);
        }

        [Given("que o usuário acessa a página de cadastro")]
        public void DadoQueOUsuarioAcessaAPaginaDeCadastro()
        {
            _cadastroPage.AcessarPaginaDeCadastro();
        }

        [When("o usuário seleciona o nível de ensino {string}")]
        public void QuandoOUsuarioSelecionaONivelDeEnsino(string nivel)
        {
            _cadastroPage.SelecionarNivelEnsino(nivel);
        }

        [When("o usuário seleciona o curso {string}")]
        public void QuandoOUsuarioSelecionaOCurso(string curso)
        {
            _cadastroPage.SelecionarCurso(curso);
        }

        [When("o usuário clica no botão avançar")]
        public void QuandoOUsuarioClicaNoBotaoAvancar()
        {
            _cadastroPage.ClicarAvancar();
        }

        [When("o usuário preenche o formulário de cadastro")]
        public void QuandoOUsuarioPreencheOFormularioDeCadastro()
        {
            _cadastroPage.PreencherFormularioCadastro();
        }

        [When(@"o usuário preenche o formulário deixando o campo ""(.*)"" vazio")]
        public void QuandoOUsuarioPreencheOFormularioDeixandoOCampoVazio(string campo)
        {
            var campos = new Dictionary<string, string>
            {
                { "nome", "name" },
                { "sobrenome", "surname" },
                { "email", "email" },
                { "cpf", "cpf" },
                { "celular", "cellphone" },
                { "cep", "cep" },
                { "endereco", "address" },
                { "complemento", "complement" },
                { "bairro", "neighborhood" },
                { "cidade", "city" },
                { "estado", "state" },
                { "pais", "country" }
            };

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            foreach (var item in campos)
            {
                if (item.Key != campo.ToLower())
                {
                    var seletor = $"[data-testid='{item.Value}-input']";
                    try
                    {
                        var elemento = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(seletor)));
                        elemento.SendKeys("teste");
                    }
                    catch (WebDriverTimeoutException)
                    {
                        throw new Exception($"O campo com data-testid '{item.Value}-input' não foi encontrado ou não está visível na tela.");
                    }
                }
            }
        }

        [When("o sistema faz login com usuário {string} e senha {string}")]
        public void QuandoOSistemaFazLoginComUsuarioESenha(string usuario, string senha)
        {
            _cadastroPage.FazerLogin(usuario, senha);
        }

        [Then("o sistema deve exibir a mensagem {string} na tela inicial")]
        public void EntaoOSistemaDeveExibirAMensagemNaTelaInicial(string mensagemEsperada)
        {
            var seletor = "#app > main > div > div.flex.flex-col > main > div > h1";
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var textoAtual = wait.Until(drv => drv.FindElement(By.CssSelector(seletor))).Text;
            Assert.Equal(mensagemEsperada, textoAtual);
        }

        [Then("o sistema deve exibir a mensagem de erro de usuário {string}")]
        public void EntaoOSistemaDeveExibirAMensagemDeErroDeUsuario(string mensagemEsperada)
        {
            var xpath = $"//p[@role='alert' and contains(text(), '{mensagemEsperada}')]";
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var elemento = wait.Until(drv => drv.FindElement(By.XPath(xpath)));
            Assert.Contains(mensagemEsperada, elemento.Text.Trim());
        }

        [Then("o sistema deve exibir a mensagem de erro de senha {string}")]
        public void EntaoOSistemaDeveExibirAMensagemDeErroDeSenha(string mensagemEsperada)
        {
            var xpath = $"//p[@role='alert' and contains(text(), '{mensagemEsperada}')]";
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var elemento = wait.Until(drv => drv.FindElement(By.XPath(xpath)));
            Assert.Contains(mensagemEsperada, elemento.Text.Trim());
        }

        [Then("o campo {string} deve estar destacado com erro")]
        public void EntaoOCampoDeveEstarDestacadoComErro(string campo)
        {
            Assert.True(_cadastroPage.CampoEstaDestacadoComErro(campo), $"O campo '{campo}' não está destacado com erro.");
        }

        [Then("deve exibir a mensagem de erro {string} abaixo do campo {string}")]
        public void EntaoDeveExibirAMensagemDeErroAbaixoDoCampo(string mensagem, string campo)
        {
            Assert.True(_cadastroPage.MensagemDeErroExibida(campo, mensagem), $"Mensagem de erro '{mensagem}' não exibida para o campo '{campo}'.");
        }

        [Then(@"o sistema deve exibir a mensagem de erro ""(.*)""")]
        public void EntaoOSistemaDeveExibirAMensagemDeErro(string mensagemEsperada)
        {
            string seletorErro = "p.text-destructive[role='alert']";
            _elements.AguardarVisibilidade(seletorErro, 10);

            var mensagensErro = _driver.FindElements(By.CssSelector(seletorErro));
            bool mensagemEncontrada = mensagensErro.Any(e => e.Text.Trim().Contains(mensagemEsperada));

            Assert.True(mensagemEncontrada, $"A mensagem '{mensagemEsperada}' não foi encontrada entre os erros exibidos.");
        }

        [Then("o sistema deve exibir as seguintes mensagens de erro:")]
        public void ThenOSistemaDeveExibirAsSeguintesMensagensDeErro(Table table)
        {
            var mensagensEsperadas = table.Rows.Select(row => row["mensagens"]).ToList();

            string seletorErro = "p.text-destructive[role='alert']";
            _elements.AguardarVisibilidade(seletorErro, 10);

            var mensagensExibidas = _driver.FindElements(By.CssSelector(seletorErro))
                                           .Select(e => e.Text.Trim())
                                           .ToList();

            foreach (var mensagem in mensagensEsperadas)
            {
                mensagensExibidas.Should().Contain(mensagem, $"Esperava-se a mensagem '{mensagem}' entre os erros exibidos.");
            }

            mensagensExibidas.Count.Should().Be(mensagensEsperadas.Count, "A quantidade de mensagens exibidas deve ser igual à esperada.");
        }
    }
}
