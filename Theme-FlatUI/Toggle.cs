﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FlatUI.Helpers;
using System.ComponentModel;
//using System.Threading;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.FlatUI
{
    [DefaultEvent("CheckedChanged")]
    public class FlatToggle : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private _Options O;
        private bool _Checked = false;

        private MouseState State = MouseState.None;
        #endregion

        #region " Properties"
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        [Flags()]
        public enum _Options
        {
            Style1,
            Style2,
            Style3,
            Style4,
            //-- TODO: New Style
            Style5
            //-- TODO: New Style
        }

        #region " Options"

        [Category("Options")]
        public _Options Options
        {
            get { return O; }
            set { O = value; Invalidate(); }
        }

        [Category("Options")]
        public bool Checked
        {
            get { return _Checked; }
            set { _Checked = value; }
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

        #region " Mouse States"

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
            {
                CheckedChanged(this);
            }
        }

        #endregion

        #endregion

        #region " Colors"

        private Color BaseColor = _FlatColor;
        private Color BaseColorRed = Color.FromArgb(220, 85, 96);
        private Color BGColor = Color.FromArgb(84, 85, 86);
        private Color ToggleColor = Color.FromArgb(45, 47, 49);

        private Color TextColor = Color.FromArgb(243, 243, 243);
        #endregion

        public FlatToggle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(44, Height + 1);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10);
            Size = new Size(76, 33);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            dynamic GP = default(GraphicsPath);
            GraphicsPath GP2 = new GraphicsPath();
            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Toggle = new Rectangle(Convert.ToInt32(W / 2), 0, 38, H);

            var _with9 = G;
            _with9.SmoothingMode = SmoothingMode.HighQuality;
            _with9.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with9.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with9.Clear(BackColor);

            switch (O)
            {
                case _Options.Style1:
                    //-- Style 1
                    //-- Base
                    GP = Helpers.RoundRec(Base, 6);
                    GP2 = Helpers.RoundRec(Toggle, 6);
                    _with9.FillPath(new SolidBrush(BGColor), GP);
                    _with9.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Text
                    _with9.DrawString("OFF", Font, new SolidBrush(BGColor), new Rectangle(19, 1, W, H), CenterSF);

                    if (Checked)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 6);
                        GP2 = Helpers.RoundRec(new Rectangle(Convert.ToInt32(W / 2), 0, 38, H), 6);
                        _with9.FillPath(new SolidBrush(ToggleColor), GP);
                        _with9.FillPath(new SolidBrush(BaseColor), GP2);

                        //-- Text
                        _with9.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(8, 7, W, H), NearSF);
                    }
                    break;
                case _Options.Style2:
                    //-- Style 2
                    //-- Base
                    GP = Helpers.RoundRec(Base, 6);
                    Toggle = new Rectangle(4, 4, 36, H - 8);
                    GP2 = Helpers.RoundRec(Toggle, 4);
                    _with9.FillPath(new SolidBrush(BaseColorRed), GP);
                    _with9.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Lines
                    _with9.DrawLine(new Pen(BGColor), 18, 20, 18, 12);
                    _with9.DrawLine(new Pen(BGColor), 22, 20, 22, 12);
                    _with9.DrawLine(new Pen(BGColor), 26, 20, 26, 12);

                    //-- Text
                    _with9.DrawString("r", new Font("Marlett", 8), new SolidBrush(TextColor), new Rectangle(19, 2, Width, Height), CenterSF);

                    if (Checked)
                    {
                        GP = Helpers.RoundRec(Base, 6);
                        Toggle = new Rectangle(Convert.ToInt32(W / 2) - 2, 4, 36, H - 8);
                        GP2 = Helpers.RoundRec(Toggle, 4);
                        _with9.FillPath(new SolidBrush(BaseColor), GP);
                        _with9.FillPath(new SolidBrush(ToggleColor), GP2);

                        //-- Lines
                        _with9.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 12, 20, Convert.ToInt32(W / 2) + 12, 12);
                        _with9.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 16, 20, Convert.ToInt32(W / 2) + 16, 12);
                        _with9.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 20, 20, Convert.ToInt32(W / 2) + 20, 12);

                        //-- Text
                        _with9.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(TextColor), new Rectangle(8, 7, Width, Height), NearSF);
                    }
                    break;
                case _Options.Style3:
                    //-- Style 3
                    //-- Base
                    GP = Helpers.RoundRec(Base, 16);
                    Toggle = new Rectangle(W - 28, 4, 22, H - 8);
                    GP2.AddEllipse(Toggle);
                    _with9.FillPath(new SolidBrush(ToggleColor), GP);
                    _with9.FillPath(new SolidBrush(BaseColorRed), GP2);

                    //-- Text
                    _with9.DrawString("OFF", Font, new SolidBrush(BaseColorRed), new Rectangle(-12, 2, W, H), CenterSF);

                    if (Checked)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 16);
                        Toggle = new Rectangle(6, 4, 22, H - 8);
                        GP2.Reset();
                        GP2.AddEllipse(Toggle);
                        _with9.FillPath(new SolidBrush(ToggleColor), GP);
                        _with9.FillPath(new SolidBrush(BaseColor), GP2);

                        //-- Text
                        _with9.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(12, 2, W, H), CenterSF);
                    }
                    break;
                case _Options.Style4:
                    //-- Style 1
                    //-- Base
                    GP = Helpers.RoundRec(Base, 1);
                    GP2 = Helpers.RoundRec(Toggle, 1);
                    _with9.FillPath(new SolidBrush(BGColor), GP);
                    _with9.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Text
                    _with9.DrawString("OFF", Font, new SolidBrush(BGColor), new Rectangle(19, 1, W, H), CenterSF);

                    if (Checked)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 1);
                        GP2 = Helpers.RoundRec(new Rectangle(Convert.ToInt32(W / 2), 0, 38, H), 1);
                        _with9.FillPath(new SolidBrush(ToggleColor), GP);
                        _with9.FillPath(new SolidBrush(BaseColor), GP2);

                        //-- Text
                        _with9.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(8, 7, W, H), NearSF);
                    }
                    break;
                case _Options.Style5:
                    //-- Style 2
                    //-- Base
                    GP = Helpers.RoundRec(Base, 1);
                    Toggle = new Rectangle(4, 4, 36, H - 8);
                    GP2 = Helpers.RoundRec(Toggle, 1);
                    _with9.FillPath(new SolidBrush(BaseColorRed), GP);
                    _with9.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Lines
                    _with9.DrawLine(new Pen(BGColor), 18, 20, 18, 12);
                    _with9.DrawLine(new Pen(BGColor), 22, 20, 22, 12);
                    _with9.DrawLine(new Pen(BGColor), 26, 20, 26, 12);

                    //-- Text
                    _with9.DrawString("r", new Font("Marlett", 8), new SolidBrush(TextColor), new Rectangle(19, 2, Width, Height), CenterSF);

                    if (Checked)
                    {
                        GP = Helpers.RoundRec(Base, 1);
                        Toggle = new Rectangle(Convert.ToInt32(W / 2) - 2, 4, 36, H - 8);
                        GP2 = Helpers.RoundRec(Toggle, 1);
                        _with9.FillPath(new SolidBrush(BaseColor), GP);
                        _with9.FillPath(new SolidBrush(ToggleColor), GP2);

                        //-- Lines
                        _with9.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 12, 20, Convert.ToInt32(W / 2) + 12, 12);
                        _with9.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 16, 20, Convert.ToInt32(W / 2) + 16, 12);
                        _with9.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 20, 20, Convert.ToInt32(W / 2) + 20, 12);

                        //-- Text
                        _with9.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(TextColor), new Rectangle(8, 7, Width, Height), NearSF);
                    }
                    break;
            }


            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }

}

