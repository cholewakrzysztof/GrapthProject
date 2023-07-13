using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrapthProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GroupBox> groupBoxes = new List<GroupBox>();
        private static Graph graph = new Graph();

        public MainWindow()
        {
            InitializeComponent();
            InitializeGroupBoxList();


            //Temporary solution
            graph = createSampleGraph();
            GraphImage.Source = ImageDrawer.DrawImage(graph);
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void nextModeBtn_Click(object sender, RoutedEventArgs e)
        {
            changeGroupBoxVisibility(true);
        }

        private void prevModeBtn_Click(object sender, RoutedEventArgs e)
        {
            changeGroupBoxVisibility(false);
        }
        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            GraphImage.Source = ImageDrawer.DrawImage();
        }

        /// <summary>
        /// Change visibility of groupBoxes
        /// </summary>
        /// <param name="direction">true->next false->previous</param>
        private void changeGroupBoxVisibility(bool direction) 
        {
            int index = groupBoxes.FindIndex(box => box.Visibility == Visibility.Visible);
            groupBoxes[index].Visibility = Visibility.Hidden;

            if (direction)
                if (index == groupBoxes.Count - 1)
                    groupBoxes[0].Visibility = Visibility.Visible;
                else
                    groupBoxes[index + 1].Visibility = Visibility.Visible;
            else 
                if (index == 0)
                    groupBoxes[groupBoxes.Count - 1].Visibility = Visibility.Visible;
                else
                    groupBoxes[index - 1].Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Fill list of GroupBoxes with reference to existing GroupBoxes
        /// </summary>
        private void InitializeGroupBoxList() 
        {
            foreach (FrameworkElement item in View.Children)
                if (!string.IsNullOrEmpty(item.Name))
                    if (item.Name.Contains("GroupBox"))
                        groupBoxes.Add((GroupBox)item);
        }

        private Graph createSampleGraph() 
        {
            Graph graph = new Graph();

            graph.AddVertice(10,10,1);
            graph.AddVertice(0,10,2);
            graph.AddVertice(10,0,3);
            graph.AddVertice(0,0,4);
            graph.AddVertice(5,5,5);

            graph.GetVertice(0).ConnectTo(graph.GetVertice(1));
            graph.GetVertice(1).ConnectTo(graph.GetVertice(2));
            graph.GetVertice(2).ConnectTo(graph.GetVertice(3));
            graph.GetVertice(3).ConnectTo(graph.GetVertice(4));
            graph.GetVertice(4).ConnectTo(graph.GetVertice(1));
            graph.GetVertice(3).ConnectTo(graph.GetVertice(1));
            graph.GetVertice(2).ConnectTo(graph.GetVertice(4));

            graph.RefreshEdges();

            return graph;
        }
    }
}
