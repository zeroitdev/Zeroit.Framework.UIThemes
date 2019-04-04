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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GameBooster
{
    [DefaultEvent("CheckedChanged")]

    public class GameBoosterCheckBox : ThemeControl154
    {

        public GameBoosterCheckBox()
        {
            LockHeight = 17;
            Width = 160;
        }

        private int X;
        private Color TextColor;
        private Color G1;
        private Color G2;

        private Color Edge;
        protected override void ColorHook()
        {
            TextColor = Color.White;
            G1 = Color.FromArgb(65, 65, 65);
            G2 = Color.FromArgb(122, 122, 122);
            Edge = Color.Black;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(51, 51, 51));
            if (_Checked)
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 16)), G1, G2, 90f);
                DrawGradient(Color.Black, Color.FromArgb(100, 100, 100), new Rectangle(2, 2, Height - 7, Height - 7), 45f);
                G.DrawRectangle(new Pen(Color.FromArgb(102, 102, 102)), 1, 1, Height - 5, Height - 5);
                G.FillRectangle(LGB, new Rectangle(new Point(3, 3), new Size(Height - 8, Height - 8)));
                DrawPixel(Color.FromArgb(42, 42, 42), 2, Height - 5);
                DrawPixel(Color.FromArgb(42, 42, 42), Height - 5, 2);
                DrawPixel(Color.FromArgb(42, 42, 42), 2, 2);
            }
            else
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 16)), G1, G2, 90f);
                DrawGradient(Color.Black, Color.FromArgb(101, 101, 101), new Rectangle(2, 2, Height - 7, Height - 7), 45f);
                G.DrawRectangle(new Pen(Color.FromArgb(102, 102, 102)), 1, 1, Height - 5, Height - 5);
                G.FillRectangle(LGB, new Rectangle(new Point(3, 3), new Size(Height - 8, Height - 8)));
                DrawPixel(Color.FromArgb(42, 42, 42), 2, Height - 5);
                DrawPixel(Color.FromArgb(42, 42, 42), Height - 5, 2);
                DrawPixel(Color.FromArgb(42, 42, 42), 2, 2);
            }

            if (State == MouseState.Over & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(70, Color.White));
                G.FillRectangle(SB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }
            else if (State == MouseState.Down & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(10, Color.Black));
                G.FillRectangle(SB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }

            HatchBrush HB = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(7, Color.Black), Color.Transparent);
            G.FillRectangle(HB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            G.DrawRectangle(new Pen(Edge), new Rectangle(new Point(0, 0), new Size(14, 14)));

            if (_Checked)
                G.DrawString("a", new Font("Marlett", 12), new SolidBrush(Color.FromArgb(214, 214, 214)), new Point(-3, -1));
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


