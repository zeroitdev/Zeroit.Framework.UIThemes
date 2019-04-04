// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCGroupBox"
    public class SLCGroupBox : ContainerControl
    {

        private bool _DrawSeperator;
        public bool DrawSeperator
        {
            get { return _DrawSeperator; }
            set
            {
                _DrawSeperator = value;
                Invalidate();
            }
        }

        private string _Title = "GroupBox";
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                Invalidate();
            }
        }

        private string _SubTitle = "Details";
        public string SubTitle
        {
            get { return _SubTitle; }
            set
            {
                _SubTitle = value;
                Invalidate();
            }
        }

        private Font _TitleFont;

        private Font _SubTitleFont;
        public SLCGroupBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            _TitleFont = new Font("Verdana", 10f);
            _SubTitleFont = new Font("Verdana", 6.5f);


        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private PointF PT1;
        private SizeF SZ1;

        private SizeF SZ2;



        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G = e.Graphics;


            G.Clear(Color.White);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 7);
            GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 7);


            G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), GP2);
            G.SetClip(GP2);
            PathGradientBrush PB = new PathGradientBrush(GP2);
            PB.CenterColor = Color.FromArgb(255, 255, 255);
            PB.SurroundColors = new Color[] { Color.FromArgb(250, 250, 250) };
            PB.FocusScales = new PointF(0.95f, 0.95f);
            G.FillPath(PB, GP2);
            G.ResetClip();

            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(70, Color.LightGray))), GP1);
            G.DrawPath(Pens.Gray, GP2);

            SZ1 = G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic);
            SZ2 = G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic);


            G.DrawString(_Title, _TitleFont, new SolidBrush(Color.FromArgb(1, 75, 124)), 5, 5);

            PT1 = new PointF(6f, SZ1.Height + 4f);


            G.DrawString(_SubTitle, _SubTitleFont, new SolidBrush(Color.Black), PT1.X, PT1.Y);


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

