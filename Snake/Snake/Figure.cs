using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList;

        public void Drow()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
          
        internal bool IsHit (Figure figure)
        {
            foreach ( var p in pList)
            {
                if (figure.IsHit(p))
                {
                    return true;
                }                
            }
            return false;
        }

        internal bool IsHitSnake(Figure snake)
        {
            foreach (var p in pList)
            {
                if (snake.IsHitSnake(p))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool IsHit (Point point)
        {
            foreach ( var p in pList)
            {
                if (p.IsHit(point))
                {
                    return true;
                }                
            }
            return false;
        }

        internal bool IsHitSnake(Point point)
        {
            Point head = pList.Last();
            if (head.IsHit(point))
                {
                    return true;
                }
            
            return false;
        }
    }
}
