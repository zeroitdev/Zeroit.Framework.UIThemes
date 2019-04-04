// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TabVertical.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Facebook
{

    public class FacebookTabControlVertical : TabControl
    {

        #region "Declarations"
        private Color _PressedTabColour = Color.FromArgb(200, 215, 237);
        private Color _HoverColour = Color.FromArgb(109, 132, 180);
        private Color _NormalColour = Color.FromArgb(237, 239, 244);
        private Color _BorderColour = Color.FromArgb(139, 162, 210);
        private Color _TextColour = Color.FromArgb(58, 66, 73);
        #endregion
        private int HoverIndex = -1;

        #region "Colour & Other Properties"
        [Category("Colours")]
        public Color NormalColour
        {
            get { return _NormalColour; }
            set { _NormalColour = value; }
        }
        [Category("Colours")]
        public Color HoverColour
        {
            get { return _HoverColour; }
            set { _HoverColour = value; }
        }
        [Category("Colours")]
        public Color PressedTabColour
        {
            get { return _PressedTabColour; }
            set { _PressedTabColour = value; }
        }
        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }
        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }
        #endregion

        #region "Draw Control"
        public FacebookTabControlVertical()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 95);
            Font = new Font("Segoe UI", 9, FontStyle.Regular);
            DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is TabPage)
            {
                foreach (TabPage i in this.Controls)
                {
                    //i = new TabPage();

                    //e.Control.CreateControl() = (TabPage)i;

                    //Controls.Add(i);
                }
                e.Control.BackColor = Color.FromArgb(255, 255, 255);
            }
            base.OnControlAdded(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            for (int I = 0; I <= TabPages.Count - 1; I++)
            {
                if (GetTabRect(I).Contains(e.Location))
                {
                    HoverIndex = I;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HoverIndex = -1;
            Invalidate();
            base.OnMouseLeave(e);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            dynamic G = Graphics.FromImage(B);
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(BackColor);
            try
            {
                SelectedTab.BackColor = _NormalColour;
            }
            catch
            {
            }
            var _with6 = G;
            _with6.FillRectangle(new SolidBrush(_NormalColour), new Rectangle(-2, 0, ItemSize.Height + 4, Height + 22));
            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    _with6.FillRectangle(new SolidBrush(_NormalColour), x2);
                    Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X - 3, GetTabRect(i).Location.Y + 2, GetTabRect(i).Size.Width + 10, GetTabRect(i).Size.Height - 11);
                    _with6.FillRectangle(new SolidBrush(_PressedTabColour), new Rectangle(tabRect.X + 1, tabRect.Y + 1, tabRect.Width - 1, tabRect.Height - 2));
                    _with6.DrawRectangle(new Pen(_BorderColour), tabRect);
                    _with6.SmoothingMode = SmoothingMode.AntiAlias;
                }
                else
                {
                    Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 11));
                    _with6.FillRectangle(new SolidBrush(_NormalColour), x2);
                    if (HoverIndex == i)
                    {
                        Rectangle x21 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y + 2), new Size(GetTabRect(i).Width, GetTabRect(i).Height - 11));
                        _with6.FillRectangle(new SolidBrush(Color.FromArgb(199, 201, 207)), x21);
                    }
                }
                Rectangle tabRect1 = new Rectangle(GetTabRect(i).Location.X + 3, GetTabRect(i).Location.Y + 3, GetTabRect(i).Size.Width - 20, GetTabRect(i).Size.Height - 11);
                _with6.DrawString(TabPages[i].Text, Font, new SolidBrush(_TextColour), tabRect1, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
                _with6.FillRectangle(new SolidBrush(_NormalColour), new Rectangle(97, 0, Width - 97, Height));
                _with6.DrawLine(new Pen((_BorderColour), 1), new Point(96, 0), new Point(96, Height));
            }
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion

    }


}

