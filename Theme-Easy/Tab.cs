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
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Easy
{
    public class EasyTabs : TabControl
    {
        // Initialize
        public EasyTabs()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Dock = DockStyle.Bottom;
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(100, 20);
        }

        // Tabs Back Color Property
        private Color m_Backcolor = Color.Empty;
        [Browsable(true)]
        public override Color BackColor
        {
            get
            {
                if (m_Backcolor.Equals(Color.Empty))
                {
                    if (Parent == null)
                    {
                        return Control.DefaultBackColor;
                    }
                    else
                    {
                        return Parent.BackColor;
                    }
                }
                return m_Backcolor;
            }
            set
            {
                if (m_Backcolor.Equals(value))
                {
                    return;
                }
                m_Backcolor = value;
                Invalidate();
                base.OnBackColorChanged(EventArgs.Empty);
            }
        }

        public bool ShouldSerializeBackColor()
        {
            return !(m_Backcolor.Equals(Color.Empty));
        }

        public override void ResetBackColor()
        {
            m_Backcolor = Color.Empty;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(BackColor);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Apply Colouring To Each Tab Page
            for (int i = 0; i < TabPages.Count; i++)
            {
                Rectangle rect = GetTabRect(i);
                Rectangle r = new Rectangle(GetTabRect(i).X + 10, GetTabRect(i).Y + 3, 100, 20);
                if (SelectedTab == TabPages[i])
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(75, 0, 0, 0)), rect);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(25, 0, 0, 0)), rect);
                }

                // Draw Tab Page Text
                g.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.White), (Rectangle)r);
                TabPages[i].UseVisualStyleBackColor = false;
            }
        }
    }
}
