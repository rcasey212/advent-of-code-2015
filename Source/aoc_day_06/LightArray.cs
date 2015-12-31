using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_day_06
{
    public class LightArray
    {
        private const int ORIGIN_X = 0;
        private const int ORIGIN_Y = 0;

        private int m_width = 0;
        private int m_height = 0;
        private bool[,] m_lightArray = null;

        public LightArray(int width, int height)
        {
            // The default values of numeric array elements are set to zero
            m_width = width;
            m_height = height;
            m_lightArray = new bool[width, height];
        }

        public void TurnOnPoint(Point p)
        {
            m_lightArray[p.X, p.Y] = true;
        }
        public void TurnOffPoint(Point p)
        {
            m_lightArray[p.X, p.Y] = false;
        }

        public void TurnOnAllLights()
        {
            int maxX = m_width - 1 - ORIGIN_X;
            int maxY = m_height - 1 - ORIGIN_Y;

            for (int y = ORIGIN_Y; y <= maxY; y++)
            {
                for (int x = ORIGIN_X; x <= maxX; x++)
                {
                    TurnOnPoint(new Point(x, y));
                }
            }
        }

        public void TurnOffAllLights()
        {
            int maxX = m_width - 1 - ORIGIN_X;
            int maxY = m_height - 1 - ORIGIN_Y;

            for (int y = ORIGIN_Y; y <= maxY; y++)
            {
                for (int x = ORIGIN_X; x <= maxX; x++)
                {
                    TurnOffPoint(new Point(x, y));
                }
            }
        }

        public void TogglePoint(Point p)
        {
            bool currValue = m_lightArray[p.X, p.Y];
            m_lightArray[p.X, p.Y] = !currValue;
        }

        public void TurnOnRectangle(Point startPoint, Point endPoint)
        {
            for (int y = startPoint.Y; y <= endPoint.Y; y++)
            {
                for (int x = startPoint.X; x <= endPoint.X; x++)
                {
                    TurnOnPoint(new Point(x, y));
                }
            }
        }

        public void TurnOffRectangle(Point startPoint, Point endPoint)
        {
            for (int y = startPoint.Y; y <= endPoint.Y; y++)
            {
                for (int x = startPoint.X; x <= endPoint.X; x++)
                {
                    TurnOffPoint(new Point(x, y));
                }
            }
        }

        public void ToggleRectangle(Point startPoint, Point endPoint)
        {
            for (int y = startPoint.Y; y <= endPoint.Y; y++)
            {
                for (int x = startPoint.X; x <= endPoint.X; x++)
                {
                    TogglePoint(new Point(x, y));
                }
            }
        }

        public void TurnOnRange(Point startPoint, Point endPoint)
        {
            // Set the first row
            for (int x = startPoint.X; x < m_width; x++)
            {
                TurnOnPoint(new Point(x, startPoint.Y));
            }
            
            // Set rows between the first and last
            for (int y = startPoint.Y; y < endPoint.Y; y++)
            {
                for (int x2 = ORIGIN_X; x2 <= m_width; x2++)
                {
                    TurnOnPoint(new Point(x2, y));
                }
            }

            // Set the last row
            for (int x3 = ORIGIN_X; x3 <= endPoint.X; x3++)
            {
                TurnOnPoint(new Point(x3, endPoint.Y));
            }
        }

        public void TurnOffRange(Point startPoint, Point endPoint)
        {
            // Set the first row
            for (int x = startPoint.X; x < m_width; x++)
            {
                TurnOffPoint(new Point(x, startPoint.Y));
            }

            // Set rows between the first and last
            for (int y = startPoint.Y; y < endPoint.Y; y++)
            {
                for (int x2 = ORIGIN_X; x2 <= m_width; x2++)
                {
                    TurnOffPoint(new Point(x2, y));
                }
            }

            // Set the last row
            for (int x3 = ORIGIN_X; x3 <= endPoint.X; x3++)
            {
                TurnOffPoint(new Point(x3, endPoint.Y));
            }
        }

        public void ToggleRange(Point startPoint, Point endPoint)
        {
            // Set the first row
            for (int x = startPoint.X; x < m_width; x++)
            {
                TogglePoint(new Point(x, startPoint.Y));
            }

            // Set rows between the first and last
            for (int y = startPoint.Y; y < endPoint.Y; y++)
            {
                for (int x2 = ORIGIN_X; x2 <= m_width; x2++)
                {
                    TogglePoint(new Point(x2, y));
                }
            }

            // Set the last row
            for (int x3 = ORIGIN_X; x3 <= endPoint.X; x3++)
            {
                TogglePoint(new Point(x3, endPoint.Y));
            }
        }

        public int GetCountOfLightsInState(bool state)
        {
            int count = 0;

            foreach (bool isLightOn in m_lightArray)
            {
                if (isLightOn == state)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
