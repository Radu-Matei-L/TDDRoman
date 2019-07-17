using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRoman
{
    public class RomanConvertor
    {
        static void Main(string[] args)
        {

        }

        private Dictionary<char, int> dictionary = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        private bool CanRepeat(char romanLetter)
        {
            var repeatableLetters = new HashSet<char>(){'I','X','C','M'};
            return repeatableLetters.Contains(romanLetter);
        }



        public int Convert(string roman)
        {
            List<string> tokenizedRomans = new List<string>();

            char letter = roman[0];
            string token = letter.ToString();
            for (int i = 1; i < roman.Length; i++)
            {
                if (checkedIfDifference(roman, i - 1))
                {
                    token += roman[i];
                    tokenizedRomans.Add(token);
                    if (i < roman.Length - 1)
                    {
                        letter = roman[i + 1];
                        token = letter.ToString();
                    }
                    else
                    {
                        token = "";
                    }
                }
                else
                {
                    if (roman[i] == letter)
                    {
                        token += letter;
                    }
                    else
                    {
                        tokenizedRomans.Add(token);
                        letter = roman[i];
                        token = letter.ToString();
                    }
                }
            }
            tokenizedRomans.Add(token);

            int result = 0;
            foreach (var tokenizedRoman in tokenizedRomans)
            {
                result += ConvertTokens(tokenizedRoman);
            }
            if (result == 0)
            {
                throw new Exception("Not a valid Roman Number");
            }
            return result;
        }

        private bool checkedIfDifference(string roman, int index)
        {
            if (roman.Length != 2) return false;

            var currentValue = dictionary[roman[index]];
            var nextValue = dictionary[roman[index + 1]];
            return currentValue == nextValue / 5 || currentValue == nextValue / 10;
        }

        private int ConvertTokens(string token)
        {
            int result = 0;

            foreach (var element in dictionary)
            {
                if (token.Equals(element.Key.ToString()))
                {
                    return element.Value;
                }

                if (checkedIfDifference(token, 0))
                {
                    return dictionary[token[1]] - dictionary[token[0]];
                }
                if (CanRepeat(element.Key))
                {
                    string doubleKey = element.Key.ToString() + element.Key.ToString();
                    string tripleKey = element.Key.ToString() + element.Key.ToString() + element.Key.ToString();

                    if (token.Contains(doubleKey))
                    {
                        if (token.Contains(tripleKey))
                        {
                            result += 3 * element.Value;
                        }
                        else
                        {
                            result += 2 * element.Value;
                        }
                    }
                }
            }


            return result;
        }
    }
}
