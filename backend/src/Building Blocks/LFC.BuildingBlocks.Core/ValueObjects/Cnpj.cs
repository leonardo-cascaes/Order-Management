using LFC.BuildingBlocks.Core.Common;

namespace LFC.BuildingBlocks.Core.ValueObjects
{
    public class Cnpj
    {
        public const int Length = 14;
        public string Number { get; private set; }

        private Cnpj(string number)
        {
            Number = number;
        }

        public static bool IsValid(string cnpj)
        {
            var digits = StringUtils.OnlyNumbers(cnpj);

            if (digits.Length != Length || HasRepeatedDigits(digits))
                return false;

            return HasValidDigits(digits);
        }

        public static Cnpj Create(string cnpj)
        {
            if (!IsValid(cnpj))
                throw new ArgumentException("Invalid CNPJ.");

            return new Cnpj(StringUtils.OnlyNumbers(cnpj));
        }

        private static bool HasRepeatedDigits(string digits)
        {
            string[] invalids = {
                "00000000000000", "11111111111111", "22222222222222",
                "33333333333333", "44444444444444", "55555555555555",
                "66666666666666", "77777777777777", "88888888888888", "99999999999999"
            };
            return invalids.Contains(digits);
        }

        private static bool HasValidDigits(string digits)
        {
            var number = digits.Substring(0, Length - 2);
            var verifier = new DigitVerifier(number)
                .WithMultipliersUpTo(2, 9)
                .Replacing("0", 10, 11);

            var firstDigit = verifier.Calculate();
            verifier.AddDigit(firstDigit);
            var secondDigit = verifier.Calculate();

            return $"{firstDigit}{secondDigit}" == digits.Substring(Length - 2, 2);
        }

        public override string ToString() => Number;
    }
}
