// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCProgrssBar"
    public class SLCProgrssBar : Control
    {

        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();
            }
        }

        private void Increment(int amount)
        {
            Value += amount;
        }

        public SLCProgrssBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);


            P2 = new Pen(Color.FromArgb(55, 55, 55));
            B1 = new SolidBrush(Color.FromArgb(0, 214, 37));
        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;

        private GraphicsPath GP3;
        private Rectangle R1;

        private Rectangle R2;
        private Pen P2;
        private SolidBrush B1;
        private LinearGradientBrush GB1;

        private LinearGradientBrush GB2;

        private int I1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle R3 = new Rectangle();
            HatchBrush HB = default(HatchBrush);

            G.Clear(Color.White);
            G.SmoothingMode = SmoothingMode.HighQuality;

            GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4);
            GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 4);

            R1 = new Rectangle(0, 2, Width - 1, Height - 1);
            GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90f);





            G.SetClip(GP1);
            //gloss
            PathGradientBrush PB = new PathGradientBrush(GP1);
            PB.CenterColor = Color.FromArgb(230, 230, 230);
            PB.SurroundColors = new Color[] { Color.FromArgb(255, 255, 255) };
            PB.CenterPoint = new Point(0, Height);
            PB.FocusScales = new PointF(1, 0);

            G.FillRectangle(PB, R1);

            G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), RoundRec(new Rectangle(1, 1, Width - 3, Height / 2 - 2), 4));

            I1 = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 3));


            if (I1 > 1)
            {




                GP3 = RoundRec(new Rectangle(1, 1, I1, Height - 3), 4);

                //grad
                HB = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(50, Color.Black), Color.Transparent);



                //bar
                R2 = new Rectangle(1, 1, I1, Height - 3);
                GB2 = new LinearGradientBrush(R2, Color.FromArgb(20, 34, 45), Color.FromArgb(27, 84, 121), 90f);

                G.FillPath(GB2, GP3);
                G.DrawPath(new Pen(Color.FromArgb(120, 134, 145)), GP3);

                G.SetClip(GP3);
                G.SmoothingMode = SmoothingMode.None;



                G.FillRectangle(new SolidBrush(Color.FromArgb(32, 100, 144)), R2.X, R2.Y + 1, R2.Width, R2.Height / 2);

                R3 = new Rectangle(1, 1, I1, Height - 1);

                G.FillRectangle(HB, R3);

                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.ResetClip();
            }



            G.DrawPath(new Pen(Color.FromArgb(125, 125, 125)), GP2);
            G.DrawPath(new Pen(Color.FromArgb(80, Color.LightGray)), GP1);
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

