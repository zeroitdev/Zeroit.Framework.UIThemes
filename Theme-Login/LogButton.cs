// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="LogButton.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using static Zeroit.Framework.UIThemes.Login.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInLogButton : Control
    {

        #region "Declarations"
        private MouseState State = MouseState.None;
        private Color _ArcColour = Color.FromArgb(43, 43, 43);
        private Color _ArrowColour = Color.FromArgb(235, 233, 234);
        private Color _ArrowBorderColour = Color.FromArgb(170, 170, 170);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _HoverColour = Color.FromArgb(0, 130, 169);
        private Color _PressedColour = Color.FromArgb(0, 145, 184);
        #endregion
        private Color _NormalColour = Color.FromArgb(0, 160, 199);

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

        #region "Colour Properties"
        [Category("Colours")]
        public Color ArcColour
        {
            get { return _ArcColour; }
            set { _ArcColour = value; }
        }
        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }
        [Category("Colours")]
        public Color ArrowColour
        {
            get { return _ArrowColour; }
            set { _ArrowColour = value; }
        }
        [Category("Colours")]
        public Color ArrowBorderColour
        {
            get { return _ArrowBorderColour; }
            set { _ArrowBorderColour = value; }
        }
        [Category("Colours")]
        public Color HoverColour
        {
            get { return _HoverColour; }
            set { _HoverColour = value; }
        }
        [Category("Colours")]
        public Color PressedColour
        {
            get { return _PressedColour; }
            set { _PressedColour = value; }
        }
        [Category("Colours")]
        public Color NormalColour
        {
            get { return _NormalColour; }
            set { _NormalColour = value; }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(50, 50);
        }

        #endregion

        #region "Draw Control"

        public LogInLogButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(50, 50);
            BackColor = Color.FromArgb(54, 54, 54);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP1 = new GraphicsPath();
            var _with5 = G;
            _with5.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with5.SmoothingMode = SmoothingMode.HighQuality;
            _with5.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with5.Clear(BackColor);
            Point[] P = {
            new Point(18, 22),
            new Point(28, 22),
            new Point(28, 18),
            new Point(34, 25),
            new Point(28, 32),
            new Point(28, 28),
            new Point(18, 28)
        };
            switch (State)
            {
                case MouseState.None:
                    _with5.FillEllipse(new SolidBrush(Color.FromArgb(56, 56, 56)), new Rectangle(Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 3, Height - 3 - 3));
                    _with5.DrawArc(new Pen(new SolidBrush(_ArcColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 3, Height - 3 - 3, -90, 360);
                    _with5.DrawEllipse(new Pen(_BorderColour), new Rectangle(1, 1, Height - 3, Height - 3));
                    _with5.FillEllipse(new SolidBrush(_NormalColour), new Rectangle(Convert.ToInt32(3 / 2) + 3, Convert.ToInt32(3 / 2) + 3, Height - 11, Height - 11));
                    _with5.FillPolygon(new SolidBrush(_ArrowColour), P);
                    _with5.DrawPolygon(new Pen(_ArrowBorderColour), P);
                    break;
                case MouseState.Over:
                    _with5.DrawArc(new Pen(new SolidBrush(_ArcColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 3, Height - 3 - 3, -90, 360);
                    _with5.DrawEllipse(new Pen(_BorderColour), new Rectangle(1, 1, Height - 3, Height - 3));
                    _with5.FillEllipse(new SolidBrush(_HoverColour), new Rectangle(6, 6, Height - 13, Height - 13));
                    _with5.FillPolygon(new SolidBrush(_ArrowColour), P);
                    _with5.DrawPolygon(new Pen(_ArrowBorderColour), P);
                    break;
                case MouseState.Down:
                    _with5.DrawArc(new Pen(new SolidBrush(_ArcColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 3, Height - 3 - 3, -90, 360);
                    _with5.DrawEllipse(new Pen(_BorderColour), new Rectangle(1, 1, Height - 3, Height - 3));
                    _with5.FillEllipse(new SolidBrush(_PressedColour), new Rectangle(6, 6, Height - 13, Height - 13));
                    _with5.FillPolygon(new SolidBrush(_ArrowColour), P);
                    _with5.DrawPolygon(new Pen(_ArrowBorderColour), P);
                    break;
            }
            GP.Dispose();
            GP1.Dispose();
            _with5.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}


