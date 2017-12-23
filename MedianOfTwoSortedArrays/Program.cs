using System;
using System.Linq;

namespace MedianOfTwoSortedArrays
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine(new Solution().FindMedianSortedArrays(new[] {1,3}, new []{2}));
            Console.ReadKey();
        }
        
        public class Solution {
            public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            { 
                int l1 = nums1.Length;
                int l2 = nums2.Length;
                int sourceLen = l1 + l2;
                bool isOdd = sourceLen % 2 != 0;
                int len = (sourceLen + (isOdd?0:-1)) / 2;
                int i = 0, j = 0;
                for (int k = 0; k < len; k++)
                    sourceLen = i == l1 || j != l2 && nums2[j] < nums1[i] ? j++ : i++;
                return isOdd
                    ? (i == l1 || j != l2 && nums2[j] < nums1[i] ? nums2[j] : nums1[i])
                    : ((i == l1 || j != l2 && nums2[j] < nums1[i] ? nums2[j++] : nums1[i++])
                       + (i == l1 || j != l2 && nums2[j] < nums1[i] ? nums2[j] : nums1[i])) / 2d;
            }
        }
    }
}