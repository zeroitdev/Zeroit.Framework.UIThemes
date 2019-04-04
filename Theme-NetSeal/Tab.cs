// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSTabControl : TabControl
    {

        public NSTabControl()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            SizeMode = TabSizeMode.Fixed;
            Alignment = TabAlignment.Left;
            ItemSize = new Size(28, 115);

            DrawMode = TabDrawMode.OwnerDrawFixed;

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(24, 24, 24));
            P3 = new Pen(Color.FromArgb(45, 45, 45), 2);

            B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
            B2 = new SolidBrush(Color.FromArgb(24, 24, 24));
            B3 = new SolidBrush(Color.FromArgb(51, 181, 229));
            B4 = new SolidBrush(Color.FromArgb(65, 65, 65));

            SF1 = new StringFormat();
            SF1.LineAlignment = StringAlignment.Center;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is TabPage)
            {
                e.Control.BackColor = Color.FromArgb(50, 50, 50);
            }

            base.OnControlAdded(e);
        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;

        private GraphicsPath GP4;
        private Rectangle R1;

        private Rectangle R2;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;

        private SolidBrush B4;

        private PathGradientBrush PB1;
        private TabPage TP1;

        private StringFormat SF1;
        private int Offset;

        private int ItemHeight;
        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(Color.FromArgb(50, 50, 50));
            G.SmoothingMode = SmoothingMode.AntiAlias;

            ItemHeight = ItemSize.Height + 2;

            GP1 = theme.CreateRound(0, 0, ItemHeight + 3, Height - 1, 7);
            GP2 = theme.CreateRound(1, 1, ItemHeight + 3, Height - 3, 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new Color[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.8f, 0.95f);

            G.FillPath(PB1, GP1);

            G.DrawPath(P1, GP1);
            G.DrawPath(P2, GP2);

            for (int I = 0; I <= TabCount - 1; I++)
            {
                R1 = GetTabRect(I);
                R1.Y += 2;
                R1.Height -= 3;
                R1.Width += 1;
                R1.X -= 1;

                TP1 = TabPages[I];
                Offset = 0;

                if (SelectedIndex == I)
                {
                    G.FillRectangle(B1, R1);

                    for (int J = 0; J <= 1; J++)
                    {
                        G.FillRectangle(B2, R1.X + 5 + (J * 5), R1.Y + 6, 2, R1.Height - 9);

                        G.SmoothingMode = SmoothingMode.None;
                        G.FillRectangle(B3, R1.X + 5 + (J * 5), R1.Y + 5, 2, R1.Height - 9);
                        G.SmoothingMode = SmoothingMode.AntiAlias;

                        Offset += 5;
                    }

                    G.DrawRectangle(P3, R1.X + 1, R1.Y - 1, R1.Width, R1.Height + 2);
                    G.DrawRectangle(P1, R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2);
                    G.DrawRectangle(P2, R1);
                }
                else
                {
                    for (int J = 0; J <= 1; J++)
                    {
                        G.FillRectangle(B2, R1.X + 5 + (J * 5), R1.Y + 6, 2, R1.Height - 9);

                        G.SmoothingMode = SmoothingMode.None;
                        G.FillRectangle(B4, R1.X + 5 + (J * 5), R1.Y + 5, 2, R1.Height - 9);
                        G.SmoothingMode = SmoothingMode.AntiAlias;

                        Offset += 5;
                    }
                }

                R1.X += 5 + Offset;

                R2 = R1;
                R2.Y += 1;
                R2.X += 1;

                G.DrawString(TP1.Text, Font, Brushes.Black, R2, SF1);
                G.DrawString(TP1.Text, Font, Brushes.WhiteSmoke, R1, SF1);
            }

            GP3 = theme.CreateRound(ItemHeight, 0, Width - ItemHeight - 1, Height - 1, 7);
            GP4 = theme.CreateRound(ItemHeight + 1, 1, Width - ItemHeight - 3, Height - 3, 7);

            G.DrawPath(P2, GP3);
            G.DrawPath(P1, GP4);
        }

    }

}


