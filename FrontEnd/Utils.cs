using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChoreographySimulator
{
    public class Utils
    {
        public static void SetColorBrush(TextBox textBox, String color)
        {
            if (color.Equals("Coral")) textBox.Background = Brushes.Coral;
            else if (color.Equals("LightBlue")) textBox.Background = Brushes.LightBlue;
        }
    }
}
