using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridExample
{
    public class Grid
    {
        private Point[] _points;

        public Grid(int width, int height)
        {
            this.Width = width; // 10
            this.Height = height; // 10

            this._points = new Point[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    this._points[y*width + x] = new Point(x+1, y+1);
                }
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        
        public int? TryGetXyIdx(Point point)
        {
            return TryGetXyIdx(point.X, point.Y);
        }

        public int? TryGetXyIdx(int x, int y)
        {
            x--;
            y--;
            if (x < 0 || x > Width-1 || y < 0 || y > Height-1)
            {
                return null;
            }

            return y * this.Width + x;
        }

        public Point? TryGetPoint(int idx)
        {
            if (idx < 0 || idx > (Width * Height) - 1)
            {
                return null;
            }

            return _points[idx];
        }
    }
}
