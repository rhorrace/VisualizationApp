using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Visualizer : Form
    {
        private int [] values = null;
        private Graphics graph = null;
        private Random rand = new Random();

        public Visualizer()
        {
            InitializeComponent();
            InitGraph();
            BuildSortedGraph();
        }

        private void ButtonRandomize_Click(object sender, EventArgs e)
        {
            InitGraph();
            BuildSortedGraph();
            Engines.SortsShuffles.ShuffleFY(graph, values, PanelGraph.Height);
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            InitGraph();
            BuildSortedGraph();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (DropdownSorts.SelectedItem == null)
                return;

            switch(DropdownSorts.SelectedItem.ToString())
            {
                case "Bubble":
                    Engines.SortsShuffles.BubbleSort(graph, values, PanelGraph.Height);
                    break;
                case "Insertion":
                    Engines.SortsShuffles.InsertionSort(graph, values, PanelGraph.Height);
                    break;
                case "Selection":
                    Engines.SortsShuffles.SelectionSort(graph, values, PanelGraph.Height);
                    break;
                case "Heap":
                    Engines.SortsShuffles.HeapSort(graph, values, PanelGraph.Height);
                    break;
                case "Merge":
                    Engines.SortsShuffles.MergeSort(graph, values, PanelGraph.Height);
                    break;
                case "Quick":
                    Engines.SortsShuffles.QuickSort(graph, values, PanelGraph.Height);
                    break;
                case "Counting":
                    Engines.SortsShuffles.CountingSort(graph, values, PanelGraph.Height);
                    break;
                default:
                    break;
            }
        }


        private void BuildSortedGraph()
        {
            graph = PanelGraph.CreateGraphics();
            int width = PanelGraph.Width;
            int height = PanelGraph.Height;
            double delta = (double) height / width;
            values = new int[width];
            for (int i = 0; i < width; ++i)
            {
                values[i] = (int)(0 + (i * delta));
                graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, height - values[i], 1, values[i]);
            }
        }

        private void InitGraph()
        {
            graph = PanelGraph.CreateGraphics();
            int numColumns = PanelGraph.Width;
            int maxHeight = PanelGraph.Height;
            values = new int[numColumns];
            graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, numColumns, maxHeight);
        }
    }
}
