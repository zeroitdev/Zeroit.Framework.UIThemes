// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="StickyButton.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.DarkFlat
{
    public class DarkFlatStickyButton : Control
    {
        #region  Variables

        private int W;
        private int H;
        private MouseState State = MouseState.None;
        private bool _Rounded = false;

        #endregion

        #region  Properties

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

        #region  Function

        private bool[] GetConnectedSides()
        {
            var Bool = new bool[4] { false, false, false, false };

            foreach (Control control in Parent.Controls)
            {
                if (control is DarkFlatStickyButton)
                {
                    if (control == this || !(Rect.IntersectsWith(Rect)))
                    {
                        continue;
                    }
                    var A = Math.Atan2(Left - control.Left, Top - control.Top) * 2 / Math.PI;
                    if (Math.Truncate(A / 1) == A)
                    {
                        Bool[Convert.ToInt32(A + 1)] = true;
                    }
                }
            }

            return Bool;
        }

        private Rectangle Rect
        {
            get
            {
                return new Rectangle(Left, Top, Width, Height);
            }
        }

        #endregion

        #region  Colors

        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return _BaseColor;
            }
            set
            {
                _BaseColor = value;
            }
        }

        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                _TextColor = value;
            }
        }

        [Category("Options")]
        public bool Rounded
        {
            get
            {
                return _Rounded;
            }
            set
            {
                _Rounded = value;
            }
        }

        #endregion

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Height = 32
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //Size = New Size(112, 32)
        }

        #endregion

        #region  Colors

        private Color _BaseColor = Color.FromArgb(0, 170, 220);
        private Color _TextColor = Color.FromArgb(243, 243, 243);

        #endregion

        public DarkFlatStickyButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(106, 32);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 10);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width;
            H = Height;

            GraphicsPath GP = new GraphicsPath();

            var GCS = GetConnectedSides();
            var RoundedBase = Helpers.RoundRect(0F, 0F, W, H, 0.3F, !(GCS[2] || GCS[1]), !(GCS[1] || GCS[0]), !(GCS[3] || GCS[0]), !(GCS[3] || GCS[2]));
            Rectangle Base = new Rectangle(0, 0, W, H);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    if (Rounded)
                    {
                        //-- Base
                        GP = RoundedBase;
                        Helpers.G.FillPath(new SolidBrush(_BaseColor), GP);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    else
                    {
                        //-- Base
                        Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    break;
                case MouseState.Over:
                    if (Rounded)
                    {
                        //-- Base
                        GP = RoundedBase;
                        Helpers.G.FillPath(new SolidBrush(_BaseColor), GP);
                        Helpers.G.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), GP);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    else
                    {
                        //-- Base
                        Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);
                        Helpers.G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), Base);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    break;
                case MouseState.Down:
                    if (Rounded)
                    {
                        //-- Base
                        GP = RoundedBase;
                        Helpers.G.FillPath(new SolidBrush(_BaseColor), GP);
                        Helpers.G.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), GP);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    else
                    {
                        //-- Base
                        Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);
                        Helpers.G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), Base);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    break;
            }


            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }

    }

}



