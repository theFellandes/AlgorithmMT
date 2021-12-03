using System.Collections.Generic;

namespace UnitTest.Sort
{
    public static class QuickSort
    {
        public static void Sort(int[] intArray)
        {
            Sort(intArray, 0, intArray.Length);
        }
        
        /// <summary>
        /// Quick Sort's overloaded version for easier method calls
        /// </summary>
        /// <param name="intArray">input array</param>
        /// <param name="start">start of the index</param>
        /// <param name="end">array's length</param>
        private static void Sort(int[] intArray, int start, int end)
        {
            //end - start < 2 then we are dealing with 1 element array
            if (end - start < 2)
                return;
            int pivotIndex = Partition(intArray, start, end);
            //Sorting the left side of the array which is smaller than the pivot
            // when the left subarray recursion ends, only then quick sort will deal with right part
            Sort(intArray, start, pivotIndex);
            //Sorting the right side of the array, which is larger than the pivot
            Sort(intArray, pivotIndex + 1, end);
        }

        /// <summary>
        /// Figuring out where the pivot will be belong in the sorted array
        /// What will be the index of the pivot, when the array is sorted
        /// This method is using the first element as the pivot
        /// </summary>
        /// <param name="intArray">input array</param>
        /// <param name="start">start index of the array</param>
        /// <param name="end">end index of the array</param>
        /// <returns></returns>
        private static int Partition(IList<int> intArray, int start, int end)
        {
            int pivot = intArray[start];
            int i = start;
            int j = end;
            
            //Traversal
            //if i is greater than j that means they have crossed.
            while (i < j)
            {
                //NOTE: Empty loop body
                //Using loop to keep decrementing j until we find an element that's less than pivot or j crosses i
                while (i < j && intArray[--j] >= pivot) ;
                //Making sure that we fell out of the loop because we found an element that's less than pivot not due
                // to j crossed i
                if (i < j)
                    intArray[i] = intArray[j]; //Moving j to i
                
                //NOTE: similar empty loop body
                while (i < j && intArray[++i] <= pivot) ;
                if (i < j)
                    intArray[j] = intArray[i]; //Moving i to j
            }

            intArray[j] = pivot;
            //index of the pivot
            return j;
        }
    }
}