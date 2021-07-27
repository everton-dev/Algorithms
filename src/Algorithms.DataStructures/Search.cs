namespace Algorithms.DataStructures
{
    public static class Search
    {
        public static int Linear(int[] list, int searchElement)
        {
            var lenght = list.Length;
            for (int i = 0; i < lenght; i++)
            {
                if (list[i] == searchElement)
                    return i;
            }
            return -1;
        }

        public static int LinearLeftRight(int[] list, int searchElement)
        {
            var left = 0;
            var right = list.Length - 1;

            while (left <= right)
            {
                if (list[left] == searchElement)
                    return left;

                if (list[right] == searchElement)
                    return left;

                left++;
                right--;
            }
            return -1;
        }

        public static int Binary(int[] list, int searchElement)
        {
            if (list != null && list.Length > 0)
            {
                var higherIndex = list.Length - 1;
                var result = Binary(list, 0, higherIndex, searchElement);
                return result;
            }

            return -1;
        }
        
        private static int Binary(int[] list, int lowerIndex, int higherIndex, int searchElement)
        {
            if (higherIndex >= lowerIndex)
            {
                var mid = lowerIndex + (higherIndex - lowerIndex) / 2;

                if (list[mid] == searchElement)
                    return mid;

                if (list[mid] > searchElement)
                    return Binary(list, lowerIndex, mid - 1, searchElement);

                return Binary(list, mid + 1, higherIndex, searchElement);
            }

            return -1;
        }

        public static int Ternary(int[] list, int searchElement)
        {
            if (list != null && list.Length > 0)
            {
                var higherIndex = list.Length - 1;
                var result = Ternary(list, 0, higherIndex, searchElement);
                return result;
            }

            return -1;
        }

        private static int Ternary(int[] list, int lowerIndex, int higherIndex, int searchElement)
        {
            if (higherIndex >= lowerIndex)
            {
                var mid1 = lowerIndex + (higherIndex - lowerIndex) / 3;
                var mid2 = mid1 + (higherIndex - lowerIndex) / 3;

                if (list[mid1] == searchElement)
                    return mid1;
                
                if (list[mid2] == searchElement)
                    return mid2;

                if (list[mid1] > searchElement)
                    return Ternary(list, lowerIndex, mid1 - 1, searchElement);

                if (list[mid2] < searchElement)
                    return Ternary(list, mid2 + 1, higherIndex, searchElement);

                return Ternary(list, mid1 + 1, mid2 - 1, searchElement);
            }

            return -1;
        }
    }
}