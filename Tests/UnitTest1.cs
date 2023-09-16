using App;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static Dictionary<string, int> parseTests = new()
        {
            { "I", 1},
            { "II", 2},
            { "III", 3},
            { "IIII", 4},
            { "IV", 4},
            { "V", 5},
            { "VI", 6},
            { "VII", 7},
            { "VIII", 8},
            { "IX", 9},
            { "X", 10 },
            { "VV", 10 },
            { "IIIIIIIIII", 10 },
            { "VX", 5 },
            { "N", 0 },
            { "-L", -50 },
            { "-XL", -40 },
            { "-IL", -49 },
            { "CMD", 1400 },
            { "CLI", 151},
            { "DIL", 549},
            { "DID", 999},
            { "DMC", 600},
            { "DD", 1000 },
            { "CCCCC", 500 },
            { "IVIVIVIVIV", 20 },
            { "MMDDCCCCCCCCCC", 4000 },
            { "MMXXIII", 2023},
            { "MMMMMMMMMMMMDCCCLXXXI", 12881 },
            { "MMMMMDLV", 5555 },
            { "MMDCLXXXVI", 2686 },
            { "MCCXCVII", 1297 },
            { "MMMMMMMMMMMMMCLIII", 13153 },
            { "MMMMMMMMMMMMDCCCXXXVI", 12836 },
            { "MMMMMMMMMMMCCV", 11205 },
            { "MMMMMMMMMMCMXXVIII", 10928 },
            { "MMMMDCXCIV", 4694 },
            { "MMMMMMMMCMLXII", 8962 },
            { "MMMMMMMMMMMMDCXXIX", 12629 },
            { "MMMMMMMMMMDCXXXVI", 10636 },
            { "MMMCDXVIII", 3418 },
            { "MMMMMMMMDCCXVI", 8716 },
            { "CMXCVII", 997 },
            { "MMMMMCXX", 5120 },
            { "MMMMMCCLXXXVII", 5287 },
            { "MMMMMMMMMCCCLIX", 9359 },
            { "MCXLIII", 1143 },
            { "MMCCCXXXVI", 2336 },
            { "MCDLXXIX", 1479 },
            { "MMMMMMMMCXXVI", 8126 },
            { "MMMMMMCLVIII", 6158 },
            { "MMMCDXII", 3412 },
            { "MMMMMMMMMMMMCXXX", 12130 },
            { "MMMDCLXIX", 3669 },
            { "MCVIII", 1108 },
            { "MMMMDCCIII", 4703 },
            { "MCCXXX", 1230 },
            { "MMMMMMMMMDCCLVII", 9757 },
            { "MMMMMMXXV", 6025 },
            { "MMMCCXCIII", 3293 },
            { "MMMMMMMMMMMCCCIII", 11303 },
            { "MMMMDCCCXCIII", 4893 },
            { "MMMMMMMMDLXXV", 8575 },
            { "MMMMMMMMMMMMCCCLXXII", 12372 },
            { "MMCCCLVIII", 2358 },
            { "MMMMMMMMMMMCCLXXIX", 11279 },
            { "MMMMMMMMMDCXXVI", 9626 },
            { "MMMMMMXI", 6011 },
            { "MMMMDCLXVIII", 4668 },
            { "MMMMMMMMMMLXXXVIII", 10088 },
            { "MMMMMMMMMCDLI", 9451 },
            { "MMMMMCDXXIII", 5423 },
            { "MMMMMMMMDCCCXXIV", 8824 },
            { "MMMMMMMDLXIII", 7563 },
            { "MMMMMMCCXLV", 6245 },
            { "MMMDCCCXLIII", 3843 },
            { "MMMDXC", 3590 },
            { "MCMVIII", 1908 },
            { "MMMMMMMMMMCCCXII", 10312 },
            { "MMMMDXII", 4512 },
            { "MDCCLXVIII", 1768 },
            { "MMMMMMMMXII", 8012 },
            { "MMDCXXXIX", 2639 },
            { "MCMXLIX", 1949 },
            { "MMMCCCLXIII", 3363 },
            { "MMMMCCXIX", 4219 },
            { "MMMMMMMMMMDCCLXXX", 10780 },
            { "MMMMMDLXXIII", 5573 },
            { "MMMMMMMCLXIII", 7163 },
            { "DLXXIII", 573 },
            { "MMMMMMMMMMCCCLXIII", 10363 },
            { "MMMCDXXX", 3430 },
            { "MMMMCCII", 4202 },
            { "MMMMMMCCCII", 6302 },
            { "MMMMLVII", 4057 },
            { "MDXCVIII", 1598 },
            { "MMMMMMMMCMXVI", 8916 },
            { "MMCCLXXVII", 2277 },
            { "MMMMMMMMCDLXIV", 8464 },
            { "MMLXVI", 2066 },
            { "MMMMMMMMMMMLV", 11055 },
            { "MMMMMDCLVII", 5657 },
            { "MMXCV", 2095 },
            { "MMMMMMCDLXIX", 6469 },
            { "MMMMCCXXV", 4225 },
            { "CMLXXV", 975 },
            { "MMMMMDXIX", 5519 },
            { "MMMMMMMMMMMMCDXIII", 12413 },
            { "NNN", 0 },
            { "-N", -0 },
            { "NV", 5 },
        };

        [TestMethod]
        public void TestRomanNumberParseValid()
        {
            foreach (var pair in parseTests)
            {
                Assert.AreEqual(pair.Value, RomanNumber.Parse(pair.Key).Value, $"{pair.Value} == {pair.Key}");
            }
        }

        private static Dictionary<string, char> invalidParseTests = new()
        {
            { "Xx", 'x' },
            { "Xy", 'y' },
            { "AX", 'A' },
            { "210", '0' },
            { "A X", ' ' },
            { "A\nX", '\n' },
            { "A\tX", '\t' },
            { "A\aX", '\a' },
            { "A\bX", '\b' },
            { "A\rX", '\r' },
        };

        [TestMethod]
        public void TestRomanNumberParseInvalid()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                RomanNumber.Parse(null!);
            }, "null == ArgumentException");
            Assert.ThrowsException<ArgumentException>(() =>
            {
                RomanNumber.Parse("");
            }, "\"\" == ArgumentException");
            Assert.ThrowsException<ArgumentException>(() =>
            {
                RomanNumber.Parse("   ");
            }, "\"\" == ArgumentException");
            
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                RomanNumber.Parse("ABC");
            }, "\"ABC\" == ArgumentException");
            Assert.IsTrue(ex.Message.Contains("'A'") && ex.Message.Contains("'B'"), "ex.Message contains 'A' and 'B'");

            foreach (var testCase in invalidParseTests)
            {
                Assert.IsTrue(
                    Assert.ThrowsException<ArgumentException>(() =>
                    {
                        RomanNumber.Parse(testCase.Key);
                    }, $"\"{testCase}\" == ArgumentException")
                        .Message.Contains($"'{testCase.Value}'"), 
                    $"ex.Message contains '{testCase.Value}'"
                );
            }

            Assert.IsFalse(
                Assert.ThrowsException<ArgumentException>(() =>
                {
                    RomanNumber.Parse("T");
                }, $"\"T\" == ArgumentException")
                    .Message.Length < 15,
                $"ex.Message is longer or equal to 15"
            );
        }

        [TestMethod]
        public void TestToString()
        {
            Dictionary<int, string> tests = new()
            {
                {0, "N" },
                {1, "I" },
                {2, "II" },
                {3, "III" },
                {4, "IV" },
                {5, "V" },
                {6, "VI" },
                {7, "VII" },
                {8, "VIII" },
                {9, "IX" },
                {10, "X" },
                {11, "XI" },
                {12, "XII" },
                {13, "XIII" },
                {14, "XIV" },
                {15, "XV" },
                {16, "XVI" },
                {17, "XVII" },
                {18, "XVIII" },
                {19, "XIX" },
                {20, "XX" },
                { 50, "L" },
                { 67, "LXVII" },
                { 114, "CXIV" },
                { 141, "CXLI" },
                { 190, "CXC" },
                { 212, "CCXII" },
                { 234, "CCXXXIV" },
                { 239, "CCXXXIX" },
                { 312, "CCCXII" },
                { 417, "CDXVII" },
                { 497, "CDXCVII" },
                { 498, "CDXCVIII" },
                { 677, "DCLXXVII" },
                { 748, "DCCXLVIII" },
                { 801, "DCCCI" },
                { 836, "DCCCXXXVI" },
                { 884, "DCCCLXXXIV" },
                { 897, "DCCCXCVII" },
                { 936, "CMXXXVI" },
                { 946, "CMXLVI" },
                { 963, "CMLXIII" },
                { 1042, "MXLII" },
                { 1066, "MLXVI" },
                { 1068, "MLXVIII" },
                { 1076, "MLXXVI" },
                { 1139, "MCXXXIX" },
                { 1166, "MCLXVI" },
                { 1173, "MCLXXIII" },
                { 1187, "MCLXXXVII" },
                { 1205, "MCCV" },
                { 1210, "MCCX" },
                { 1248, "MCCXLVIII" },
                { 1263, "MCCLXIII" },
                { 1265, "MCCLXV" },
                { 1315, "MCCCXV" },
                { 1348, "MCCCXLVIII" },
                { 1370, "MCCCLXX" },
                { 1397, "MCCCXCVII" },
                { 1414, "MCDXIV" },
                { 1445, "MCDXLV" },
                { 1461, "MCDLXI" },
                { 1531, "MDXXXI" },
                { 1534, "MDXXXIV" },
                { 1538, "MDXXXVIII" },
                { 1548, "MDXLVIII" },
                { 1600, "MDC" },
                { 1603, "MDCIII" },
                { 1674, "MDCLXXIV" },
                { 1718, "MDCCXVIII" },
                { 1742, "MDCCXLII" },
                { 1747, "MDCCXLVII" },
                { 1784, "MDCCLXXXIV" },
                { 1796, "MDCCXCVI" },
                { 1884, "MDCCCLXXXIV" },
                { 1945, "MCMXLV" },
                { 1951, "MCMLI" },
                { 1972, "MCMLXXII" },
                { 1980, "MCMLXXX" },
                { 2026, "MMXXVI" },
                { 2043, "MMXLIII" },
                { 2196, "MMCXCVI" },
                { 2279, "MMCCLXXIX" },
                { 2290, "MMCCXC" },
                { 2364, "MMCCCLXIV" },
                { 2401, "MMCDI" },
                { 2403, "MMCDIII" },
                { 2420, "MMCDXX" },
                { 2455, "MMCDLV" },
                { 2571, "MMDLXXI" },
                { 2585, "MMDLXXXV" },
                { 2590, "MMDXC" },
                { 2661, "MMDCLXI" },
                { 2668, "MMDCLXVIII" },
                { 2682, "MMDCLXXXII" },
                { 2693, "MMDCXCIII" },
                { 2705, "MMDCCV" },
                { 2730, "MMDCCXXX" },
                { 2756, "MMDCCLVI" },
                { 2767, "MMDCCLXVII" },
                { 2777, "MMDCCLXXVII" },
                { 2799, "MMDCCXCIX" },
                { 2804, "MMDCCCIV" },
                { 2806, "MMDCCCVI" },
                { 2879, "MMDCCCLXXIX" },
                { 2914, "MMCMXIV" },
                { 2929, "MMCMXXIX" },
                { 2947, "MMCMXLVII" },
                { 2970, "MMCMLXX" },
                { -2947, "-MMCMXLVII" },
                { -2970, "-MMCMLXX" },
                { -2730, "-MMDCCXXX" },
                { -2756, "-MMDCCLVI" },
                { -2767, "-MMDCCLXVII" },
                { -2777, "-MMDCCLXXVII" },
                { -2799, "-MMDCCXCIX" },
                { -1603, "-MDCIII" },
                { -1674, "-MDCLXXIV" },
                { -1718, "-MDCCXVIII" },
                { -1742, "-MDCCXLII" },
                { -1747, "-MDCCXLVII" },
                { -1784, "-MDCCLXXXIV" },
                { -1796, "-MDCCXCVI" },
                { -1884, "-MDCCCLXXXIV" },
                { -1945, "-MCMXLV" },
                { -1951, "-MCMLI" },
                { -1972, "-MCMLXXII" },
                { -1980, "-MCMLXXX" },
            };

            foreach (var test in tests)
            {
                Assert.AreEqual(test.Value, new RomanNumber(test.Key).ToString(), $"{test.Key}.ToString() == {test.Value}");
            }

            var random = new Random();
            for (int i = 0; i < 255; i++)
            {
                int num = random.Next(-3000, 3000);
                var romanNum = new RomanNumber(num);
                string romanNumStr = romanNum.ToString();
                Assert.AreEqual(num, RomanNumber.Parse(romanNumStr).Value, $"{num} == {romanNumStr}");
            }
        }

        [TestMethod]
        public void TestRomanNumberParseIllegal()
        {
            string[] illegalValues = { "IIV", "IIX", "VVX", "IVX", "IIIX", "VIX", "LLC", "CDM", "ANNNM", "I-V", "IV-", "---", "-V-", "_-_" };

            foreach (var value in illegalValues)
            {
                Assert.ThrowsException<ArgumentException>(() =>
                {
                    RomanNumber.Parse(value);
                }, $"{value} -> Exception");
            }
        }

        [TestMethod]
        public void TestAdd()
        {
            RomanNumber r1 = new(10);
            RomanNumber r2 = new(20);

            Assert.IsInstanceOfType(r1.Add(r2), typeof(RomanNumber));
            Assert.AreEqual("XXX", r1.Add(r2).ToString());
            Assert.AreEqual(30, r1.Add(r2).Value);
            Assert.AreEqual("XXX", r2.Add(r1).ToString());
            Assert.AreEqual(30, r2.Add(r1).Value);

            var ex = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                r1.Add(null!);
            }, "r1.Add(null!) -> ArgumentNullException");
            Assert.IsTrue(ex.Message.Contains("Cannot Add null object", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestSum()
        {
            RomanNumber r1 = new(10);
            RomanNumber r2 = new(20);

            Assert.AreEqual(30, RomanNumber.Sum(r1, r2).Value, "RomanNumber.Sum(r1, r2) == 30");
            Assert.AreEqual(30, RomanNumber.Sum(r2, r1).Value, "RomanNumber.Sum(r2, r1) == 30");
            
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Sum(r1, null!), "RomanNumber.Sum(r1, null!) -> ArgumentNullException");
            var ex = Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Sum(null!), "RomanNumber.Sum(null!) -> ArgumentNullException");

            string expectedFragment = "Cannot Add null object";
            Assert.IsTrue(ex.Message.Contains(expectedFragment), $"ex.Message.Contains(${expectedFragment})");

            Random random = new();
            for (int i = 0; i < 200; i++)
            {
                int x = random.Next(-3000, 3000);
                int y = random.Next(-3000, 3000);
                Assert.AreEqual(
                    x + y, 
                    RomanNumber.Sum(new(x), new(y)).Value, 
                    $"{x} + {y} = {x + y}"
                );
            }
            
            for (int i = 0; i < 200; i++)
            {
                var x = new RomanNumber(random.Next(-3000, 3000));
                var y = new RomanNumber(random.Next(-3000, 3000));
                Assert.AreEqual(
                    x.Add(y).Value, 
                    RomanNumber.Sum(x, y).Value, 
                    $"{x} + {y} = {x.Value + y.Value}"
                );
            }
        }
    }
}