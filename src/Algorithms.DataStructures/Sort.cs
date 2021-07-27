namespace Algorithms.DataStructures
{
    public static class Sort
    {
        public static int[] Selection(int[] list)
        {
            var lenList = list.Length;

            for (var i = 0; i < lenList - 1; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < lenList; j++)
                    if (list[j] < list[minIndex])
                        minIndex = j;
                
                var temp = list[minIndex];
                list[minIndex] = list[i];
                list[i] = temp;
            }

            return list;
        }

        public static int[] Bubble(int[] list) => Bubble(list, list.Length);

        private static int[] Bubble(int[] list, int length)
        {
            if (length == 1)
                return list;
            
            for (int i = 0; i < length - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    int temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;
                }
            }

            list = Bubble(list, length - 1);

            return list;
        }

        public static int[] Quick(int[] list) => Quick(list, 0, list.Length - 1);

        private static int[] Quick(int[] list, int initIndex, int endIndex)
        {
            if (initIndex < endIndex)
            {
                int p = QuickPartition(list, initIndex, endIndex);
                list = Quick(list, initIndex, p - 1);
                list = Quick(list, p + 1, endIndex);
            }

            return list;
        }

        private static int QuickPartition(int[] list, int initIndex, int endIndex)
        {
            var x = list[endIndex];
            var i = (initIndex - 1);

            for (int j = initIndex; j <= endIndex - 1; j++)
            {
                if (list[j] <= x)
                {
                    i++;
                    var aux = list[i];
                    list[i] = list[j];
                    list[j] = aux;
                }
            }

            var tmp = list[i + 1];
            list[i + 1] = list[endIndex];
            list[endIndex] = tmp;
            return (i + 1);
        }
    }
}