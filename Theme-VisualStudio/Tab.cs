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
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.VisualStudio
{
    public class VisualStudioTabControl : TabControl
    {
        #region Declarations

        private Color _TextColour = Color.FromArgb(255, 255, 255);
        private Color _BackTabColour = Color.FromArgb(28, 28, 28);
        private Color _BaseColour = Color.FromArgb(45, 45, 48);
        private Color _ActiveColour = Color.FromArgb(0, 122, 204);
        private Color _BorderColour = Color.FromArgb(30, 30, 30);
        private Color _HorizLineColour = Color.FromArgb(0, 122, 204);
        private StringFormat CenterSF = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };

        #endregion

        #region Properties

        [Category("Colours")]
        public Color BorderColour
        {
            get
            {
                return _BorderColour;
            }
            set
            {
                _BorderColour = value;
            }
        }

        [Category("Colours")]
        public Color HorizontalLineColour
        {
            get
            {
                return _HorizLineColour;
            }
            set
            {
                _HorizLineColour = value;
            }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get
            {
                return _TextColour;
            }
            set
            {
                _TextColour = value;
            }
        }

        [Category("Colours")]
        public Color BackTabColour
        {
            get
            {
                return _BackTabColour;
            }
            set
            {
                _BackTabColour = value;
            }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get
            {
                return _BaseColour;
            }
            set
            {
                _BaseColour = value;
            }
        }

        [Category("Colours")]
        public Color ActiveColour
        {
            get
            {
                return _ActiveColour;
            }
            set
            {
                _ActiveColour = value;
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        private TabPage predraggedTab;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            predraggedTab = getPointedTab();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            predraggedTab = null;
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && predraggedTab != null)
            {
                this.DoDragDrop(predraggedTab, DragDropEffects.Move);
            }
            base.OnMouseMove(e);
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            TabPage draggedTab = (TabPage)drgevent.Data.GetData(typeof(TabPage));
            TabPage pointedTab = getPointedTab();

            if (draggedTab == predraggedTab && pointedTab != null)
            {
                drgevent.Effect = DragDropEffects.Move;

                if (!(pointedTab == draggedTab))
                {
                    swapTabPages(draggedTab, pointedTab);
                }
            }

            base.OnDragOver(drgevent);
        }

        private TabPage getPointedTab()
        {
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                if (this.GetTabRect(i).Contains(this.PointToClient(Cursor.Position)))
                {
                    return this.TabPages[i];
                }
            }

            return null;
        }

        private void swapTabPages(TabPage src, TabPage dst)
        {
            int srci = this.TabPages.IndexOf(src);
            int dsti = this.TabPages.IndexOf(dst);

            this.TabPages[dsti] = src;
            this.TabPages[srci] = dst;

            if (this.SelectedIndex == srci)
            {
                this.SelectedIndex = dsti;
            }
            else if (this.SelectedIndex == dsti)
            {
                this.SelectedIndex = srci;
            }

            this.Refresh();
        }

        #endregion

        #region Draw Control

        public VisualStudioTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(240, 16);
            AllowDrop = true;
        }

        protected override void OnTabIndexChanged(EventArgs e)
        {
            base.OnTabIndexChanged(e);
            SelectedTab.BackColor = _BackTabColour;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(_BaseColour);
            

            for (var i = 0; i < TabCount; i++)
            {
                Rectangle Base = new Rectangle(new Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width, GetTabRect(i).Height));
                Rectangle BaseSize = new Rectangle(Base.Location, new Size(Base.Width, Base.Height));
                if (i == SelectedIndex)
                {
                    g.FillRectangle(new SolidBrush(_BaseColour), BaseSize);
                    g.FillRectangle(new SolidBrush(_ActiveColour), new Rectangle(Base.X - 5, Base.Y - 3, Base.Width, Base.Height + 5));
                    g.DrawString(TabPages[i].Text, Font, new SolidBrush(_TextColour), BaseSize, CenterSF);
                }
                else
                {
                    g.DrawString(TabPages[i].Text, Font, new SolidBrush(_TextColour), BaseSize, CenterSF);
                }
            }
            g.DrawLine(new Pen(_HorizLineColour, 2F), new Point(0, 19), new Point(Width, 19));
            g.FillRectangle(new SolidBrush(_BackTabColour), new Rectangle(0, 20, Width, Height - 20));
            g.DrawRectangle(new Pen(_BorderColour, 2F), new Rectangle(0, 0, Width, Height));
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}
