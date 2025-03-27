using SistemaBancario.Model;

namespace TestSistemaBancario
{
    [TestClass]
    public sealed class TestConta
    {
        [TestMethod]
        public void TestSaque()
        {
            Cliente cliente = new Cliente("Fulano", "123.456.789-00");
            Conta conta = new Conta(1, 100, cliente);
            conta.Sacar(50);
            Assert.AreEqual(50, conta.Saldo);
        }
    }
}
