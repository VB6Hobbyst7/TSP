using System;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;

namespace WindowsTSP
{
    public class PaintManagement
    {
        private Random rand;
        public Dictionary<int, Brush> MyBrushes;
        public Dictionary<int, Pen> MyPens;
        public Pen MyPen;
        public SolidBrush MyBrush;
        public Color CanvasColor;

        public PaintManagement()
        {
            MyPen = new Pen(Color.White);
            MyBrush = new SolidBrush(Color.White);
            CanvasColor = Color.Black;
        }

        public void GenerateColors(int numColors, bool randColors = false)
        {
            MyBrushes = new Dictionary<int, Brush>();
            MyPens = new Dictionary<int, Pen>();

            if (randColors)
            {
                rand = new Random(369);
                for (int i = 0; i < numColors; ++i)
                {
                    MyBrushes[i] = PickBrush();
                    MyPens[i] = new Pen(MyBrushes[i]);
                }
            }
            else
            {
                int temp;
                for (int i = 0; i < numColors; ++i)
                {
                    temp = i % 5;
                    if (temp == 0) { MyBrushes[i] = Brushes.Red; }
                    else if (temp == 1) { MyBrushes[i] = Brushes.Green; }
                    else if (temp == 2) { MyBrushes[i] = Brushes.Blue; }
                    else if (temp == 3) { MyBrushes[i] = Brushes.Yellow; }
                    else if (temp == 4) { MyBrushes[i] = Brushes.Violet; }
                    MyPens[i] = new Pen(MyBrushes[i]);
                }
            }

        }
        private Brush PickBrush() {
            //Brush result = Brushes.Transparent;

            //Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rand.Next(properties.Length);

            //result = (Brush)properties[id].GetValue(null, null);

            //return result;
            while (CanvasColor.Name == properties[random].Name)
            {
                random = rand.Next(properties.Length);
            }
            return (Brush)properties[random].GetValue(null, null);
        }
    }
}
