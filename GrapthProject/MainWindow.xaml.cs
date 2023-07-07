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
            GraphImage.Source = ImageDrawer.DrawSampleImage();
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
    }
}
