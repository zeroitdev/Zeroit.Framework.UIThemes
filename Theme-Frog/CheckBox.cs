// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Frog
{

    public class FrogCheckbox : ThemeControl154
    {
        private bool _Checked;

        private int X;
        protected override void ColorHook()
        {
            SetColor("Border", Color.FromArgb(255, 200, 200, 200));
        }

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            _Checked = !_Checked;
        }

        public FrogCheckbox()
        {
            this.BackColor = BackColor;
            this.Height = 18;
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 20 + textSize;
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(255, 60, 60, 60));
            Color Border = Color.FromArgb(160, GetColor("Border"));
            LinearGradientBrush LGBNone = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 50, 50, 50));
            LinearGradientBrush LGBOver = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 40, 40, 40));
            LinearGradientBrush LGBDown = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 30, 30, 30));
            Point[] Polygon = null;
            Point[] Polygon2 = null;
            Polygon = new Point[] {
            new Point(0, 0),
            new Point(18 - 1, 0),
            new Point(18 - 1, 18 - 7),
            new Point(18 - 2, 18 - 6),
            new Point(18 - 3, 18 - 5),
            new Point(18 - 4, 18 - 4),
            new Point(18 - 5, 18 - 3),
            new Point(18 - 6, 18 - 2),
            new Point(18 - 7, 18 - 1),
            new Point(0, 18 - 1)
        };
            Polygon2 = new Point[] {
            new Point(1, 1),
            new Point(18 - 2, 1),
            new Point(18 - 2, 18 - 7),
            new Point(18 - 7, 18 - 2),
            new Point(1, 18 - 2)
        };
            switch (State)
            {
                case MouseState.Down:
                    G.FillPolygon(LGBDown, Polygon);
                    break;
                case MouseState.None:
                    G.FillPolygon(LGBNone, Polygon);
                    break;
                case MouseState.Over:
                    G.FillPolygon(LGBOver, Polygon);
                    break;
            }
            G.DrawPolygon(Pens.Black, Polygon);
            G.DrawPolygon(new Pen(Border), Polygon2);
            if ((Checked == true))
            {
                G.DrawString("a", new Font("Webdings", 13), new SolidBrush(GetColor("Border")), new Point(-2, -2));
            }
            G.DrawString(Text, Font, new SolidBrush(GetColor("Border")), 20, 2);
        }
    }


}

