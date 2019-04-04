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
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Earn
{
    [DefaultEvent("CheckedChanged")]
    public class EarnCheckBox : ThemeControl154
    {

        public EarnCheckBox()
        {
            LockHeight = 14;
            SetColor("Text", 75, 77, 89);
            SetColor("Gradient 1", 240, 240, 240);
            SetColor("Gradient 2", 240, 240, 240);
            SetColor("Glow", 240, 240, 240);
            SetColor("Edges", 127, 128, 136);
            SetColor("Backcolor", BackColor);
            SetColor("Check", 75, 77, 89);
            Width = 160;
        }

        private int X;
        private Color TextColor;
        private Color G1;
        private Color G2;
        private Color Glow;
        private Color Edge;
        private Color BG;

        private Color Tick;
        protected override void ColorHook()
        {
            TextColor = GetColor("Text");
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            Glow = GetColor("Glow");
            Edge = GetColor("Edges");
            BG = GetColor("Backcolor");
            Tick = GetColor("Check");
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void PaintHook()
        {
            G.Clear(BG);
            if (_Checked)
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(12, 12)), G1, G2, 90f);
                G.FillRectangle(LGB, new Rectangle(new Point(0, 0), new Size(12, 12)));
                G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(12, 6)));
            }
            else
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(12, 12)), G1, G2, 90f);
                G.FillRectangle(LGB, new Rectangle(new Point(0, 0), new Size(12, 12)));
                G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(12, 6)));
            }

            G.DrawRectangle(new Pen(Edge), new Rectangle(new Point(0, 0), new Size(12, 12)));

            if (_Checked)
                G.DrawString("a", new Font("Marlett", 11), Brushes.Green, new Point(-3, -1));
            DrawText(new SolidBrush(Tick), HorizontalAlignment.Left, 19, -1);
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnMouseDown(e);
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

    }


}

