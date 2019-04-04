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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.XVisual
{

    public class xVisualTabControl : TabControl
    {

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
        }

        public xVisualTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(35, 122);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }
        TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
        Color.FromArgb(45, 41, 37),
        Color.FromArgb(47, 43, 39),
        Color.FromArgb(43, 39, 35)
    });
        TextureBrush TabBGTexture = Draw.NoiseBrush(new Color[]{
        Color.FromArgb(55, 51, 48),
        Color.FromArgb(57, 53, 50),
        Color.FromArgb(53, 49, 46)

    });
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Font FF = new Font("Arial", 9, FontStyle.Bold);

            try
            {
                SelectedTab.BackColor = Color.FromArgb(56, 52, 49);
            }
            catch
            {
            }
            G.Clear(Parent.FindForm().BackColor);

            G.FillRectangle(TabBGTexture, new Rectangle(0, 0, ItemSize.Height + 3, Height - 1));
            //Full Tab Background
            G.DrawLine(Draw.GetPen(Color.FromArgb(44, 42, 39)), 1, Height - 3, ItemSize.Height + 3, Height - 3);
            G.DrawLine(Draw.GetPen(Color.FromArgb(48, 45, 43)), 1, Height - 4, ItemSize.Height + 3, Height - 4);
            G.DrawLine(Draw.GetPen(Color.FromArgb(53, 50, 47)), 1, Height - 5, ItemSize.Height + 3, Height - 5);



            for (int i = 0; i <= TabCount - 1; i++)
            {
                int y = GetTabRect(i).Height * 2;
                while (!(y >= Height - 1))
                {
                    G.DrawLine(Pens.Black, 1, y, Width - 2, y);
                    G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, y + 1, Width - 2, y + 1);
                    y = y + GetTabRect(0).Height;
                }

                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));

                    if (SelectedIndex == 0)
                    {
                        Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 1, GetTabRect(i).Size.Width - 1, GetTabRect(i).Size.Height - 1);
                        LinearGradientBrush TabOverlay = new LinearGradientBrush(tabRect, Color.FromArgb(114, 203, 232), Color.FromArgb(58, 118, 188), 90);
                        G.FillRectangle(TabOverlay, tabRect);

                        G.DrawLine(Draw.GetPen(Color.FromArgb(235, 255, 255)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 1, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y - 1);
                    }
                    else
                    {
                        Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 2, GetTabRect(i).Size.Width - 1, GetTabRect(i).Size.Height);
                        LinearGradientBrush TabOverlay = new LinearGradientBrush(tabRect, Color.FromArgb(114, 203, 232), Color.FromArgb(58, 118, 188), 90);
                        G.FillRectangle(TabOverlay, tabRect);

                        G.DrawLine(Draw.GetPen(Color.FromArgb(235, 255, 255)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 2, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y - 2);
                    }

                    G.DrawLine(Pens.Black, GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 33, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 33);

                    G.SmoothingMode = SmoothingMode.HighQuality;

                    G.DrawString(TabPages[i].Text, FF, Draw.GetBrush(Color.FromArgb(20, 20, 20)), new Rectangle(x2.X, x2.Y - 1, x2.Width + 1, x2.Height + 2), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                    G.DrawString(TabPages[i].Text, FF, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });

                    G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Location.X - 1, x2.Location.Y - 1), new Point(x2.Location.X, x2.Location.Y));
                    G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Location.X - 1, x2.Bottom - 1), new Point(x2.Location.X, x2.Bottom));
                }
                else
                {
                    Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 2, GetTabRect(i).Size.Width - 1, GetTabRect(i).Size.Height - 1);

                    G.FillRectangle(InnerTexture, tabRect);
                    //Highlight Fill Background
                    LinearGradientBrush TabOverlay = new LinearGradientBrush(tabRect, Color.FromArgb(15, Color.White), Color.FromArgb(100, Color.FromArgb(43, 40, 38)), 90);
                    G.FillRectangle(TabOverlay, tabRect);

                    G.DrawLine(Draw.GetPen(Color.FromArgb(113, 110, 108)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 1, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y - 1);
                    G.DrawLine(Pens.Black, GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 32, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 32);

                    if (i == TabCount - 1)
                    {
                        G.DrawLine(Draw.GetPen(Color.FromArgb(64, 60, 57)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 31, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 31);
                        G.DrawLine(Draw.GetPen(Color.FromArgb(35, 33, 31)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 33, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 33);
                        G.DrawLine(Draw.GetPen(Color.FromArgb(43, 41, 38)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 34, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 34);
                        G.DrawLine(Draw.GetPen(Color.FromArgb(53, 50, 47)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 35, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 35);
                        G.DrawLine(Draw.GetPen(Color.FromArgb(58, 55, 51)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 36, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 36);
                    }

                    G.DrawString(TabPages[i].Text, FF, new SolidBrush(Color.FromArgb(210, 220, 230)), new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
                G.FillRectangle(new SolidBrush(Color.FromArgb(56, 52, 49)), new Rectangle(123, -1, Width - 123, Height + 1));
                //Page Fill Full

                G.DrawRectangle(Pens.Black, new Rectangle(123, 0, Width - 124, Height - 2));
                Color[] c = {
                Color.FromArgb(43, 40, 38),
                Color.FromArgb(50, 47, 44),
                Color.FromArgb(55, 52, 49)
            };
                Draw.InnerGlow(G, new Rectangle(124, 1, Width - 125, Height - 3), c);
            }

            G.DrawLine(Draw.GetPen(Color.FromArgb(56, 52, 49)), -1, Height - 1, ItemSize.Height + 1, Height - 1);
            G.DrawLine(Draw.GetPen(Color.FromArgb(56, 52, 49)), 0, -1, 0, Height - 1);
            G.DrawRectangle(new Pen(new SolidBrush(Color.Black)), new Rectangle(1, 0, ItemSize.Height, Height - 2));
            //Full Tab Inner Outline

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

