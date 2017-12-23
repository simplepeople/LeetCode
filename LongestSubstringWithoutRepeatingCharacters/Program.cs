using System;
using System.Collections.Generic;

namespace LongestSubstringWithoutRepeatingCharacters
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LengthOfLongestSubstring("busvutpwmu"));
            Console.ReadKey();
        }
        
        public class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                if (s == "")
                    return 0;
                int index = 0, len = 1, maxLen = 1;
                var charCodes = new Dictionary<int, int>{{s[0], 0}};
                for (int i = 1; i < s.Length; i++)
                {
                    if (index + len == i && s[i] == s[index])
                    {
                        index++;
                        charCodes[s[i]] = i;
                        continue;
                    }
                    if (!charCodes.TryGetValue(s[i], out var charCodeIndex))
                    {
                        charCodes.Add(s[i], i);
                        len++;
                        continue;
                    }
                    UpdateMaxLenIfNeeded(len, ref maxLen);
                    for (int j = index; j < charCodeIndex; j++)
                        charCodes.Remove(s[j]);
                    index = charCodeIndex + 1;
                    charCodes[s[i]] = i;
                    len = i - index+1;
                }
                UpdateMaxLenIfNeeded(len, ref maxLen);
                return maxLen;
            }

            private static void UpdateMaxLenIfNeeded(int len, ref int maxLen)
            {
                if (len > maxLen)
                {
                    maxLen = len;
                }
            }
        }
    }
}