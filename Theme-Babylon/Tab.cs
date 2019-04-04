// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Babylon
{
    #region  TabControl 

    public class BabylonTabControl : TabControl
    {
        // NOTE: For best quality icons/images on the TabControl; from the associated ImageList, set
        // the image size (24,24) so it can fit in the tab rectangle. However, to ensure a
        // high-quality image drawing, make sure you only add (32,32) images and not (24,24) as
        // determined in the ImageList

        // INFO: A free, non-commercial icon list that would fit in perfectly with the TabControl is
        // Wireframe Toolbar Icons by Gentleface. Licensed under Creative Commons Attribution.
        // Check it out from here: http://www.gentleface.com/free_icon_set.html

        public BabylonTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);

            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 135);
            DrawMode = TabDrawMode.OwnerDrawFixed;

            foreach (TabPage Page in this.TabPages)
            {
                Page.BackColor = Color.FromArgb(246, 246, 246);
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is TabPage)
            {
                foreach (TabPage i in this.Controls)
                {
                    //i = new TabPage();
                    i.BackColor = Color.FromArgb(246, 246, 246);
                }
                e.Control.BackColor = Color.FromArgb(246, 246, 246);
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            base.DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            Appearance = TabAppearance.Normal;
            Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);


            G.Clear(Color.FromArgb(246, 246, 246));
            G.SmoothingMode = SmoothingMode.HighSpeed;
            G.CompositingQuality = CompositingQuality.HighSpeed;
            G.CompositingMode = CompositingMode.SourceOver;

            // Draw tab selector background
            G.FillRectangle(new SolidBrush(Color.FromArgb(54, 57, 64)), new Rectangle(-5, 0, ItemSize.Height + 4, Height));
            // Draw vertical line at the end of the tab selector rectangle
            G.DrawLine(new Pen(Color.FromArgb(25, 26, 28)), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height);

            for (int TabIndex = 0; TabIndex < TabCount; TabIndex++)
            {
                if (TabIndex == SelectedIndex)
                {
                    Rectangle TabRect = new Rectangle(new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));

                    // Draw background of the selected tab
                    G.FillRectangle(new SolidBrush(Color.FromArgb(35, 36, 38)), TabRect.X, TabRect.Y, TabRect.Width - 4, TabRect.Height + 3);
                    // Draw a tab highlighter on the background of the selected tab
                    Rectangle TabHighlighter = new Rectangle(new Point(GetTabRect(TabIndex).X - 2, GetTabRect(TabIndex).Location.Y - ((TabIndex == 0) ? 1 : 1)), new Size(4, GetTabRect(TabIndex).Height - 7));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(89, 169, 222)), TabHighlighter);
                    // Draw tab text
                    G.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(Color.FromArgb(254, 255, 255)), new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), new StringFormat { Alignment = StringAlignment.Near });

                    if (this.ImageList != null)
                    {
                        int Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            G.DrawImage(this.ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9, TabRect.Y + 6, 24, 24);
                        }
                    }

                }
                else
                {

                    Rectangle TabRect = new Rectangle(new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));
                    // Draw tab text
                    G.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(Color.FromArgb(159, 162, 167)), new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), new StringFormat { Alignment = StringAlignment.Near });

                    if (this.ImageList != null)
                    {
                        int Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            G.DrawImage(this.ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9, TabRect.Y + 6, 24, 24);
                        }
                    }

                }
            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}