using System;

namespace Algorithms
{
    public class MedianOfTwoSortedArrays
    {
        //Analysis: Assuming nums2.Length is not greater than nums1.Length, there
        //          are only in total 4 cases need to be considered as below.
        //          We need only do divide and conquer on case 4.
        //          The relationship of cutpoint (mid1 and mid2) between nums1 and nums2 is:
        //           mid2 = (len1 + len2) / 2 - mid1 - 2;
        // Case 1: [][][][][][][][][]           <- nums1
        //               null                   <- nums2
        //
        // Case 2: [][][][][][]                 <- nums1
        //                     [][][][][][]     <- nums2
        //
        // Case 3:             [][][][][][][][] -< nums1
        //         [][][][][][]                 -< nums2
        //
        // Case 4: [][][][][][][][][]           -< nums1
        //           [][][][][][][]             -< nums2
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length, len2 = nums2.Length, halfIndex = (len1 + len2 - 1) / 2, odd = (len1 + len2) % 2, halfLength = (len1 + len2) / 2;
            if (len1 < len2) return FindMedianSortedArrays(nums2, nums1);
            //Case 1, 2
            if (len2 == 0 || nums1[len1 - 1] <= nums2[0])
                if (len1 != len2)
                    return odd == 1 ? nums1[halfIndex] : (nums1[halfIndex] + nums1[halfIndex + 1]) / 2d;
                else return (nums1[len1 - 1] + nums2[0]) / 2d;
            //Case 3
            if (nums2[len2 - 1] <= nums1[0])
                if (len1 != len2)
                    return odd == 1 ? nums1[halfIndex - len2] : (nums1[halfIndex - len2] + nums1[halfIndex - len2 + 1]) / 2d;
                else return (nums2[len1 - 1] + nums1[0]) / 2d;
            //Case 4
            for (int i = 0, j = len1 - 1, mid1 = (i + j) >> 1, mid2 = halfLength - mid1 - 2; ; mid1 = (i + j) >> 1, mid2 = halfLength - mid1 - 2)
                if (mid2 < -1) j = mid1 - 1;
                else if (mid2 >= len2) i = mid1 + 1;
                else
                {
                    int d11 = nums1[mid1], d12 = nums1[mid1 + 1];
                    int d21 = mid2 == -1 ? int.MinValue : nums2[mid2];
                    int d22 = mid2 + 1 == len2 ? int.MaxValue : nums2[mid2 + 1];
                    int d1 = Math.Max(d11, d21), d2 = Math.Min(d12, d22);
                    if (d11 > d22) j = mid1 - 1;
                    else if (d21 > d12) i = mid1 + 1;
                    else return odd == 1 ? d2 : (d1 + d2) / 2d;
                }
            return -1;
        }

        //public static void Main()
        //{
        //    var mdianOfTwoSortedArrays = new MedianOfTwoSortedArrays();
        //    MedianOfTwoSortedArrays = mdianOfTwoSortedArrays.FindMedianSortedArrays()

        //}
    }
}