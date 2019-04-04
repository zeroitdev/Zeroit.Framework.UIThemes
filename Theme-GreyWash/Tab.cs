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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GreyWash
{
    public class GreywashTabControl : TabControl
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            LightBrush = new SolidBrush(LightColor);
            DarkBrush = new SolidBrush(DarkColor);
        }

        #region  Declarations 
        private Color LightColor = Color.DarkGray;
        private Color DarkColor = Color.LightGray;
        private SolidBrush LightBrush;
        private SolidBrush DarkBrush;
        private SolidBrush NotSelectedColor = new SolidBrush(Color.LightGray);
        private SolidBrush SelectedColor = new SolidBrush(Color.DarkGray);
        #endregion

        public GreywashTabControl()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque), true);
            SetStyle(ControlStyles.Selectable, false);
            Dock = DockStyle.None;
            SizeMode = TabSizeMode.Fixed;
            Alignment = TabAlignment.Left;
            ItemSize = new Size(25, 120);
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Font = new Font("Segoe UI", 10);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bm = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(DarkColor);

            for (var i = 0; i < TabCount; i++)
            {
                Rectangle TabRectangle = GetTabRect(i);
                if (i == SelectedIndex)
                {
                    g.FillRectangle(LightBrush, TabRectangle);
                    g.FillRectangle(SelectedColor, new Rectangle(TabRectangle.Location.X + 2, TabRectangle.Location.Y + 2, 3, TabRectangle.Height - 4));
                }
                else
                {
                    g.FillRectangle(DarkBrush, TabRectangle);
                    g.FillRectangle(NotSelectedColor, new Rectangle(TabRectangle.Location.X + 2, TabRectangle.Location.Y + 2, 3, TabRectangle.Height - 4));
                }
                g.DrawString(TabPages[i].Text, Font, Brushes.White, TabRectangle, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }

            e.Graphics.DrawImage((Image)bm.Clone(), 0, 0);
            g.Dispose();
            bm.Dispose();
            base.OnPaint(e);
        }

    }

}
