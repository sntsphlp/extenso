using Extenso.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Extenso.UnitTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestarValoresNegativos()
        {
            Assert.AreEqual("(menos) vinte e três real(is)", Program.ObterValorPorExtenso("-23,00"));
        }

        [TestMethod]
        public void TestarValoresComFracaoMaiorQueZero()
        {
            Assert.AreEqual("treze real(is) e noventa e dois centavo(s)", Program.ObterValorPorExtenso("13,92"));
        }

        [TestMethod]
        public void TestarValoresComUnidadeDeMilhar()
        {
            Assert.AreEqual(Program.VALOR_INVALIDO, Program.ObterValorPorExtenso("1456,00"));
        }

        [TestMethod]
        public void TestarValoresValidos()
        {
            Assert.AreEqual("quarenta e dois real(is)", Program.ObterValorPorExtenso("42,00"));
            Assert.AreEqual("seiscentos e setenta e oito real(is)", Program.ObterValorPorExtenso("678,00"));
        }
    }
}