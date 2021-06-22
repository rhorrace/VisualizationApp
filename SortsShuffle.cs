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
        public static void Swap(int x, int y)
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
                    Thread.Sleep(1);
                    array[j + 1] = array[j];
                    UpdateGraph(j + 1);
                    --j;
                }

                UpdateLineColor(j + 1, redBrush);
                Thread.Sleep(1);
                array[j + 1] = k;
                UpdateGraph(j + 1);
            }
        }

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
                merge(l, m, r);
            }
        }

        private static void merge(int l, int m, int r)
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
            Swap(i + 1, high);
            return i + 1;
        }
    }
}
