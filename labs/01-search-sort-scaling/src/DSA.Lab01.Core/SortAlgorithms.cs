using System;

namespace DSA.Lab01
{
    public static class SortAlgorithms
    {
        public static void InsertionSort(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            
            for (int i = 1; i < values.Length; i++)
            {
                int j = i - 1;
                int stashedValue = values[i];

                while (j >= 0 && values[j] > stashedValue)
                {   
                    values[j + 1] = values[j];
                    j--;
                }
                
                values[j + 1] = stashedValue;
            }
        }
    }
}
