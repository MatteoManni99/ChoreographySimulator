using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Xml.Linq;

namespace ChoreographySimulator
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Element> elements = new List<Element> { };


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
            debug.Text = numRows.ToString() + " " + numColumns.ToString() + " " + numRowsAfterAdd.ToString() + " " + numColumns1AfterAdd;

            Element element1 = new Element(0, "fede", "LightBlue", 20, 20);
            Move move1 = new Move(20, 20, 10, 10, 5);
            element1.AddMove(move1);
            GridHandler.AddElement(gridBallroom, element1);

        }
        private void StartSimulation(Object sender, RoutedEventArgs e)
        {
            ControlClass.SetSimulationState(true);
            debug.Text = "start simulation";

        }
        private void StopSimulation(Object sender, RoutedEventArgs e)
        {
            ControlClass.SetSimulationState(false);
            debug.Text = "stop simulation";
        }
    }

    public class GridHandler
    {
        public static void AddRows(Grid grid, int rowNum)
        {
            for (int index = 0; index < rowNum; index++) {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(10);
                grid.RowDefinitions.Add(row);
            }
        }

        public static void AddColumns(Grid grid, int colNum)
        {
            for (int index = 0; index < colNum; index++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(10);
                grid.ColumnDefinitions.Add(col);
            }
        }
        public static void AddElement(Grid grid, Element element)
        {
            TextBox textBox = new TextBox
            {
                Name = element.GetName(),
                Text = element.GetName(),
                TextAlignment = TextAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                IsReadOnly = true
            };

            Util.SetBrush(textBox, element.GetColor());

            grid.Children.Add(textBox);
            Grid.SetRowSpan(textBox, 3);
            Grid.SetColumnSpan(textBox, 3);
            Grid.SetRow(textBox, element.GetSpawnX());
            Grid.SetColumn(textBox, element.GetSpawnY());
        }
        public static void MoveElement(Grid grid, Element element)
        {

        }
    }

    public class Element
    {
        private int id;
        private String name;
        private String color;
        private int spawnX;
        private int spawnY;
        private List<Move> moves = new List<Move> { };

        public Element(int id_, String name_, String color_, int spawnX_, int spawnY_)
        {
            this.id = id_;
            this.name = name_;
            this.color = color_;
            this.spawnX = spawnX_;
            this.spawnY = spawnY_;
        }

        public void AddMove(Move move) { this.moves.Append(move); }
        public void RemoveLastMove() { this.moves.RemoveAt(this.moves.Count - 1); }
        public int GetCountMoves() { return this.moves.Count; }
        public Move GetMove(int index) { return moves[index]; }

        //getter
        public int GetId() { return id; }
        public String GetName() { return name; }
        public String GetColor() { return color; }
        public int GetSpawnX() { return spawnX; }
        public int GetSpawnY() { return spawnY; }

        //setter
        public void SetId(int id_) { id = id_; }
        public void SetName(String name_) { name = name_; }
        public void SetColor(String color_) { color = color_; }
        public void SetSpawnX(int spawnX_) { spawnX = spawnX_; }
        public void SetSpawnY(int spawnY_) { spawnY = spawnY_; }
    }
    public class Move
    {
        private Point start;
        private Point end;
        private int time;
        private List<Point> path = new List<Point> { };

        public Move(int startX, int startY, int endX, int endY, int time_)
        {
            start = new Point(startX, startY);
            end = new Point(endX, endY);
            time = time_;
        }
        public void EvaluateAndSetPath()
        {
            int distX = end.GetX() - start.GetX();
            int distY = end.GetY() - start.GetY();
            float squareRatio = (float)distX / distY;
            float decimalPart = squareRatio - (float)Math.Floor(squareRatio);

            //TODO rimpiazzare con uno switch

            if (distX == 0)     //the 2 points are in the same column
            {
                while (!end.IsEqualTo(path[path.Count - 1]))
                {

                }
            }
            else if (distY == 0)    //the 2 points are in the same row
            {
                while (!end.IsEqualTo(path[path.Count - 1]))
                {

                }
            }
            else if (distX == distY)    //we have to move on a square diagonal
            {
                while (!end.IsEqualTo(path[path.Count - 1]))
                {

                }
            }
            else if (decimalPart > 0.5)     //it's a vertical rectangle
            {
                while (!end.IsEqualTo(path[path.Count - 1]))
                {


                }
            }
            else if (decimalPart <= 0.5)    //it's a horizontal rectangle
            {
                while (!end.IsEqualTo(path[path.Count - 1]))
                {

                }
            }

        }
        //getter
        public Point GetStartPoint() { return start; }
        public Point GetEndPoint() { return end; }
        public int GetTime() { return time; }

    }

    public class Point
    {
        private int x;
        private int y;

        public Point(int x_, int y_)
        {
            x = x_;
            y = y_;
        }
        public int GetX() { return x; }
        public int GetY() { return y; }

        public bool IsEqualTo(Point anOtherPoint)
        {
            if (anOtherPoint.GetX() == this.x && anOtherPoint.GetY() == this.y) return true;
            else return false;
        }
    }

    public class ControlClass
    {
        private static bool simulationState;
        ControlClass() { }
        public static void SetSimulationState(bool simulationState_) { simulationState = simulationState_; }
        public static bool GetSimulationState() { return simulationState; }
    }
    public class Util
    {
        public static void SetBrush(TextBox textBox, String color)
        {
            if (color.Equals("Coral")) textBox.Background = Brushes.Coral;
            else if (color.Equals("LightBlue")) textBox.Background = Brushes.LightBlue;
        }
    }
}

