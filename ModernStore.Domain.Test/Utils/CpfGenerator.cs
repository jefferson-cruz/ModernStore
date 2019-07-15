using System;
using System.Linq;

namespace ModernStore.Domain.Test.Utils
{
    public static class CpfGenerator
    {
        static readonly int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public static string Gerar()
        {
            string cpf = new Random().Next(100000000, 999999999).ToString();
            cpf = cpf + CalcularDigitoVerificador(cpf, multiplicador1);
            cpf = cpf + CalcularDigitoVerificador(cpf, multiplicador2);

            return cpf;
        }

        private static int CalcularDigitoVerificador(string semente, int[] multiplicador)
        {
            return CalcularDigito(
                soma: SomarDigitos(semente, multiplicador)
            );
        }

        private static int CalcularDigito(int soma)
        {
            var resto = soma % 11;

            if (resto < 2)
                return 0;

            return 11 - resto;
        }

        private static int SomarDigitos(string semente, int[] multiplicador)
        {
            var soma = 0;

            for (int i = 0; i < multiplicador.Length; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador[i];

            return soma;
        }
    }
}
