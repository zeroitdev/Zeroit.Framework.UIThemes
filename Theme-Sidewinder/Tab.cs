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
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sidewinder
{
    public class SideWinderTab : TabControl
    {

        #region " Helpers "



        #endregion

        #region " Drawing "
        private Graphics G;
        private Rectangle Rect;
        private int LastIndex;

        private Color BackgroundC = Color.FromArgb(102, 105, 112);
        private int _Index = -1;
        private int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
                Invalidate();
            }
        }

        public SideWinderTab()
        {
            DoubleBuffered = true;
            ItemSize = new Size(40, 170);
            Alignment = TabAlignment.Left;
            SizeMode = TabSizeMode.Fixed;
            Dock = DockStyle.Fill;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.BackColor = Color.White;
            e.Control.ForeColor = Color.FromArgb(72, 75, 82);
            e.Control.Font = new Font("Segoe UI", 10);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Color.FromArgb(72, 75, 82));


            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                Rect = GetTabRect(i);


                if (string.IsNullOrEmpty((string)TabPages[i].Tag))
                {

                    if (SelectedIndex == i)
                    {
                        //Fill selected
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(90, 93, 100)))
                        {
                            G.FillRectangle(B, new Rectangle(Rect.X, Rect.Y + 2, Rect.Width, Rect.Height));
                        }

                        //Triangles
                        Helpers.DrawTriangle(G, new Rectangle(Rect.X + 158, (int)(Rect.Y + 8.5), 16, 25), Helpers.Direction.Left, Color.FromArgb(62, 65, 72));
                        Helpers.DrawTriangle(G, new Rectangle(Rect.X + 160, (int)(Rect.Y + 8.5), 16, 25), Helpers.Direction.Left, TabPages[i].BackColor);


                    }
                    else
                    {
                        //Fill not selected
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(72, 75, 82)))
                        {
                            G.FillRectangle(B, Rect);
                        }

                    }

                    //OverFill not selected

                    if (!(Index == -1) & !(SelectedIndex == Index))
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(82, 85, 92)))
                        {
                            G.FillRectangle(B, GetTabRect(Index));
                        }

                        //OverText
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(218, 220, 217)))
                        {
                            G.DrawString(TabPages[Index].Text, new Font("Segoe UI", 10), B, new Point(GetTabRect(Index).X + 55, GetTabRect(Index).Y + 12));
                        }

                        //Images
                        if ((ImageList != null))
                        {
                            if (!(TabPages[Index].ImageIndex < 0))
                            {
                                G.DrawImage(ImageList.Images[TabPages[Index].ImageIndex], new Rectangle(GetTabRect(Index).X + 25, GetTabRect(Index).Y + ((GetTabRect(Index).Height / 2) - 9), 18, 18));
                            }
                        }

                    }


                    if (!(i == Index))
                    {
                        //Texts
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(218, 220, 217)))
                        {
                            G.DrawString(TabPages[i].Text, new Font("Segoe UI", 10), B, new Point(Rect.X + 55, Rect.Y + 12));
                        }

                        //Images
                        if ((ImageList != null))
                        {
                            if (!(TabPages[i].ImageIndex < 0))
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Rectangle(Rect.X + 25, Rect.Y + ((Rect.Height / 2) - 9), 18, 18));
                            }
                        }

                    }
                }
                else
                {
                    //Headers
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(158, 160, 157)))
                    {
                        G.DrawString(TabPages[i].Text.ToUpper(), new Font("Segoe UI semibold", 9), B, new Point(Rect.X + 25, Rect.Y + 18));
                    }

                }

            }

        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);

            if ((e.TabPage != null))
            {
                if (!string.IsNullOrEmpty((string)e.TabPage.Tag))
                {
                    e.Cancel = true;
                }
                else
                {
                    Index = -1;
                }
            }

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                if (GetTabRect(i).Contains(e.Location) & !(SelectedIndex == i) & string.IsNullOrEmpty((string)TabPages[i].Tag))
                {
                    Index = i;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Index = -1;
        }

        #endregion

    }

}