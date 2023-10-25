using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;


namespace ChoreographySimulator
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Element> elements = new List<Element> { };
        public static bool simulationState;
        public static void SetSimulationState(bool newState) { simulationState = newState; }

        public MainWindow()
        {
            InitializeComponent();

            int rowNumToAdd = 56;
            int colNumToAdd = 103;

            int numRows = gridBallroom.RowDefinitions.Count;
            int numColumns = gridBallroom.ColumnDefinitions.Count;

            GridHandler.AddRows(gridBallroom, rowNumToAdd);
            GridHandler.AddColumns(gridBallroom, colNumToAdd);

            int numRowsAfterAdd = gridBallroom.RowDefinitions.Count;
            int numColumns1AfterAdd = gridBallroom.ColumnDefinitions.Count;

            //debug.Text = numRows.ToString() + " " + numColumns.ToString() + " " + numRowsAfterAdd.ToString() + " " + numColumns1AfterAdd;

            //TODO anzichè fare spawnX e spawnY mettere il new Point
            Element element1 = new Element(0, "fede", "LightBlue", 20, 20);
            GridHandler.AddElement(gridBallroom, element1);

            Move testMove1 = new Move(new Point(3, 4), new Point(3, 10), 1000);
            Move testMove2 = new Move(new Point(3, 10), new Point(10, 5), 1000);

            element1.AddMove(testMove1);
            element1.AddMove(testMove2);
            Debug.WriteLine(element1.MovesToString());
        }
        private void StartSimulation(Object sender, RoutedEventArgs e)
        {
            SetSimulationState(true);
            debug.Text = "start simulation";
        }
        private void StopSimulation(Object sender, RoutedEventArgs e)
        {
            SetSimulationState(false);
            debug.Text = "stop simulation";
        }
    }
}

