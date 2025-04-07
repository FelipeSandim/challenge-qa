using Bogus;
using System;

namespace QA_Challenge.Utils
{
    public static class DataFactory
    {
        private static readonly Faker faker = new Faker("pt_BR");

        // Dados pessoais
        public static string GerarNomeAleatorio() => faker.Person.FirstName;

        public static string GerarSobrenomeAleatorio() => faker.Person.LastName;

        public static string GerarEmailAleatorio() => faker.Internet.Email();

        public static string GerarCPF() => GerarCPFValido();

        public static string GerarCelular() => faker.Phone.PhoneNumber("(##) 9####-####");
        
        public static string GerarCEP() => faker.Address.ZipCode("########");

        public static string GerarEndereco() => faker.Address.StreetName();

        public static string GerarComplemento() => faker.Address.SecondaryAddress();

        public static string GerarBairro() => faker.Address.StreetName();

        public static string GerarCidade() => faker.Address.City();

        public static string GerarEstado() => faker.Address.State();

        public static string GerarPais() => "Brasil";

        private static string GerarCPFValido()
        {
            int soma, resto;
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var random = new Random();
            string cpf = "";

            for (int i = 0; i < 9; i++)
                cpf += random.Next(0, 9).ToString();

            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            cpf += resto.ToString();

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            cpf += resto.ToString();

            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
}
