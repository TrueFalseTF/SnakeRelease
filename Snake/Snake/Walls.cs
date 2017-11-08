using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls (int mapWight, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontalLine hLineTop = new HorizontalLine(0, mapWight - 2, 0, '+');
            HorizontalLine hLineBottom = new HorizontalLine(0, mapWight - 2, mapHeight - 1, '+');
            VerticalLine vLineLeft = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine vLineRight = new VerticalLine(0, mapHeight - 1, mapWight - 2, '+');

            wallList.Add(hLineTop);
            wallList.Add(hLineBottom);
            wallList.Add(vLineLeft);
            wallList.Add(vLineRight);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach(var walls in wallList)
            {
                walls.Drow();
            }
        }
    }
}
