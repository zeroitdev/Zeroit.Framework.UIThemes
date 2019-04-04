// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="OnOffBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    [DefaultEvent("CheckedChanged")]
    public class NSOnOffBox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public NSOnOffBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(24, 24, 24));
            P3 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(24, 24, 24));
            B2 = new SolidBrush(Color.FromArgb(85, 85, 85));
            B3 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B4 = new SolidBrush(Color.FromArgb(51, 181, 229));
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
            ThemeModule theme = new ThemeModule();
            var G = theme.G;
            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = theme.CreateRound(1, 1, Width - 3, Height - 3, 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new Color[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            G.FillPath(PB1, GP1);
            G.DrawPath(P1, GP1);
            G.DrawPath(P2, GP2);

            R1 = new Rectangle(5, 0, Width - 10, Height + 2);
            R2 = new Rectangle(6, 1, Width - 10, Height + 2);

            R3 = new Rectangle(1, 1, (Width / 2) - 1, Height - 3);

            if (_Checked)
            {
                G.DrawString("On", Font, Brushes.Black, R2, SF1);
                G.DrawString("On", Font, Brushes.WhiteSmoke, R1, SF1);

                R3.X += (Width / 2) - 1;
            }
            else
            {
                G.DrawString("Off", Font, B1, R2, SF2);
                G.DrawString("Off", Font, B2, R1, SF2);
            }

            GP3 = theme.CreateRound(R3, 7);
            GP4 = theme.CreateRound(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2, 7);

            GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90f);

            G.FillPath(GB1, GP3);
            G.DrawPath(P2, GP3);
            G.DrawPath(P3, GP4);

            Offset = R3.X + (R3.Width / 2) - 3;

            for (int I = 0; I <= 1; I++)
            {
                if (_Checked)
                {
                    G.FillRectangle(B1, Offset + (I * 5), 7, 2, Height - 14);
                }
                else
                {
                    G.FillRectangle(B3, Offset + (I * 5), 7, 2, Height - 14);
                }

                G.SmoothingMode = SmoothingMode.None;

                if (_Checked)
                {
                    G.FillRectangle(B4, Offset + (I * 5), 7, 2, Height - 14);
                }
                else
                {
                    G.FillRectangle(B5, Offset + (I * 5), 7, 2, Height - 14);
                }

                G.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
            base.OnMouseDown(e);
        }

    }

}


