// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Toggle.cs" company="Zeroit Dev Technologies">
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
    public class DarkFlatToggle : Control
    {
        #region  Variables

        private int W;
        private int H;
        private _Options O;
        private bool _Checked = false;
        private MouseState State = MouseState.None;

        #endregion

        #region  Properties
        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;

        [Flags()]
        public enum _Options
        {
            Style1,
            Style2,
            Style3,
            Style4, //-- TODO: New Style
            Style5 //-- TODO: New Style
        }

        #region  Options

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

        [Category("Options")]
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
            }
        }

        #endregion

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 76;
            Height = 33;
        }

        #region  Mouse States

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _Checked = !_Checked;
            if (CheckedChanged != null)
                CheckedChanged(this);
        }

        #endregion

        #endregion

        #region  Colors

        private Color BaseColor = Color.FromArgb(0, 170, 220);
        private Color BaseColorRed = Color.FromArgb(0, 170, 220);
        private Color BGColor = Color.FromArgb(84, 85, 86);
        private Color ToggleColor = Color.FromArgb(45, 47, 49);
        private Color TextColor = Color.FromArgb(243, 243, 243);

        #endregion

        public DarkFlatToggle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(44, Height + 1);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10);
            Size = new Size(56, 13);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width - 1;
            H = Height - 1;

            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();
            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Toggle = new Rectangle(Convert.ToInt32(W / 2), 0, 38, H);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            switch (O)
            {
                case _Options.Style1: //-- Style 1
                                      //-- Base
                    GP = Helpers.RoundRec(Base, 6);
                    GP2 = Helpers.RoundRec(Toggle, 6);
                    Helpers.G.FillPath(new SolidBrush(BGColor), GP);
                    Helpers.G.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Text
                    Helpers.G.DrawString("OFF", Font, new SolidBrush(BGColor), new Rectangle(19, 1, W, H), Helpers.CenterSF);

                    if (Checked)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 6);
                        GP2 = Helpers.RoundRec(new Rectangle(Convert.ToInt32(W / 2), 0, 38, H), 6);
                        Helpers.G.FillPath(new SolidBrush(ToggleColor), GP);
                        Helpers.G.FillPath(new SolidBrush(BaseColor), GP2);

                        //-- Text
                        Helpers.G.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(8, 7, W, H), Helpers.NearSF);
                    }
                    break;
                case _Options.Style2: //-- Style 2
                                      //-- Base
                    GP = Helpers.RoundRec(Base, 6);
                    Toggle = new Rectangle(4, 4, 36, H - 8);
                    GP2 = Helpers.RoundRec(Toggle, 4);
                    Helpers.G.FillPath(new SolidBrush(BaseColorRed), GP);
                    Helpers.G.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Lines
                    Helpers.G.DrawLine(new Pen(BGColor), 18, 20, 18, 12);
                    Helpers.G.DrawLine(new Pen(BGColor), 22, 20, 22, 12);
                    Helpers.G.DrawLine(new Pen(BGColor), 26, 20, 26, 12);

                    //-- Text
                    Helpers.G.DrawString("r", new Font("Marlett", 8), new SolidBrush(TextColor), new Rectangle(19, 2, Width, Height), Helpers.CenterSF);

                    if (Checked)
                    {
                        GP = Helpers.RoundRec(Base, 6);
                        Toggle = new Rectangle(Convert.ToInt32(W / 2) - 2, 4, 36, H - 8);
                        GP2 = Helpers.RoundRec(Toggle, 4);
                        Helpers.G.FillPath(new SolidBrush(BaseColor), GP);
                        Helpers.G.FillPath(new SolidBrush(ToggleColor), GP2);

                        //-- Lines
                        Helpers.G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 12, 20, Convert.ToInt32(W / 2) + 12, 12);
                        Helpers.G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 16, 20, Convert.ToInt32(W / 2) + 16, 12);
                        Helpers.G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 20, 20, Convert.ToInt32(W / 2) + 20, 12);

                        //-- Text
                        Helpers.G.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(TextColor), new Rectangle(8, 7, Width, Height), Helpers.NearSF);
                    }
                    break;
                case _Options.Style3: //-- Style 3
                                      //-- Base
                    GP = Helpers.RoundRec(Base, 16);
                    Toggle = new Rectangle(W - 28, 4, 22, H - 8);
                    GP2.AddEllipse(Toggle);
                    Helpers.G.FillPath(new SolidBrush(ToggleColor), GP);
                    Helpers.G.FillPath(new SolidBrush(BaseColorRed), GP2);

                    //-- Text
                    Helpers.G.DrawString("OFF", Font, new SolidBrush(BaseColorRed), new Rectangle(-12, 2, W, H), Helpers.CenterSF);

                    if (Checked)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 16);
                        Toggle = new Rectangle(6, 4, 22, H - 8);
                        GP2.Reset();
                        GP2.AddEllipse(Toggle);
                        Helpers.G.FillPath(new SolidBrush(ToggleColor), GP);
                        Helpers.G.FillPath(new SolidBrush(BaseColor), GP2);

                        //-- Text
                        Helpers.G.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(12, 2, W, H), Helpers.CenterSF);
                    }
                    break;
                case _Options.Style4:
                    //-- TODO: New Styles
                    if (Checked)
                    {
                        //--
                    }
                    break;
                case _Options.Style5:
                    //-- TODO: New Styles
                    if (Checked)
                    {
                        //--
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



