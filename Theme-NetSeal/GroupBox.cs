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
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSGroupBox : ContainerControl
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
        public NSGroupBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            _TitleFont = new Font("Verdana", 10f);
            _SubTitleFont = new Font("Verdana", 6.5f);

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(55, 55, 55));

            B1 = new SolidBrush(Color.FromArgb(51, 181, 229));
        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private PointF PT1;
        private SizeF SZ1;

        private SizeF SZ2;
        private Pen P1;
        private Pen P2;

        private SolidBrush B1;
        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = theme.CreateRound(1, 1, Width - 3, Height - 3, 7);

            G.DrawPath(P1, GP1);
            G.DrawPath(P2, GP2);

            SZ1 = G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic);
            SZ2 = G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic);

            G.DrawString(_Title, _TitleFont, Brushes.Black, 6, 6);
            G.DrawString(_Title, _TitleFont, B1, 5, 5);

            PT1 = new PointF(6f, SZ1.Height + 4f);

            G.DrawString(_SubTitle, _SubTitleFont, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            G.DrawString(_SubTitle, _SubTitleFont, Brushes.WhiteSmoke, PT1.X, PT1.Y);

            if (_DrawSeperator)
            {
                int Y = Convert.ToInt32(PT1.Y + SZ2.Height) + 8;

                G.DrawLine(P1, 4, Y, Width - 5, Y);
                G.DrawLine(P2, 4, Y + 1, Width - 5, Y + 1);
            }
        }

    }

}


