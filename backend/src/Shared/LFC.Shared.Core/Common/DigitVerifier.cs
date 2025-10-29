namespace LFC.Shared.Core.Common
{
    public class DigitVerifier
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new() { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly Dictionary<int, string> _substitutions = new();
        private bool _useModuleComplement = true;

        public DigitVerifier(string number)
        {
            _number = number;
        }

        public DigitVerifier WithMultipliersUpTo(int start, int end)
        {
            _multipliers.Clear();
            for (int i = start; i <= end; i++)
                _multipliers.Add(i);

            return this;
        }

        public DigitVerifier Replacing(string substitute, params int[] digits)
        {
            foreach (var d in digits)
                _substitutions[d] = substitute;
            return this;
        }

        public void AddDigit(string digit) => _number += digit;

        public string Calculate()
        {
            if (string.IsNullOrEmpty(_number))
                return "";

            var sum = 0;
            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var product = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                sum += product;
                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = sum % Module;
            var result = _useModuleComplement ? Module - mod : mod;
            return _substitutions.ContainsKey(result) ? _substitutions[result] : result.ToString();
        }
    }
}
