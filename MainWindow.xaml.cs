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

namespace ChoreographySimulator
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double windowWidth;
        double windowHeight;

        public MainWindow()
        {
            InitializeComponent();

            //retrive 
            double windowWidth = this.Width;
            double windowHeight = this.Height;

            //<TextBox x:Name="myTextBox" PointerPressed="TextBox_PointerPressed" />
            int numRows = gridBallroom.RowDefinitions.Count;
            int numColumns = gridBallroom.ColumnDefinitions.Count;

            debug.Text = numRows.ToString() + " " + numColumns.ToString();
        }
    }
}
