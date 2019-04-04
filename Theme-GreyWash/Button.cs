// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GreyWash
{
    public class GreywashButton : Control
    {
        #region  Declarations 
        private MouseState State = MouseState.None;
        private Color _MainColour = Color.DarkGray;
        private Color _TextColour = Color.White;
        private Color _HoverColour = Color.LightGray;
        #endregion

        #region  MouseStates 

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

        #region  Properties 

        [Category("Colours"), Description("Background Colour Selection")]
        public Color BackgroundColour
        {
            get
            {
                return _MainColour;
            }
            set
            {
                _MainColour = value;
            }
        }

        [Category("Colours"), Description("Text Colour Selection")]
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

        #endregion

        public GreywashButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(135, 29);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP1 = new GraphicsPath();
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(BackColor);
            switch (State)
            {
                case MouseState.None:
                    GP = DrawHelpers.RoundRec(Base, 1);
                    G.FillPath(new SolidBrush(_MainColour), GP);
                    G.DrawString(Text, Font, new SolidBrush(_TextColour), Base, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                    break;
                case MouseState.Over:
                    GP = DrawHelpers.RoundRec(Base, 1);
                    G.FillPath(new SolidBrush(_HoverColour), GP);
                    G.DrawString(Text, Font, new SolidBrush(_TextColour), Base, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                    break;
                case MouseState.Down:
                    GP = DrawHelpers.RoundRec(Base, 1);
                    G.FillPath(new SolidBrush(_HoverColour), GP);
                    G.DrawString(Text, Font, new SolidBrush(_TextColour), Base, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                    GP1 = DrawHelpers.RoundRec(new Rectangle(0, 0, Width, Height), 3);
                    //.DrawPath(New Pen(New SolidBrush(Color.Gray), 2), GP1)
                    break;
            }
            base.OnPaint(e);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

    }

}
