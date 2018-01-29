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
            Assert.AreEqual("(menos) duzentos e trinta real(is)", Program.ObterValorPorExtenso("-230,00"));
            Assert.AreEqual("(menos) vinte e três real(is)", Program.ObterValorPorExtenso("-23,00"));
            Assert.AreEqual("(menos) três real(is) e setenta e cinco centavo(s)", Program.ObterValorPorExtenso("-3,75"));
            Assert.AreEqual("(menos) setenta e cinco centavo(s)", Program.ObterValorPorExtenso("-0,75"));
        }

        [TestMethod]
        public void TestarValoresComFracaoMaiorQueZero()
        {
            Assert.AreEqual("treze real(is) e noventa e dois centavo(s)", Program.ObterValorPorExtenso("13,92"));
            Assert.AreEqual("cinquenta real(is) e vinte e três centavo(s)", Program.ObterValorPorExtenso("50,23"));
            Assert.AreEqual("novecentos e noventa e nove real(is) e sessenta e quatro centavo(s)", Program.ObterValorPorExtenso("999,64"));
            Assert.AreEqual("cinco real(is) e quarenta e um centavo(s)", Program.ObterValorPorExtenso("5,41"));
        }

        [TestMethod]
        public void TestarValoresComUnidadeDeMilhar()
        {
            Assert.AreEqual(Program.VALOR_INVALIDO, Program.ObterValorPorExtenso("1456,00"));
            Assert.AreEqual(Program.VALOR_INVALIDO, Program.ObterValorPorExtenso("53548,56"));
            Assert.AreEqual(Program.VALOR_INVALIDO, Program.ObterValorPorExtenso("1000,00"));
            Assert.AreEqual(Program.VALOR_INVALIDO, Program.ObterValorPorExtenso("956874,00"));
        }

        [TestMethod]
        public void TestarValoresValidos()
        {
            Assert.AreEqual("quarenta e dois real(is) e oitenta e nove centavo(s)", Program.ObterValorPorExtenso("42,89"));
            Assert.AreEqual("quarenta e dois real(is)", Program.ObterValorPorExtenso("42,00"));
            Assert.AreEqual("seiscentos e setenta e oito real(is)", Program.ObterValorPorExtenso("678,00"));
            Assert.AreEqual("trinta e quatro centavo(s)", Program.ObterValorPorExtenso("0,34"));
        }
    }
}