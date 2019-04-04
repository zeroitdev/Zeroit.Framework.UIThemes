// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RandomPool.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Text;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    [DefaultEvent("ValueChanged")]
    public class NSRandomPool : Control
    {

        public event ValueChangedEventHandler ValueChanged;
        public delegate void ValueChangedEventHandler(object sender);

        private StringBuilder _Value = new StringBuilder();
        public string Value
        {
            get { return _Value.ToString(); }
        }

        private string _FullValue;
        public string FullValue
        {
            get { return BitConverter.ToString(Table).Replace("-", ""); }
        }


        private Random RNG = new Random();
        private int ItemSize = 9;

        private int DrawSize = 8;

        private Rectangle WA;
        private int RowSize;

        private int ColumnSize;
        public NSRandomPool()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(24, 24, 24));

            B1 = new SolidBrush(Color.FromArgb(30, 30, 30));
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            UpdateTable();
            base.OnHandleCreated(e);
        }

        private byte[] Table;
        private void UpdateTable()
        {
            WA = new Rectangle(5, 5, Width - 10, Height - 10);

            RowSize = WA.Width / ItemSize;
            ColumnSize = WA.Height / ItemSize;

            WA.Width = RowSize * ItemSize;
            WA.Height = ColumnSize * ItemSize;

            WA.X = (Width / 2) - (WA.Width / 2);
            WA.Y = (Height / 2) - (WA.Height / 2);

            Table = new byte[(RowSize * ColumnSize)];

            for (int I = 0; I <= Table.Length - 1; I++)
            {
                Table[I] = Convert.ToByte(RNG.Next(100));
            }

            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateTable();
        }

        private int Index1 = -1;

        private int Index2;

        private bool InvertColors;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            HandleDraw(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            HandleDraw(e);
            base.OnMouseDown(e);
        }

        private void HandleDraw(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (!WA.Contains(e.Location))
                    return;

                InvertColors = (e.Button == MouseButtons.Right);

                Index1 = GetIndex(e.X, e.Y);
                if (Index1 == Index2)
                    return;

                bool L = !(Index1 % RowSize == 0);
                bool R = !(Index1 % RowSize == (RowSize - 1));

                Randomize(Index1 - RowSize);
                if (L)
                    Randomize(Index1 - 1);
                Randomize(Index1);
                if (R)
                    Randomize(Index1 + 1);
                Randomize(Index1 + RowSize);

                _Value.Append(Table[Index1].ToString("X"));
                if (_Value.Length > 32)
                    _Value.Remove(0, 2);

                if (ValueChanged != null)
                {
                    ValueChanged(this);
                }

                Index2 = Index1;
                Invalidate();
            }
        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private Pen P1;
        private Pen P2;
        private SolidBrush B1;

        private SolidBrush B2;

        private PathGradientBrush PB1;
        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = theme.CreateRound(1, 1, Width - 3, Height - 3, 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new Color[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.9f, 0.5f);

            G.FillPath(PB1, GP1);

            G.DrawPath(P1, GP1);
            G.DrawPath(P2, GP2);

            G.SmoothingMode = SmoothingMode.None;

            for (int I = 0; I <= Table.Length - 1; I++)
            {
                int C = Math.Max((int)Table[I], (int)75);

                int X = ((I % RowSize) * ItemSize) + WA.X;
                int Y = ((I / RowSize) * ItemSize) + WA.Y;

                B2 = new SolidBrush(Color.FromArgb(C, C, C));

                G.FillRectangle(B1, X + 1, Y + 1, DrawSize, DrawSize);
                G.FillRectangle(B2, X, Y, DrawSize, DrawSize);

                B2.Dispose();
            }

        }

        private int GetIndex(int x, int y)
        {
            return (((y - WA.Y) / ItemSize) * RowSize) + ((x - WA.X) / ItemSize);
        }

        private void Randomize(int index)
        {
            if (index > -1 && index < Table.Length)
            {
                if (InvertColors)
                {
                    Table[index] = Convert.ToByte(RNG.Next(100));
                }
                else
                {
                    Table[index] = Convert.ToByte(RNG.Next(100, 256));
                }
            }
        }

    }

}


