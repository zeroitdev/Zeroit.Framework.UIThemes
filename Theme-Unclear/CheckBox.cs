// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.UClear
{
    [DefaultEvent("CheckedChanged")]
    public class UnClearCheckBox : ThemeControl154
    {

        public UnClearCheckBox()
        {
            LockHeight = 17;
            SetColor("Text", Color.Black);
            SetColor("Gradient 1", 230, 230, 230);
            SetColor("Gradient 2", 210, 210, 210);
            SetColor("Glow", 230, 230, 230);
            SetColor("Edges", 170, 170, 170);
            SetColor("Backcolor", 246, 246, 246);
            Width = 160;
        }

        private int X;
        private Color TextColor;
        private Color G1;
        private Color G2;
        private Color Glow;
        private Color Edge;

        private Color BG;
        protected override void ColorHook()
        {
            TextColor = GetColor("Text");
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            Glow = GetColor("Glow");
            Edge = GetColor("Edges");
            BG = Color.FromArgb(246, 246, 246);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(246, 246, 246));
            if (_Checked)
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(9, 9)), G1, G2, 90f);
                G.FillRectangle(LGB, new Rectangle(new Point(0, 0), new Size(9, 9)));
                G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(9, 4)));
            }
            else
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(9, 3)), G1, G2, 90f);
                G.FillRectangle(LGB, new Rectangle(new Point(0, 0), new Size(9, 9)));
                G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(9, 4)));
            }

            if (State == MouseState.Over & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(70, Color.White));
                G.FillRectangle(SB, new Rectangle(new Point(0, 0), new Size(9, 9)));
            }
            else if (State == MouseState.Down & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(10, Color.Black));
                G.FillRectangle(SB, new Rectangle(new Point(0, 0), new Size(9, 9)));
            }

            HatchBrush HB = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(7, Color.Black), Color.Transparent);
            G.FillRectangle(HB, new Rectangle(new Point(0, 0), new Size(9, 9)));
            G.DrawRectangle(new Pen(Edge), new Rectangle(new Point(0, 0), new Size(9, 9)));

            if (_Checked)
                G.DrawString("g", new Font("Marlett", 6), Brushes.Black, new Point(-0, 1));
            DrawText(new SolidBrush(TextColor), HorizontalAlignment.Left, 19, -1);
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


