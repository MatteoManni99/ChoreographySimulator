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

            Element element1 = new Element(1, "test", "red", 20, 20);
            
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

        public Element (int id_, String name_, String color_, int spawnX_, int spawnY_)
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

    }
    public class Move
    {
        public int StartPointX { get; set; }
        public int EndPointY { get; set; }
        public int Time { get; set; }

    }

}
