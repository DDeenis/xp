using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public record RomanNumber
    {
        const char MINUS_SIGN = '-';
        const string INVALID_DIGIT_MESSAGE = "Invalid symbol";
        const string INVALID_DIGITS_MESSAGE = "Invalid symbols";
        const string ILLIGAL_INPUT_MESSAGE = "Illegal roman number";
        const string EMPTY_INPUT_MESSAGE = "Roman number string is empty";
        const string ADD_NULL_MESSAGE = "Cannot Add null object";

        public int Value { get; set; }

        private static Dictionary<int, string> parts = new()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };

        public RomanNumber(int value = 0)
        {
            Value = value;
        }

        public override string ToString()
        {
            if (Value == 0) return "N";

            int val = Value;
            StringBuilder str = new();
            
            if(val < 0)
            {
                str.Append(MINUS_SIGN);
                val = -val;
            }

            foreach (var part in parts)
            {
                while (val >= part.Key)
                {
                    val -= part.Key;
                    str.Append(part.Value);
                }
            }

            return str.ToString();
        }

        public RomanNumber Add(RomanNumber other)
        {
            if (other is null) throw new ArgumentNullException(ADD_NULL_MESSAGE, nameof(other));
            return this with { Value = this.Value + other.Value };
        }

        public static RomanNumber Sum(params RomanNumber[] numbers)
        {
            if (numbers is null) throw new ArgumentNullException(ADD_NULL_MESSAGE, nameof(numbers));

            //int sum = 0;

            //foreach (var num in numbers)
            //{
            //    sum += num is not null ? num.Value : throw new ArgumentNullException(ADD_NULL_MESSAGE, nameof(numbers));
            //}

            //return new(sum);

            return new(numbers.Sum(v => v is not null ? v.Value : throw new ArgumentNullException(ADD_NULL_MESSAGE, nameof(numbers))));
        }

        public static RomanNumber Parse(string romanNumber)
        {
            string? source = romanNumber?.Trim();

            if (string.IsNullOrEmpty(source)) throw new ArgumentException(EMPTY_INPUT_MESSAGE, nameof(romanNumber));

            CheckValidityOrThrow(source);
            CheckLegalityOrThrow(source);

            bool isNegative = source[0] == MINUS_SIGN;
            int endIndex = isNegative ? 1 : 0;

            int currentNumber = 0;
            int lastNumber = 0;
            int result = 0;

            for (int i = source.Length - 1; i >= endIndex; i--)
            {
                currentNumber = GetDigitValue(source[i]);

                result += lastNumber > currentNumber ? -currentNumber : currentNumber;
                lastNumber = currentNumber;
            }

            return new()
            {
                Value = isNegative ? -result : result
            };
        }

        private static int GetDigitValue(char digit)
        {
            return digit switch
            {
                'N' => 0,
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} '{digit}'", nameof(digit))
            };
        }

        private static void CheckValidityOrThrow(string romanNumber)
        {
            List<char> invalidChars = new();
            int startIndex = romanNumber.StartsWith(MINUS_SIGN) ? 1 : 0;
            for(int i = startIndex; i < romanNumber.Length; i++)
            {
                char c = romanNumber[i];
                try
                {
                    GetDigitValue(c);
                }
                catch (ArgumentException)
                {
                    invalidChars.Add(c);
                }
            }

            if (invalidChars.Count != 0)
            {
                var invaidCharsString = string.Join(", ", invalidChars.Select(c => $"'{c}'"));
                throw new ArgumentException($"{INVALID_DIGITS_MESSAGE}: {invaidCharsString}", nameof(romanNumber));
            }
        }

        private static void CheckLegalityOrThrow(string romanNumber)
        {
            int endIndex = romanNumber.StartsWith(MINUS_SIGN) ? 1 : 0;
            int maxDigit = 0;
            int lessDigitsCount = 0;

            for (int i = romanNumber.Length - 1; i >= endIndex; i--)
            {
                int digitValue = GetDigitValue(romanNumber[i]);

                if (digitValue < maxDigit)
                {
                    lessDigitsCount++;
                    if (lessDigitsCount > 1)
                    {
                        throw new ArgumentException($"{ILLIGAL_INPUT_MESSAGE} '{romanNumber}'", nameof(romanNumber));
                    }
                }
                else
                {
                    maxDigit = digitValue;
                    lessDigitsCount = 0;
                }
            }
        }
    }
}
