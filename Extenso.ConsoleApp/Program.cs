using System;

namespace Extenso.ConsoleApp
{
    public static class Program
    {
        public const string VALOR_INVALIDO = "valor inválido";
        public const string SINAL_DE_SUBTRACAO = "-";

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
            string valorPorExtenso = string.Empty;

            if (ValorValido(valor))
            {
                valorPorExtenso += ObterParteInteiraDoValorPorExtenso(valor);

                valorPorExtenso += ObterParteFracionadaDoValorPorExtenso(valor);
            }
            else
                return VALOR_INVALIDO;

            return valorPorExtenso;
        }

        static string ObterParteInteiraDoValorPorExtenso(string valor)
        {
            string valorPorExtenso = string.Empty;
            string parteInteiraStr = string.Empty;
            int parteInteiraInt = 0;

            int digitoUnidade = 0;
            int digitoDezena = 0;
            int digitoCentena = 0;

            if (ValorEhNegativo(valor))
            {
                parteInteiraStr = ObterParteInteiraSemSinalDeSubtracao(valor);
                valorPorExtenso += "(menos) ";
            }
            else
                parteInteiraStr = ObterParteInteira(valor);

            parteInteiraInt = Convert.ToInt32(parteInteiraStr);

            if (parteInteiraInt != 0)
            {
                string parteInteiraInvertida = InverterString(parteInteiraStr);
                parteInteiraInvertida = parteInteiraInvertida.PadRight(3, '0');

                digitoUnidade = Convert.ToInt32(parteInteiraInvertida[0].ToString());
                digitoDezena = Convert.ToInt32(parteInteiraInvertida[1].ToString());
                digitoCentena = Convert.ToInt32(parteInteiraInvertida[2].ToString());

                if (parteInteiraInt < 10)
                {
                    valorPorExtenso += ObterUnidade(digitoUnidade);
                }
                else if (parteInteiraInt < 100)
                {
                    valorPorExtenso += ObterDezena(digitoDezena, digitoUnidade);

                    if (parteInteiraInt >= 20 && digitoUnidade != 0)
                    {
                        valorPorExtenso += " e ";
                        valorPorExtenso += ObterUnidade(digitoUnidade);
                    }
                }
                else
                {
                    valorPorExtenso += ObterCentena(digitoCentena, digitoDezena, digitoUnidade);

                    if (digitoDezena != 0)
                    {
                        valorPorExtenso += " e ";
                        valorPorExtenso += ObterDezena(digitoDezena, digitoUnidade);
                    }

                    if (digitoUnidade != 0)
                    {
                        valorPorExtenso += " e ";
                        valorPorExtenso += ObterUnidade(digitoUnidade);
                    }
                }

                valorPorExtenso += " real(is)";
            }

            return valorPorExtenso;
        }

        static string ObterParteFracionadaDoValorPorExtenso(string valor)
        {
            string valorPorExtenso = string.Empty;
            string parteFracionadaStr = ObterParteFracionada(valor);
            int parteInteiraInt = 0;
            string parteInteiraStr = string.Empty;
            int parteFracionadaInt = 0;

            int digitoDezena = 0;
            int digitoUnidade = 0;

            parteFracionadaInt = Convert.ToInt32(parteFracionadaStr);

            if (parteFracionadaInt != 0)
            {
                parteInteiraStr = ValorEhNegativo(valor) ? ObterParteInteiraSemSinalDeSubtracao(valor) : ObterParteInteira(valor);

                parteInteiraInt = Convert.ToInt32(parteInteiraStr);

                if (parteInteiraInt != 0)
                    valorPorExtenso += " e ";

                string parteFracionadaInvertida = InverterString(parteFracionadaStr);
                parteFracionadaInvertida = parteFracionadaInvertida.PadRight(2, '0');

                digitoUnidade = Convert.ToInt32(parteFracionadaInvertida[0].ToString());
                digitoDezena = Convert.ToInt32(parteFracionadaInvertida[1].ToString());

                if (parteFracionadaInt < 10)
                {
                    valorPorExtenso += ObterUnidade(digitoUnidade);
                }
                else
                {
                    valorPorExtenso += ObterDezena(digitoDezena, digitoUnidade);

                    if (parteFracionadaInt >= 20 && digitoUnidade != 0)
                    {
                        valorPorExtenso += " e ";
                        valorPorExtenso += ObterUnidade(digitoUnidade);
                    }
                }

                valorPorExtenso += " centavo(s)";
            }

            return valorPorExtenso;
        }

        static bool ValorValido(string valor)
        {
            string parteInteira = ObterParteInteira(valor);

            if (ValorEhNegativo(valor))
                parteInteira = ObterParteInteiraSemSinalDeSubtracao(valor);

            bool parteInteiraEhMenorQueMil = Convert.ToInt32(parteInteira) < 1000;

            bool valorValido = parteInteiraEhMenorQueMil;

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

        static bool ValorEhNegativo(string valor)
        {
            string parteInteiraDoValor = ObterParteInteira(valor);

            bool valorEhNegativo = parteInteiraDoValor.Contains(SINAL_DE_SUBTRACAO);

            return valorEhNegativo;
        }

        static string ObterParteInteiraSemSinalDeSubtracao(string valor)
        {
            string parteInteiraDoValor = ObterParteInteira(valor);

            string parteInteiraDoValorSemSinalDeSubtracao = parteInteiraDoValor.Replace(SINAL_DE_SUBTRACAO, string.Empty);

            return parteInteiraDoValorSemSinalDeSubtracao;
        }

        static string ObterParteInteira(string valor)
        {
            string[] partesDoValor = valor.Split(',');

            string parteInteiraDoValor = partesDoValor[0];

            return parteInteiraDoValor;
        }

        static string ObterParteFracionada(string valor)
        {
            string[] partesDoValor = valor.Split(',');

            string parteFracionadaDoValor = partesDoValor[1];

            return parteFracionadaDoValor;
        }
    }
}