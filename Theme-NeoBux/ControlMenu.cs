// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlMenu.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.NeoBux
{
    public class clsControlMenu : ThemeControl154
    {
        private int X;
        Color BG;
        Color Edge;
        Pen BEdge;
        protected override void ColorHook()
        {
            BG = GetColor("Background");
            Edge = GetColor("Edge color");
            BEdge = new Pen(GetColor("Button edge color"));
        }

        public clsControlMenu()
        {
            SetColor("Background", Color.FromArgb(239, 239, 242));
            SetColor("Edge color", Color.Transparent);
            SetColor("Button edge color", Color.Transparent);
            this.Size = new Size(71, 19);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if (X <= 22)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (X > 22 & X <= 44)
            {
                if (Parent.FindForm().WindowState != FormWindowState.Maximized)
                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                else
                    Parent.FindForm().WindowState = FormWindowState.Normal;
            }
            else if (X > 44)
            {
                Parent.FindForm().Close();
            }
        }

        protected override void PaintHook()
        {
            //Draw outer edge
            G.Clear(Color.FromArgb(239, 239, 242));

            //Fill buttons
            //Dim SB As New LinearGradientBrush(New Rectangle(New Point(1, 1), New Size(Width - 2, Height - 2)), BG, Color.FromArgb(30, 30, 30), 90.0F)
            G.FillRectangle(new SolidBrush(Color.FromArgb(239, 239, 242)), new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));

            //Draw icons
            G.DrawString("0", new Font("Marlett", 8.25f), Brushes.Black, new Point(5, 5));
            if (Parent.FindForm().WindowState != FormWindowState.Maximized)
                G.DrawString("1", new Font("Marlett", 8.25f), Brushes.Black, new Point(27, 4));
            else
                G.DrawString("2", new Font("Marlett", 8.25f), Brushes.Black, new Point(27, 4));
            G.DrawString("r", new Font("Marlett", 10), Brushes.Black, new Point(49, 3));

            //Glassy effect
            //Dim CBlend As New ColorBlend(2)
            //CBlend.Colors = {Color.FromArgb(100, Color.Black), Color.Transparent}
            //CBlend.Positions = {0, 1}
            //DrawGradient(CBlend, New Rectangle(New Point(1, 8), New Size(68, 8)), 90.0F)

            //Draw button outlines
            G.DrawRectangle(BEdge, new Rectangle(new Point(1, 1), new Size(20, 16)));
            G.DrawRectangle(BEdge, new Rectangle(new Point(23, 1), new Size(20, 16)));
            G.DrawRectangle(BEdge, new Rectangle(new Point(45, 1), new Size(24, 16)));

            //Mouse states
            switch (State)
            {
                case MouseState.Over:
                    if (X <= 22)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), new Rectangle(new Point(1, 1), new Size(21, Height - 2)));
                    }
                    else if (X > 22 & X <= 44)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), new Rectangle(new Point(23, 1), new Size(21, Height - 2)));
                    }
                    else if (X > 44)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), new Rectangle(new Point(45, 1), new Size(25, Height - 2)));
                    }
                    break;
                case MouseState.Down:
                    if (X <= 22)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), new Rectangle(new Point(1, 1), new Size(21, Height - 2)));
                    }
                    else if (X > 22 & X <= 44)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), new Rectangle(new Point(23, 1), new Size(21, Height - 2)));
                    }
                    else if (X > 44)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), new Rectangle(new Point(45, 1), new Size(25, Height - 2)));
                    }
                    break;
            }
        }
    }


}

