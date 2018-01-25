using System;

namespace Extenso.ConsoleApp
{
    public static class Program
    {
        public const string VALOR_INVALIDO = "valor inválido";

        static void Main(string[] args)
        {
            Console.Write($"informe um valor: ");

            string valor = Console.ReadLine();

            Console.WriteLine($"valor informado: {valor}");

            string valorPorExtenso = ObterValorPorExtenso(valor);

            Console.WriteLine($"o valor por extenso é: {valorPorExtenso}");

            Console.ReadKey(true);
        }

        static string InverterString(string texto)
        {
            char[] caracteres = texto.ToCharArray();

            Array.Reverse(caracteres);

            return new string(caracteres);
        }

        public static string ObterValorPorExtenso(string valor)
        {
            string nomePorExtenso = string.Empty;

            int digitoUnidade = 0;
            int digitoDezena = 0;
            int digitoCentena = 0;
            int digitoDecimo = 0;
            int digitoCentesimo = 0;

            if (ValorValido(valor))
            {
                if (valor.Contains("-"))
                {
                    valor = valor.Replace("-", string.Empty);
                    nomePorExtenso += "(menos) ";
                }

                string[] partesValor = valor.Split(',');
                valor = partesValor[0];
                string fracao = partesValor[1];
                valor = InverterString(valor);

                digitoUnidade = Convert.ToInt32(valor[0].ToString());

                switch (valor.Length)
                {
                    case 1: nomePorExtenso += ObterUnidade(digitoUnidade); break;

                    case 2:
                        {
                            digitoDezena = Convert.ToInt32(valor[1].ToString());

                            nomePorExtenso += ObterDezena(digitoDezena, digitoUnidade);
                            nomePorExtenso += " e ";
                            nomePorExtenso += ObterUnidade(digitoUnidade);
                        }
                        break;

                    case 3:
                        {
                            digitoDezena = Convert.ToInt32(valor[1].ToString());
                            digitoCentena = Convert.ToInt32(valor[2].ToString());

                            nomePorExtenso += ObterCentena(digitoCentena, digitoDezena, digitoUnidade);
                            nomePorExtenso += " e ";
                            nomePorExtenso += ObterDezena(digitoDezena, digitoUnidade);
                            nomePorExtenso += " e ";
                            nomePorExtenso += ObterUnidade(digitoUnidade);
                        }
                        break;

                    default: break;
                }

                nomePorExtenso += " real(is)";
            }
            else
                return VALOR_INVALIDO;

            return nomePorExtenso;
        }

        static bool ValorValido(string valor)
        {
            string[] partesDoValor = valor.Split(',');

            string parteInteiraDoValor = partesDoValor[0];

            bool parteInteiraEhPositiva = int.TryParse(parteInteiraDoValor, out int parteInteira) && parteInteira >= 0;
            bool parteInteiraPossuiAlgarismosAlemDaCentena = parteInteiraEhPositiva && parteInteira > 999;

            bool valorValido = !parteInteiraPossuiAlgarismosAlemDaCentena;

            return valorValido;
        }

        static string ObterCentena(int digitoCentena, int digitoDezena, int digitoUnidade)
        {
            switch (digitoCentena)
            {
                case 1: return (digitoDezena == 0 && digitoUnidade == 0) ? "cem" : "cento";
                case 2: return "duzentos";
                case 3: return "trezentos";
                case 4: return "quatrocentos";
                case 5: return "quinhentos";
                case 6: return "seiscentos";
                case 7: return "setecentos";
                case 8: return "oitocentos";
                case 9: return "novecentos";

                default: return string.Empty;
            }
        }

        static string ObterDezena(int digitoDezena, int digitoUnidade)
        {
            switch (digitoDezena)
            {
                case 1:
                    {
                        switch (digitoUnidade)
                        {
                            case 0: return "dez";
                            case 1: return "onze";
                            case 2: return "doze";
                            case 3: return "treze";
                            case 4: return "quatorze";
                            case 5: return "quinze";
                            case 6: return "dezesseis";
                            case 7: return "dezessete";
                            case 8: return "dezoito";
                            case 9: return "dezenove";

                            default: return string.Empty;
                        }
                    }

                case 2: return "vinte";
                case 3: return "trinta";
                case 4: return "quarenta";
                case 5: return "cinquenta";
                case 6: return "sessenta";
                case 7: return "setenta";
                case 8: return "oitenta";
                case 9: return "noventa";

                default: return string.Empty;
            }
        }

        static string ObterUnidade(int digitoUnidade)
        {
            switch (digitoUnidade)
            {
                case 1: return "um";
                case 2: return "dois";
                case 3: return "três";
                case 4: return "quatro";
                case 5: return "cinco";
                case 6: return "seis";
                case 7: return "sete";
                case 8: return "oito";
                case 9: return "nove";

                default: return string.Empty;
            }
        }
    }
}