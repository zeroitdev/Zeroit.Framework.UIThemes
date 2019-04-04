// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="DescriptiveButton.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Professional
{
    public class ProDescriptiveButton : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            DrawingHelper dh = new DrawingHelper();
            MultiLineHandler mlh = new MultiLineHandler();
            int slope = Adjustments.Roundness;

            Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath mainPath = dh.RoundRect(mainRect, slope);

            ColorBlend backCB = new ColorBlend(3);
            backCB.Colors = new[] { Color.WhiteSmoke, Color.WhiteSmoke, Color.FromArgb(225, 230, 230) };
            backCB.Positions = new[] { 0.0f, 0.75f, 1.0f };
            LinearGradientBrush backLGB = new LinearGradientBrush(mainRect, Color.Black, Color.Black, 90.0F);
            backLGB.InterpolationColors = backCB;
            g.FillPath(backLGB, mainPath);

            SolidBrush textBrush = new SolidBrush(Color.FromArgb(50, 50, 50));

            if (_image != null)
            {
                Rectangle imageRect = new Rectangle(12, 12, 48, 48);
                g.DrawImage(_image, imageRect);
                g.DrawString(_title, _titleFont, textBrush, new Point(12 + 48 + 4, (int)(12 + (48 / 2.0) - (g.MeasureString(_title, _titleFont).Height / 2.0))));
            }
            else
            {
                g.DrawString(_title, _titleFont, textBrush, new Point(12, (int)(12 + (48 / 2.0) - (g.MeasureString(_title, _titleFont).Height / 2.0))));
            }

            int descY = 12 + 48 + 14;
            textBrush = new SolidBrush(Color.FromArgb(120, 120, 120));

            foreach (string line in mlh.GetLines(g, Text, Font, Width - 24))
            {
                g.DrawString(line, Font, textBrush, new Point(12, descY));
                descY += 13;
            }

            if (state == MouseState.Over)
            {
                g.FillPath(new SolidBrush(Color.FromArgb(10, Color.Black)), mainPath);
            }
            else if (state == MouseState.Down)
            {
                g.FillPath(new SolidBrush(Color.FromArgb(18, Color.Black)), mainPath);
            }

            LinearGradientBrush borderLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.Silver, Color.Gainsboro, 90.0F);
            g.DrawPath(new Pen(borderLGB), mainPath);

        }

        public ProDescriptiveButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Font = new Font(Adjustments.DefaultFontFamily, 8);
            Size = new Size(200, 130);
            Cursor = Cursors.Hand;
        }

        private Image _image;
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        private string _title = "Title";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                Invalidate();
            }
        }

        private Font _titleFont = new Font(Adjustments.DefaultFontFamily, 14);
        public Font TitleFont
        {
            get
            {
                return _titleFont;
            }
            set
            {
                _titleFont = value;
                Invalidate();
            }
        }

        public enum MouseState
        {
            None,
            Over,
            Down
        }

        private MouseState state = MouseState.None;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            state = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            state = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            state = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            state = MouseState.Over;
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Font = new Font(Font.FontFamily, 8);
        }

    }
}
