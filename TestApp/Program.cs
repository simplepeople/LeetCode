using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TestApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int n = 100000000;
            var sw = new Stopwatch();
            var sl = new Solution();
            var nums1 = new int[n];
            int i = 0;
            for (; i < n; i++)
                nums1[i] = i;
            var nums2 = new int[n];
            for (; i < n; i++)
                nums2[i] = i;
            var s = new long[4];
            for (i = 0; i < 10; i++)
            {
                sw.Start();
                sl.FindMedianSortedArrays(nums1, nums2);
                sw.Stop();
                s[0] = sw.ElapsedMilliseconds;

                sw.Restart();
                sl.FindMedianSortedArrays2(nums1, nums2);
                sw.Stop();
                s[1] = sw.ElapsedMilliseconds;

                sw.Restart();
                sl.FindMedianSortedArrays3(nums1, nums2);
                sw.Stop();
                s[2] = sw.ElapsedMilliseconds;

//                sw.Restart();
//                sl.FindMedianSortedArrays4(nums1, nums2);
//                sw.Stop();
//                s[3] = sw.ElapsedMilliseconds;
            }

            foreach (var l in s)
            {
                Console.WriteLine(l);
            }
            Console.ReadKey();

        }
        
        public class Solution {
            public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            { 
                int sourceLen = nums1.Length + nums2.Length;
                bool isOdd = sourceLen % 2 != 0;
                int len = (sourceLen+(isOdd?0:-1)) / 2;
                int i = 0, j = 0;
                for (int k = 0; k < len; k++)
                    if (i == nums1.Length || j != nums2.Length && nums2[j] < nums1[i])
                        j++;
                    else i++;
                if (isOdd)
                    return i == nums1.Length || j != nums2.Length && nums2[j] < nums1[i] ? nums2[j] : nums1[i];
                return ((i == nums1.Length || j != nums2.Length && nums2[j] < nums1[i] ? nums2[j++] : nums1[i++]) +
                        (i == nums1.Length || j != nums2.Length && nums2[j] < nums1[i] ? nums2[j] : nums1[i])) / 2d;
            }
            public double FindMedianSortedArrays2    (int[] nums1, int[] nums2)
            { 
                int sourceLen = nums1.Length + nums2.Length;         
                int len = (sourceLen+(sourceLen%2!=0?1:0)) / 2;                
                int i = 0, j = 0, a = 0;
                for (int k=0;k<len;k++)
                    a = i == nums1.Length || j!=nums2.Length && nums2[j] < nums1[i] ? nums2[j++] : nums1[i++];
                return sourceLen % 2 != 0 ? a :
                    (a + (i == nums1.Length || j != nums2.Length && nums2[j] < nums1[i] ? nums2[j] : nums1[i]))/2d;  
            }

            public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
            {
                int l1 = nums1.Length;
                int l2 = nums2.Length;
                int sourceLen = l1 + l2;
                bool isOdd = sourceLen % 2 != 0;
                int len = (sourceLen + (isOdd ? 0 : -1)) / 2;
                int i = 0, j = 0;
                for (int k = 0; k < len; k++)
                    sourceLen = i == l1 || j != l2 && nums2[j] < nums1[i] ? j++ : i++;
                return isOdd
                    ? (i == nums1.Length || j != nums2.Length && nums2[j] < nums1[i] ? nums2[j] : nums1[i])
                    : ((i == nums1.Length || j != nums2.Length && nums2[j] < nums1[i++] ? nums2[j]++ : nums1[i])
                       + (i == nums1.Length || j != nums2.Length && nums2[j] < nums1[i] ? nums2[j] : nums1[i])) / 2d;
            }
        }
    }   
}