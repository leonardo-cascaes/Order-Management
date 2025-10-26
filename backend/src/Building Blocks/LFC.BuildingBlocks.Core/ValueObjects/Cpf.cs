using LFC.BuildingBlocks.Core.Common;

namespace LFC.BuildingBlocks.Core.ValueObjects
{
    public class Cpf
    {
        public const int Length = 11;
        public string Number { get; private set; }

        private Cpf(string number)
        {
            Number = number;
        }

        public static bool IsValid(string cpf)
        {
            var digits = StringUtils.OnlyNumbers(cpf);

            if (digits.Length != Length || HasRepeatedDigits(digits))
                return false;

            return HasValidDigits(digits);
        }

        public static Cpf Create(string cpf)
        {
            if (!IsValid(cpf))
                throw new ArgumentException("Invalid CPF.");

            return new Cpf(StringUtils.OnlyNumbers(cpf));
        }

        private static bool HasRepeatedDigits(string digits)
        {
            string[] invalids = { "00000000000", "11111111111", "22222222222",
                                  "33333333333", "44444444444", "55555555555",
                                  "66666666666", "77777777777", "88888888888", "99999999999" };
            return invalids.Contains(digits);
        }

        private static bool HasValidDigits(string digits)
        {
            var number = digits.Substring(0, Length - 2);
            var verifier = new DigitVerifier(number)
                .WithMultipliersUpTo(2, 11)
                .Replacing("0", 10, 11);

            var firstDigit = verifier.Calculate();
            verifier.AddDigit(firstDigit);
            var secondDigit = verifier.Calculate();

            return $"{firstDigit}{secondDigit}" == digits.Substring(Length - 2, 2);
        }

        public override string ToString() => Number;
    }
}
