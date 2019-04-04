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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.Facebook.DrawHelpers;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Facebook
{

    public class FacebookButton : Control
    {

        #region "Declarations"
        private MouseState State = MouseState.None;
        private Color _MainColour = Color.FromArgb(70, 98, 158);
        private Color _TextColour = Color.FromArgb(255, 255, 255);
        #endregion
        private Color _HoverColour = Color.FromArgb(55, 83, 158);

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

        [Category("Colours"), Description("Background Colour Selection")]
        public Color BackgroundColour
        {
            get { return _MainColour; }
            set { _MainColour = value; }
        }

        [Category("Colours"), Description("Text Colour Selection")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        #endregion

        #region "Draw Control"

        public FacebookButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(135, 32);
            BackColor = Color.Transparent;
            Font = new Font("Klavika", 9);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            dynamic G = Graphics.FromImage(B);
            dynamic GP = default(GraphicsPath);
            GraphicsPath GP1 = new GraphicsPath();
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            var _with2 = G;
            _with2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with2.SmoothingMode = SmoothingMode.HighQuality;
            _with2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with2.Clear(BackColor);
            switch (State)
            {
                case MouseState.None:
                    GP = DrawHelpers.RoundRec(Base, 2);
                    _with2.FillPath(new SolidBrush(_MainColour), GP);
                    _with2.DrawString(Text, Font, new SolidBrush(_TextColour), Base, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    GP = DrawHelpers.RoundRec(Base, 2);
                    _with2.FillPath(new SolidBrush(_HoverColour), GP);
                    _with2.DrawString(Text, Font, new SolidBrush(_TextColour), Base, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    GP = DrawHelpers.RoundRec(Base, 2);
                    _with2.FillPath(new SolidBrush(_HoverColour), GP);
                    _with2.DrawString(Text, Font, new SolidBrush(_TextColour), Base, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                    GP1 = DrawHelpers.RoundRec(new Rectangle(0, 0, Width, Height), 3);
                    _with2.DrawPath(new Pen(new SolidBrush(Color.LightYellow), 2), GP1);
                    break;
            }
            base.OnPaint(e);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }


}

