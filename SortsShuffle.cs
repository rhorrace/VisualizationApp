using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Engines
{
    public class SortsShuffles
    {
        private static Random rand = new Random();
        private static int[] values;
        private static Graphics graph;
        private static int maxValue;
        private static Brush whiteBrush = new SolidBrush(Color.White);
        private static Brush blackBrush = new SolidBrush(Color.Black);
        private static Brush redBrush = new SolidBrush(Color.Red);

        #region Shuffles

        public static void ShuffleFY(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;    

            for(int i = 0;i < n;++i)
            {
                int r = rand.Next(0, i + 1);
                Swap(i, r);
            }
        }

        #endregion

        #region Sorts

        #region Bubble Sort

        public static void BubbleSort(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;
            for (int i = 0;i < n - 1;++i)
                for(int j = 0;j < n - i - 1;++j)
                {
                    UpdateLineColor(j, redBrush);
                    if (array[j] > array[j+1])
                        Swap(j, j + 1);
                    UpdateLineColor(j, whiteBrush);
                }
        }

        #endregion

        #region Insertion Sort
        public static void InsertionSort(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;
            for (int i = 1; i < n; ++i)
            {
                int k = array[i];
                int j = i - 1;


                while (j >= 0 && array[j] > k)
                {
                    UpdateLineColor(j + 1, redBrush);
                    array[j + 1] = array[j];
                    UpdateGraph(j + 1);
                    --j;
                }

                UpdateLineColor(j + 1, redBrush);
                array[j + 1] = k;
                UpdateGraph(j + 1);
            }
        }

        #endregion

        #region Selection Sort

        public static void SelectionSort(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;
            for (int i = 0; i < n - 1; ++i)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {
                    UpdateLineColor(j, redBrush);
                    if (values[j] < values[min_idx])
                        min_idx = j;
                    UpdateGraph(j);
                }
                Swap(i, min_idx);
            }
        }

        #endregion

        #region Heap Sort

        public static void HeapSort(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(n, i);

            for (int i = n - 1; i > 0; --i)
            {
                UpdateLineColor(i, redBrush);
                Swap(0, i);
                UpdateGraph(i);
                Heapify(i, 0);
            }
        }

        private static void Heapify(int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && values[l] > values[largest])
                largest = l;

            if (r < n && values[r] > values[largest])
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                UpdateLineColor(largest, redBrush);
                Swap(i, largest);
                UpdateGraph(largest);
                Heapify(n, largest);
            }
        }

        #endregion

        #region Merge Sort

        public static void MergeSort(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;
            MergeSortHelper(0, n - 1);
        }

        private static void MergeSortHelper(int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSortHelper(l, m);
                MergeSortHelper(m + 1, r);
                Merge(l, m, r);
            }
        }

        private static void Merge(int l, int m, int r)
        {
            int n1 = m - l + 1, n2 = r - m, i, j;
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (i = 0; i < n1; ++i)
                L[i] = values[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = values[m + 1 + j];

            i = j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                UpdateLineColor(k, redBrush);
                Thread.Sleep(1);
                if (L[i] <= R[j])
                {
                    values[k] = L[i++];
                }
                else
                {
                    values[k] = R[j++];
                }
                UpdateGraph(k);
                ++k;
            }

            while(i < n1)
            {
                UpdateLineColor(k, redBrush);
                Thread.Sleep(1);
                values[k] = L[i++];
                UpdateGraph(k);
                ++k;
            }

            while (j < n2)
            {
                UpdateLineColor(k, redBrush);
                Thread.Sleep(1);
                values[k] = R[j++];
                UpdateGraph(k);
                ++k;
            }
        }

        #endregion

        #region Quick Sort

        public static void QuickSort(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;
            QuickSortHelper(0, n - 1);
        }

        private static void QuickSortHelper(int low, int high)
        {
            if(low < high)
            {
                int pi = Partition(low, high);
                QuickSortHelper(low, pi - 1);
                QuickSortHelper(pi + 1, high);
            }
        }

        private static int Partition(int low, int high)
        {
            int pi = rand.Next(low, high + 1);
            Swap(pi, high);
            int pivot = values[high];
            int i = low - 1;
            for(int j = low; j <= high;++j)
            {
                if (values[j] < pivot)
                {
                    UpdateLineColor(j, redBrush);
                    ++i;
                    Swap(i, j);
                    UpdateGraph(j);
                }
            }
            UpdateLineColor(i  + 1, redBrush);
            Swap(i + 1, high);
            UpdateGraph(i + 1);
            return i + 1;
        }

        #endregion

        #region Counting Sort

        public static void CountingSort(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;
            int[] output = new int[n];
            int[] count = new int[maxValue + 1];
            for (int i = 0; i <= maxValue; ++i)
                count[i] = 0;
            for (int i = 0; i < n; ++i)
            {
                UpdateLineColor(i, redBrush);
                Thread.Sleep(1);
                ++count[values[i]];
                UpdateLineColor(i, whiteBrush);
            }
            for (int i = 1; i <= maxValue; ++i)
                count[i] += count[i - 1];
            for (int i = n - 1; i >= 0; --i)
            {
                output[count[values[i]] - 1] = values[i];
                --count[values[i]];
            }
            for (int i = 0; i < n; ++i)
            {
                UpdateLineColor(i, redBrush);
                Thread.Sleep(1);
                values[i] = output[i];
                UpdateLineColor(i, whiteBrush);
            }
        }

        #endregion

        #region Radix Sort

        public static void RadixSort(Graphics g, int[] array, int max)
        {
            if (array == null || g == null)
                return;
            values = array;
            graph = g;
            maxValue = max;
            int n = values.Length;
            int[] digits = new int[10];
            int[] output = new int[n];
            for (int exp = 1; maxValue / exp > 0; exp *= 10)
            {
                for (int i = 0; i < 10; ++i)
                    digits[i] = 0;
                for (int i = 0; i < n; ++i)
                {
                    UpdateLineColor(i, redBrush);
                    Thread.Sleep(1);
                    ++digits[(values[i] / exp) % 10];
                    UpdateLineColor(i, whiteBrush);
                }
                for (int i = 1; i < 10; ++i)
                    digits[i] += digits[i - 1];
                for (int i = n - 1; i >= 0; --i)
                {
                    int index = (values[i] / exp) % 10;
                    output[--digits[index]] = values[i];
                }
                for (int i = 0; i < n; ++i)
                {
                    UpdateLineColor(i, redBrush);
                    Thread.Sleep(1);
                    values[i] = output[i];
                    UpdateLineColor(i, whiteBrush);
                }
            }
        }

        #endregion

        #endregion

        #region Other Methods

        private static void Swap(int x, int y)
        {
            Thread.Sleep(1);
            if (values == null)
                return;
            int temp = values[x];
            values[x] = values[y];
            values[y] = temp;

            UpdateGraph(x);
            UpdateGraph(y);
        }

        private static void UpdateGraph(int x)
        {
            graph.FillRectangle(blackBrush, x, 0, 1, maxValue);
            graph.FillRectangle(whiteBrush, x, maxValue - values[x], 1, maxValue);
        }

        private static void UpdateLineColor(int x, Brush brush)
        {
            graph.FillRectangle(blackBrush, x, 0, 1, maxValue);
            graph.FillRectangle(brush, x, maxValue - values[x], 1, maxValue);
        }

        #endregion
    }
}
