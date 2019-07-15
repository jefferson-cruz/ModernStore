using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Document : Notifiable
    {
        protected Document() { }
        public Document(string number)
        {
            Number = number;

            new ValidationContract<Document>(this)
                .IsRequired(x => x.Number)
                .HasMinLenght(x => x.Number, 11)
                .HasMaxLenght(x => x.Number, 11);

            if(!Validate(Number))
                AddNotification(nameof(Number), "The informed document number doesn't valid");
        }

        public string Number { get; private set; }

        private bool Validate(string number)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            number = number.Trim();
            number = number.Replace(".", "").Replace("-", "");
            if (number.Length != 11)
                return false;
            tempCpf = number.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return number.EndsWith(digito);
        }
    }
}
