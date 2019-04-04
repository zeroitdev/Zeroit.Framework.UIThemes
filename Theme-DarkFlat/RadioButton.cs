// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
    [DefaultEvent("CheckedChanged")]
    public class DarkFlatRadioButton : Control
    {
        #region  Variables

        private MouseState State = MouseState.None;
        private int W;
        private int H;
        private _Options O;
        private bool _Checked;

        #endregion

        #region  Properties

        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                    CheckedChanged(this);
                Invalidate();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
            {
                Checked = true;
            }
            base.OnClick(e);
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
            {
                return;
            }
            foreach (Control C in Parent.Controls)
            {
                if (C != this && C is RadioButton)
                {
                    ((RadioButton)C).Checked = false;
                    Invalidate();
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InvalidateControls();
        }

        [Flags]
        public enum _Options
        {
            Style1,
            Style2
        }

        [Category("Options")]
        public _Options Options
        {
            get
            {
                return O;
            }
            set
            {
                O = value;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 22;
        }

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
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
            }
        }

        #endregion

        #region  Mouse States

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

        #endregion

        #region  Colors

        private Color _BaseColor = Color.FromArgb(60, 60, 60);
        private Color _BorderColor = Color.FromArgb(0, 170, 220);
        private Color _TextColor = Color.FromArgb(243, 243, 243);

        #endregion

        public DarkFlatRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            Size = new Size(100, 22);
            BackColor = Color.FromArgb(50, 50, 50);
            Font = new Font("Segoe UI", 10);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width - 1;
            H = Height - 1;

            Rectangle Base = new Rectangle(0, 2, Height - 5, Height - 5);
            Rectangle Dot = new Rectangle(4, 6, H - 12, H - 12);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            switch (O)
            {
                case _Options.Style1: //-- Style 1
                                      //-- Base
                    Helpers.G.FillEllipse(new SolidBrush(_BaseColor), Base);

                    switch (State) //-- Mouse States
                    {
                        case MouseState.Over:
                            //-- Base
                            Helpers.G.DrawEllipse(new Pen(_BorderColor), Base);
                            break;
                        case MouseState.Down:
                            //-- Base
                            Helpers.G.DrawEllipse(new Pen(_BorderColor), Base);
                            break;
                    }

                    //-- If Checked
                    if (Checked)
                    {
                        //-- Base
                        Helpers.G.FillEllipse(new SolidBrush(_BorderColor), Dot);
                    }

                    //-- If Enabled
                    if (this.Enabled == false)
                    {
                        //-- Base
                        Helpers.G.FillEllipse(new SolidBrush(Color.FromArgb(54, 58, 61)), Base);
                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(140, 142, 143)), new Rectangle(20, 2, W, H), Helpers.NearSF);
                    }

                    //-- Text
                    Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(20, 2, W, H), Helpers.NearSF);
                    break;
                case _Options.Style2: //-- Style 2
                                      //-- Base
                    Helpers.G.FillEllipse(new SolidBrush(_BaseColor), Base);

                    switch (State)
                    {
                        case MouseState.Over: //-- Mouse States
                                              //-- Base
                            Helpers.G.DrawEllipse(new Pen(_BorderColor), Base);
                            Helpers.G.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), Base);
                            break;
                        case MouseState.Down:
                            //-- Base
                            Helpers.G.DrawEllipse(new Pen(_BorderColor), Base);
                            Helpers.G.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), Base);
                            break;
                    }

                    //-- If Checked
                    if (Checked)
                    {
                        //-- Base
                        Helpers.G.FillEllipse(new SolidBrush(_BorderColor), Dot);
                    }

                    //-- If Enabled
                    if (this.Enabled == false)
                    {
                        //-- Base
                        Helpers.G.FillEllipse(new SolidBrush(Color.FromArgb(54, 58, 61)), Base);
                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(48, 119, 91)), new Rectangle(20, 2, W, H), Helpers.NearSF);
                    }

                    //-- Text
                    Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(20, 2, W, H), Helpers.NearSF);
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



