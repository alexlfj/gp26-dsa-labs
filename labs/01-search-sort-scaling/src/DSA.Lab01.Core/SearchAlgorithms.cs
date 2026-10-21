using System;

namespace DSA.Lab01
{
    public static class SearchAlgorithms
    {
        public static int LinearSearch(int[] values, int target)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch(int[] sortedValues, int target)
        {
            // Check for null
            if (sortedValues == null)
            {
                throw new ArgumentNullException(nameof(sortedValues));
            }
            
            int highIndex = sortedValues.Length - 1;
            int lowIndex = 0;
            
            
            while (lowIndex <= highIndex)
            {
                int midIndex = lowIndex + (highIndex - lowIndex) / 2;

                if (sortedValues[midIndex] == target)
                {
                    return midIndex;
                }
                
                if (sortedValues[midIndex] < target)
                {
                    lowIndex = midIndex + 1;
                }
                else
                {
                    highIndex = midIndex - 1;
                }
            }
    
            return -1;
        }
    }
}
