using System;

using System.Collections.Generic;

using System.Windows;

using static ChoreographySimulator.Element;

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

            Element element1 = new Element(0, "lorenzo", "LightBlue", 20, 20);
            GridHandler.AddElement(gridBallroom, element1);

            Move testMove = new Move(new Point(1, 1), new Point(16, 29), 1000);

            //ciclo di debug
            foreach (Point point in testMove.GetPath())
            {
                debug.Text += point.ToString() + "\n";
            }

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

