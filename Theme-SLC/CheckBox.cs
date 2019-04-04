// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCCheckbox"
    [DefaultEvent("CheckedChanged")]
    public class SLCCheckbox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public SLCCheckbox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P11 = new Pen(Color.LightGray);
            P22 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.Black, 2f);
            P4 = new Pen(Color.White, 2f);
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }

                Invalidate();
            }
        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P11;
        private Pen P22;
        private Pen P3;

        private Pen P4;

        private PathGradientBrush PB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = RoundRec(new Rectangle(0, 2, Height - 5, Height - 5), 1);
            GP2 = RoundRec(new Rectangle(1, 3, Height - 7, Height - 7), 1);

            GraphicsPath GPF = new GraphicsPath();
            GPF.AddPath(RoundRec(new Rectangle((int)(Height - 18.5), Height - 20, 14, 14), 2), true);
            PathGradientBrush PB3 = default(PathGradientBrush);
            PB3 = new PathGradientBrush(GPF);
            //  PB3.CenterPoint = New Point(Height - 18.5, Height - 21)
            PB3.CenterColor = Color.FromArgb(240, 240, 240);
            PB3.SurroundColors = new Color[] { Color.FromArgb(90, 90, 90) };
            PB3.FocusScales = new PointF(0.4f, 0.4f);

            HatchBrush hb = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(70, Color.FromArgb(15, 54, 80)), Color.Transparent);

            g.FillPath(PB3, GPF);
            g.FillPath(hb, GPF);


            g.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
            g.SetClip(GPF);
            g.FillEllipse(new SolidBrush(Color.FromArgb(70, Color.DarkGray)), new Rectangle(Height - 16, Height - 18, 6, 6));
            g.DrawPath(Pens.White, RoundRec(new Rectangle(5, 4, Height - 11, Height - 11), 2));
            g.ResetClip();




            if (_Checked)
            {
                //g.DrawLine(Pens.Red, New PointF(7, Height - 10), New PointF(Height - 10, 5))
                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(1, 75, 124)), 2), new Point(8, Height - 9), new Point(Height - 8, 6));


                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(1, 75, 124)), 2), 7, Height - 13, 8, Height - 10);


            }

            SZ1 = g.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);


            g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

    }

    #endregion

}

