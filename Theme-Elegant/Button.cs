// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.Elegant.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Elegant
{

    public class ElegantThemeButton : Control
    {

        #region "Declarations"
        private MouseState State = MouseState.None;
        private Font _Font = new Font("Segoe UI", 9);
        private Color _BaseColour = Color.FromArgb(245, 245, 245);
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        private Color _PressedTextColour = Color.FromArgb(42, 42, 42);
        #endregion
        private Color _BorderColour = Color.FromArgb(163, 190, 146);

        #region "Properties"

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }
        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }
        [Category("Colours")]
        public Color PressedTextColour
        {
            get { return _PressedTextColour; }
            set { _PressedTextColour = value; }
        }
        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }
        public override Font Font
        {
            get { return _Font; }
            set { _Font = value; }
        }

        #endregion

        #region "Mouse States"

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

        #region "Draw Control"

        public ElegantThemeButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(75, 30);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            GraphicsPath GP = default(GraphicsPath);
            GraphicsPath GP1 = new GraphicsPath();
            var _with4 = G;
            _with4.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with4.SmoothingMode = SmoothingMode.HighQuality;
            _with4.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with4.Clear(BackColor);
            switch (State)
            {
                case MouseState.None:
                    _with4.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
                    _with4.DrawRectangle(new Pen(_BorderColour, 1), new Rectangle(0, 0, Width, Height));
                    _with4.DrawString(Text, _Font, new SolidBrush(_TextColour), new Rectangle(0, 0, Width, Height), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    _with4.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
                    _with4.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
                    _with4.DrawString(Text, _Font, new SolidBrush(_TextColour), new Rectangle(0, 0, Width, Height), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    _with4.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
                    _with4.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
                    _with4.DrawString(Text, _Font, new SolidBrush(_PressedTextColour), new Rectangle(0, 0, Width, Height), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }
            base.OnPaint(e);
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }


}


