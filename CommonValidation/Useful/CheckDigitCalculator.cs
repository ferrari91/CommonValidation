namespace CommonValidation.Useful
{
    public class CheckDigitCalculator
    {
        private string number;
        private int modulo = 11;
        private List<int> multipliers = new() { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly Dictionary<int, string> replacements = new();
        private bool useComplement = true;

        public CheckDigitCalculator(string number)
        {
            this.number = number;
        }

        public CheckDigitCalculator WithMultipliers(int start, int end)
        {
            if (start > end)
                multipliers = Enumerable.Range(end, start - end + 1).Reverse().ToList();
            else
            {
                multipliers = new List<int>();
                
                for (int i = start; i >= end; i--)
                    multipliers.Add(i);
            }
            return this;
        }

        public CheckDigitCalculator WithMultipliers(params int[] multiplicators)
        {
            multipliers = multiplicators.ToList();
            return this;
        }

        public CheckDigitCalculator ReplaceWith(string replacement, params int[] digits)
        {
            foreach (var digit in digits)
            {
                replacements[digit] = replacement;
            }
            return this;
        }

        public void AddDigit(string digit)
        {
            number = string.Concat(number, digit);
        }

        public string Calculate()
        {
            if (string.IsNullOrEmpty(number))
                return string.Empty;

            var sum = number
                .Select((digit, index) => char.GetNumericValue(digit) * multipliers[index % multipliers.Count])
                .Sum();

            var modResult = sum % modulo;
            var result = useComplement ? modulo - modResult : modResult;

            if (result >= 10)
                result = 0;

            return replacements.ContainsKey((int)result) ? replacements[(int)result] : result.ToString();
        }
    }
}
