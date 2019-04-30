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

namespace qbert
{
    class Pyramid
    {
        private int[,] cubes = new int[7, 13];
        private Canvas _canvas;

        public Pyramid(Canvas c)
        {
            _canvas = c;
            for (int x = 0; x < cubes.GetLength(0); x++)
            {
                for (int y = 0; y < cubes.GetLength(1); y++)
                {
                    cubes[x, y] = 0;
                }
            }
            //MessageBox.Show(cubes.GetLength(0).ToString());
            //loop through each row
            for (int x = 0; x < cubes.GetLength(0); x++)
            {
                int numberOfCubes = x + 1;
                int midPoint = cubes.GetLength(1) / 2;
                int offset = 1;
                if (numberOfCubes % 2 == 1)
                {
                    cubes[x, midPoint] = 1;
                    offset = 2;
                }
                for (int i = 0; i < numberOfCubes / 2; i++)
                {
                    cubes[x, midPoint - offset] = 1;
                    cubes[x, midPoint + offset] = 1;
                    offset += 2;
                }

            }


            string output = "";

            for (int x = 0; x < cubes.GetLength(0); x++)
            {
                for (int y = 0; y < cubes.GetLength(1); y++)
                {
                    Console.Write(cubes[x, y]);
                    output += cubes[x, y].ToString();
                }
                Console.WriteLine();
                output += Environment.NewLine;
            }
           
            Clipboard.SetText(output);
        }

        public void draw()
        {
            _canvas.Children.RemoveRange(0, _canvas.Children.Count);
            _canvas.Background = Brushes.Black;

            //draw cubes:
            for (int x = 0; x < cubes.GetLength(0); x++)
            {
                for (int y = 0; y < cubes.GetLength(1); y++)
                {
                    if (cubes[x, y] == 1)
                    {
                        //draw a square
                        //replace later with cube code
                        Rectangle r = new Rectangle();
                        r.Fill = Brushes.Red;
                        r.Width = 25;
                        r.Height = 25;
                        _canvas.Children.Add(r);
                        Canvas.SetLeft(r, 25 * y);
                        Canvas.SetTop(r, 25 * x);
                    }
                    
                    
                }
                Console.WriteLine();
                
            }
        }
    }
}
