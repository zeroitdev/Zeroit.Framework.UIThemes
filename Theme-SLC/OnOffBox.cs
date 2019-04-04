// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="OnOffBox.cs" company="Zeroit Dev Technologies">
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
    #region "SLCOnOffBox"
    [DefaultEvent("CheckedChanged")]
    public class SLCOnOffBox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);


        protected MouseState State;

        public SLCOnOffBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(35, 35, 35));
            B2 = new SolidBrush(Color.FromArgb(85, 85, 85));
            B3 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B4 = new SolidBrush(Color.FromArgb(205, 150, 0));
            B5 = new SolidBrush(Color.FromArgb(40, 40, 40));

            SF1 = new StringFormat();
            SF1.LineAlignment = StringAlignment.Center;
            SF1.Alignment = StringAlignment.Near;

            SF2 = new StringFormat();
            SF2.LineAlignment = StringAlignment.Center;
            SF2.Alignment = StringAlignment.Far;

            Size = new Size(56, 24);
            MinimumSize = Size;
            MaximumSize = Size;
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
        private GraphicsPath GP3;

        private GraphicsPath GP4;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private SolidBrush B4;

        private SolidBrush B5;
        private PathGradientBrush PB1;

        private LinearGradientBrush GB1;
        private Rectangle R1;
        private Rectangle R2;
        private Rectangle R3;
        private StringFormat SF1;

        private StringFormat SF2;

        private int Offset;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.Clear(Color.White);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 7);
            GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(250, 250, 250);
            PB1.SurroundColors = new Color[] { Color.FromArgb(245, 245, 245) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            G.FillPath(PB1, GP1);
            G.DrawPath(Pens.LightGray, GP1);
            G.DrawPath(Pens.White, GP2);

            R1 = new Rectangle(5, 0, Width - 10, Height + 2);
            R2 = new Rectangle(6, 1, Width - 10, Height + 2);

            R3 = new Rectangle(1, 1, (Width / 2) - 1, Height - 3);



            if (_Checked)
            {
                // G.DrawString("On", Font, Brushes.Black, R2, SF1)
                G.DrawString("On", Font, new SolidBrush(Color.FromArgb(1, 75, 124)), R1, SF1);

                R3.X += (Width / 2) - 1;
            }
            else
            {
                //G.DrawString("Off", Font, B1, R2, SF2)
                G.DrawString("Off", Font, new SolidBrush(Color.FromArgb(1, 75, 124)), R1, SF2);
            }

            GP3 = RoundRec(R3, 7);
            GP4 = RoundRec(new Rectangle(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2), 7);

            GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 255, 255), Color.FromArgb(245, 245, 245), 90f);

            G.FillPath(GB1, GP3);
            G.DrawPath(Pens.LightGray, GP3);
            G.DrawPath(Pens.White, GP4);


            Offset = R3.X + (R3.Width / 2) - 3;

            for (int I = 0; I <= 1; I++)
            {
                if (_Checked)
                {
                    //G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
                }
                else
                {
                    // G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
                }

                G.SmoothingMode = SmoothingMode.None;


                if (_Checked)
                {
                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GraphicsPath GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(Width - 20, Height - 17, 10, 10));
                    PathGradientBrush PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point((int)(Height - 18.5), Height - 20);
                    PB3.CenterColor = Color.FromArgb(53, 152, 74);
                    PB3.SurroundColors = new Color[] { Color.FromArgb(86, 216, 114) };
                    PB3.FocusScales = new PointF(0.9f, 0.9f);


                    G.FillPath(PB3, GPF);

                    G.DrawPath(new Pen(Color.FromArgb(85, 200, 109)), GPF);
                    G.SetClip(GPF);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                    G.ResetClip();


                    //  G.FillRectangle(New SolidBrush(Color.FromArgb(85, 158, 203)), Offset + (I * 5), 7, 2, Height - 14)
                }
                else
                {
                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GraphicsPath GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(Height - 15, Height - 17, 10, 10));
                    PathGradientBrush PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point((int)(Height - 18.5), Height - 20);
                    PB3.CenterColor = Color.FromArgb(185, 65, 65);
                    PB3.SurroundColors = new Color[] { Color.Red };
                    PB3.FocusScales = new PointF(0.9f, 0.9f);


                    G.FillPath(PB3, GPF);

                    G.DrawPath(new Pen(Color.FromArgb(152, 53, 53)), GPF);
                    G.SetClip(GPF);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Height - 16, Height - 18, 6, 6));
                    G.ResetClip();



                    //  G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
                }

                G.SmoothingMode = SmoothingMode.AntiAlias;
            }
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
            base.OnMouseDown(e);
        }

    }
    #endregion

}

