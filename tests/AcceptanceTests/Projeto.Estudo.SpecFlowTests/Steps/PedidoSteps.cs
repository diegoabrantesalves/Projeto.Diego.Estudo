using Projeto.Estudo.Core.Entities;
using TechTalk.SpecFlow;

namespace Projeto.Estudo.AcceptanceTests.StepDefinitions
{
    [Binding]
    public sealed class PedidoSteps
    {
        private  Pedido _pedido;

        [Given(@"o seguinte pedido com o nome: '([^']*)'")]
        public void PreencherPedido(string nomePedido)
        {
            _pedido = new Pedido()
            {
                Nome = nomePedido,
                DataRegistro = DateTime.Now
            };
        }

        [When(@"eu solicitar o cadastro")]
        public void WhenEuSolicitarOCadastro()
        {
            Assert.NotNull(_pedido);
        }

        [Then(@"o resultado do cadastro '([^']*)'")]
        public void ThenOResultadoDoCadastro(string nomePedido)
        {
            Assert.NotNull(_pedido);
        }
    }
}