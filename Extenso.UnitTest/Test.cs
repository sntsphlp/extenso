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
            Assert.AreEqual(Program.VALOR_INVALIDO, Program.EscreverValorPorExtenso("-23,00"));
        }

        [TestMethod]
        public void TestarValoresComFracaoMaiorQueZero()
        {
            Assert.AreEqual(Program.VALOR_INVALIDO, Program.EscreverValorPorExtenso("13,92"));
        }

        [TestMethod]
        public void TestarValoresComUnidadeDeMilhar()
        {
            Assert.AreEqual(Program.VALOR_INVALIDO, Program.EscreverValorPorExtenso("1456,00"));
        }

        [TestMethod]
        public void TestarValoresValidos()
        {
            Assert.AreEqual("quarenta e dois real(is)", Program.EscreverValorPorExtenso("42,00"));
            Assert.AreEqual("seiscentos e setenta e oito real(is)", Program.EscreverValorPorExtenso("678,00"));
        }
    }
}