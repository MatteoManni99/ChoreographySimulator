using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ChoreographySimulator
{
    public class GridHandler
    {
        public static void AddRows(Grid grid, int rowNum)
        {
            for (int index = 0; index < rowNum; index++)
            {
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

            Utils.SetColorBrush(textBox, element.GetColor());

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
}
