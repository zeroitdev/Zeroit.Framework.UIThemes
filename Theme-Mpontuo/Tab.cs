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
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoTabControl : TabControl
    {
        private int _HeaderWidth;
        private int _HeaderHeight;

        private System.Drawing.ContentAlignment _HeaderAlignment;
        private System.Windows.Forms.Padding _HeaderPadding;
        private Font _HeaderFont;
        private Color _HeaderBackColor;
        private SolidBrush _HeaderBackBrush;
        private Color _HeaderBorderColor;
        private Pen _HeaderBackPen;
        private Color _HeaderForeColor;
        private SolidBrush _HeaderForeBrush;
        private Color _HeaderSelectedBackColor;
        private SolidBrush _HeaderSelectedBackBrush;
        private Color _HeaderSelectedForeColor;
        private Brush _HeaderSelectedForeBrush;

        private Color _BackColor;
        private System.Drawing.SolidBrush _BackBrush;

        #region  Header Properties 
        [System.ComponentModel.DefaultValue(100)]
        public int HeaderWidth
        {
            get
            {
                return this._HeaderWidth;
            }
            set
            {
                this._HeaderWidth = value;
                this.ItemSize = new Size(this.ItemSize.Width, value);
            }
        }

        [System.ComponentModel.DefaultValue(32)]
        public int HeaderHeight
        {
            get
            {
                return this._HeaderHeight;
            }
            set
            {
                this._HeaderHeight = value;
                this.ItemSize = new Size(value, this.ItemSize.Height);
            }
        }

        [System.ComponentModel.DefaultValue(typeof(System.Drawing.ContentAlignment), "ContentAlignment.MiddleLeft")]
        public System.Drawing.ContentAlignment HeaderAlignment
        {
            get
            {
                return this._HeaderAlignment;
            }
            set
            {
                this._HeaderAlignment = value;
                this.Invalidate();
            }
        }

        [System.ComponentModel.DefaultValue(typeof(System.Windows.Forms.Padding), "3,3,3,3")]
        public System.Windows.Forms.Padding HeaderPadding
        {
            get
            {
                return this._HeaderPadding;
            }
            set
            {
                this._HeaderPadding = value;
                this.Invalidate();
            }
        }

        [System.ComponentModel.DefaultValue(typeof(Color), "White")]
        public Color HeaderBorderColor
        {
            get
            {
                return this._HeaderBorderColor;
            }
            set
            {
                if (!(value == this._HeaderBorderColor))
                {
                    this._HeaderBorderColor = value;
                    if (this._HeaderBackPen != null)
                    {
                        this._HeaderBackPen.Dispose();
                        this._HeaderBackPen = null;
                    }
                    this.Invalidate();
                }
            }
        }

        [System.ComponentModel.DefaultValue(typeof(Color), "LightGray")]
        public Color HeaderBackColor
        {
            get
            {
                return this._HeaderBackColor;
            }
            set
            {
                if (!(value == this._HeaderBackColor))
                {
                    this._HeaderBackColor = value;
                    if (this._HeaderBackBrush != null)
                    {
                        this._HeaderBackBrush.Dispose();
                        this._HeaderBackBrush = null;
                    }
                    this.Invalidate();
                }
            }
        }

        private SolidBrush HeaderBackBrush
        {
            get
            {
                if (this._HeaderBackBrush == null)
                {
                    this._HeaderBackBrush = new SolidBrush(this.HeaderBackColor);
                }
                return this._HeaderBackBrush;
            }
        }

        private Pen HeaderPen
        {
            get
            {
                if (this._HeaderBackPen == null)
                {
                    this._HeaderBackPen = new Pen(this.HeaderBorderColor);
                }
                return this._HeaderBackPen;
            }
        }

        [System.ComponentModel.DefaultValue(typeof(Color), "Black")]
        public Color HeaderForeColor
        {
            get
            {
                return this._HeaderForeColor;
            }
            set
            {
                if (!(value == this._HeaderForeColor))
                {
                    this._HeaderForeColor = value;
                    if (this._HeaderForeBrush != null)
                    {
                        this._HeaderForeBrush.Dispose();
                        this._HeaderForeBrush = null;
                    }
                    this.Invalidate();
                }
            }
        }

        private SolidBrush HeaderForeBrush
        {
            get
            {
                if (this._HeaderForeBrush == null)
                {
                    this._HeaderForeBrush = new SolidBrush(this.HeaderForeColor);
                }
                return this._HeaderForeBrush;
            }
        }

        [System.ComponentModel.DefaultValue(typeof(Color), "DarkGray")]
        public Color HeaderSelectedBackColor
        {
            get
            {
                return this._HeaderSelectedBackColor;
            }
            set
            {
                if (!(value == this._HeaderSelectedBackColor))
                {
                    this._HeaderSelectedBackColor = value;
                    if (this._HeaderSelectedBackBrush != null)
                    {
                        this._HeaderSelectedBackBrush.Dispose();
                        this._HeaderSelectedBackBrush = null;
                    }
                    this.Invalidate();
                }
            }
        }

        private SolidBrush HeaderSelectedBackBrush
        {
            get
            {
                if (this._HeaderSelectedBackBrush == null)
                {
                    this._HeaderSelectedBackBrush = new SolidBrush(this.HeaderSelectedBackColor);
                }
                return this._HeaderSelectedBackBrush;
            }
        }

        [System.ComponentModel.DefaultValue(typeof(Color), "Black")]
        public Color HeaderSelectedForeColor
        {
            get
            {
                return this._HeaderSelectedForeColor;
            }
            set
            {
                if (!(value == this._HeaderSelectedForeColor))
                {
                    this._HeaderSelectedForeColor = value;
                    this._HeaderSelectedForeBrush.Dispose();
                    this._HeaderSelectedForeBrush = null;
                    this.Invalidate();
                }
            }
        }

        private SolidBrush HeaderSelectedForeBrush
        {
            get
            {
                if (this._HeaderSelectedForeBrush == null)
                {
                    this._HeaderSelectedForeBrush = new SolidBrush(this.HeaderSelectedForeColor);
                }
                return (SolidBrush)this._HeaderSelectedForeBrush;
            }
        }

        public Font HeaderFont
        {
            get
            {
                return this._HeaderFont;
            }
            set
            {
                this._HeaderFont = value;
                this.Invalidate();
            }
        }
        #endregion

        [System.ComponentModel.DefaultValue(typeof(Color), "White"), System.ComponentModel.Browsable(true)]
        public override Color BackColor
        {
            get
            {
                return this._BackColor;
            }
            set
            {
                if (!(this._BackColor == value))
                {
                    this._BackColor = value;
                    if (this._BackBrush != null)
                    {
                        this._BackBrush.Dispose();
                        this._BackBrush = null;
                    }
                    this.Invalidate();
                }
            }
        }

        private SolidBrush BackBrush
        {
            get
            {
                if (this._BackBrush == null)
                {
                    this._BackBrush = new SolidBrush(this.BackColor);
                }
                return this._BackBrush;
            }
        }

        public MpontuoTabControl()
        {
            this._HeaderWidth = 100;
            this._HeaderHeight = 32;
            this._HeaderAlignment = ContentAlignment.MiddleLeft;
            this._HeaderPadding = new Padding(3);
            this._BackColor = Color.FromArgb(40, 40, 40);
            this._HeaderBorderColor = Color.FromArgb(40, 40, 40);
            this._HeaderFont = this.Font;
            this._HeaderForeColor = Color.FromArgb(66, 130, 181);
            this._HeaderBackColor = Color.FromArgb(50, 50, 50);
            this._HeaderSelectedBackColor = Color.FromArgb(65, 65, 65);
            this._HeaderSelectedForeColor = Color.FromArgb(66, 130, 181);

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = TabSizeMode.Fixed;
            this.Alignment = TabAlignment.Left;

            this.ItemSize = new Size(this.HeaderHeight, this.HeaderWidth);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            foreach (TabPage tp in this.TabPages)
            {
                tp.BackColor = Color.Transparent;
                tp.CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(65, 65, 65)), new Rectangle(0, 0, tp.Width - 1, tp.Height - 1));
            }
            SubscribeToEvents();
        }

        private void TabP(object sender, EventArgs e)
        {
            if (TabPages.Count < 1)
            {
                return;
            }
            foreach (TabPage tp in this.TabPages)
            {
                tp.BackColor = Color.Transparent;
                tp.CreateGraphics().Clear(this.BackColor);
                tp.CreateGraphics().DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, tp.Width - 1, tp.Height - 1));
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = null;

            g = e.Graphics;

            g.FillRectangle(this.BackBrush, e.ClipRectangle); // background

            for (int i = 0; i < this.TabPages.Count; i++)
            {
                this.DrawTabButton(g, i);
                this.DrawTabText(g, i);
            }
        }

        private void DrawTabButton(Graphics g, int TabPageIndex)
        {
            Rectangle r = new Rectangle();
            // get the tab rectangle
            r = this.GetTabRect(TabPageIndex);
            // increase its width we dont want the background in between
            r.Width = r.Width + 2;
            // if first tab page
            if (TabPageIndex == 0)
            {
                // reduce its height and move it a little bit lower
                // since in tab control first tab button is displayed a little
                // bit heigher
                r.Height = r.Height - 2;
                r.Y = r.Y + 2;
            }
            // if given tab button is selected
            if (this.SelectedIndex == TabPageIndex)
            {
                // use selected properties
                g.FillRectangle(this.HeaderSelectedBackBrush, r);
                // if currently focused then draw focus rectangle
                if (this.Focused)
                {
                    System.Windows.Forms.ControlPaint.DrawFocusRectangle(g, new Rectangle(r.Left + 2, r.Top + 2, r.Width - 4, r.Height - 5));
                }
            }
            else // else (not the selected tab page)
            {
                g.FillRectangle(this.HeaderBackBrush, r);
            }

            // if first tab button
            if (TabPageIndex == 0)
            {
                // draw a line on top
                g.DrawLine(this.HeaderPen, r.Left, r.Top, r.Right, r.Top);
            }
            // line at left
            g.DrawLine(this.HeaderPen, r.Left, r.Top, r.Left, r.Bottom - 1);
            // line at bottom
            g.DrawLine(this.HeaderPen, r.Left, r.Bottom - 1, r.Right, r.Bottom - 1);
            // no line at right since we want to give an effect of
            // pages
        }

        private void DrawTabText(Graphics g, int TabPageIndex)
        {
            int iX = 0;
            int iY = 0;
            string sText = null;
            SizeF sizeText = new SizeF();
            Rectangle rectTab = new Rectangle();

            // get tab button rectangle
            rectTab = this.GetTabRect(TabPageIndex);
            // get text
            sText = this.TabPages[TabPageIndex].Text;
            // measure the size of text
            sizeText = g.MeasureString(sText, this.HeaderFont);

            // check text alignment
            switch (this.HeaderAlignment)
            {
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.TopLeft:
                    iX = rectTab.Left + this.HeaderPadding.Left;
                    break;
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                case ContentAlignment.TopRight:
                    iX = (int)(rectTab.Right - sizeText.Width - this.HeaderPadding.Right);
                    break;
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.TopCenter:
                    iX = (int)(rectTab.Left + (rectTab.Width - this.HeaderPadding.Left - this.HeaderPadding.Right - sizeText.Width) / 2.0);
                    break;
            }

            switch (this.HeaderAlignment)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    iY = rectTab.Top + this.HeaderPadding.Top;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    iY = (int)(rectTab.Bottom - sizeText.Height - this.HeaderPadding.Bottom);
                    break;
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    iY = (int)(rectTab.Top + (rectTab.Height - this.HeaderPadding.Top - sizeText.Height) / 2.0);
                    break;
            }

            // if selected tab button
            if (this.SelectedIndex == TabPageIndex)
            {
                g.DrawString(sText, this.HeaderFont, this.HeaderSelectedForeBrush, iX, iY);
            }
            else
            {
                g.DrawString(sText, this.HeaderFont, this.HeaderForeBrush, iX, iY);
            }
        }

        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.SelectedIndexChanged += TabP;
        }

    }
}

