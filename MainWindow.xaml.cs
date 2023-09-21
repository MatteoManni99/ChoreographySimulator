using System;
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

            int numRows1 = gridBallroom.RowDefinitions.Count;
            int numColumns1 = gridBallroom.ColumnDefinitions.Count;
            debug.Text = numRows.ToString() + " " + numColumns.ToString() + " " + numRows1.ToString() + " " + numColumns1;

            Element element1 = new Element(0, "fede", "LightBlue", 20, 20);
            GridHandler.AddElement(gridBallroom, element1);

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

        //getter and setter
        public int GetId() { return id; }
        public String GetName() { return name; }
        public String GetColor() { return color; }
        public int GetSpawnX() { return spawnX; }
        public int GetSpawnY() { return spawnY; }

        public void SetId(int id_) { id = id_; }
        public void SetName(String name_) { name = name_; }
        public void SetColor(String color_) { color = color_; }
        public void SetSpawnX(int spawnX_) { spawnX = spawnX_; }
        public void SetSpawnY(int spawnY_) { spawnY = spawnY_; }

    }
    public class Move
    {
        public int StartPointX { get; set; }
        public int EndPointY { get; set; }
        public int Time { get; set; }

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

