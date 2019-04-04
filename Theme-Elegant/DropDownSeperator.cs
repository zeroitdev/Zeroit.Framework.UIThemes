// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="DropDownSeperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Elegant
{

    public class ElegantThemeDropDownSeperator : ContainerControl
    {

        #region "Declaration"

        private bool _Checked;
        private int X;
        private int Y;
        private bool Up;
        private int SpecifiedHeight;
        private int _OpenHeight = 200;
        private int _ClosedHeight = 30;
        private int _OpenWidth = 160;
        private bool _CaptureHeightChange = false;
        private Color _SeperatorColour = Color.FromArgb(163, 190, 146);
        private int _FontSize = 11;
        private Font _Font;
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        private float _Thickness = 1;

        private bool _Animate = false;
        #endregion

        #region "Properties & Events"

        [Category("Colours")]
        public Color SeperatorColour
        {
            get { return _SeperatorColour; }
            set { _SeperatorColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        public int OpenHeight
        {
            get { return _OpenHeight; }
            set { _OpenHeight = value; }
        }

        public float Thickness
        {
            get { return _Thickness; }
            set { _Thickness = value; }
        }

        public bool Animation
        {
            get { return _Animate; }
            set
            {
                _Animate = value;
                Invalidate();
            }
        }

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public bool CaptureHeightChange
        {
            get { return _CaptureHeightChange; }
            set
            {
                _CaptureHeightChange = value;
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (_CaptureHeightChange == true)
            {
                _OpenHeight = Height;
            }
            base.OnResize(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Y = e.Y;
            Invalidate();
        }

        public void Animate(bool Closing)
        {
            switch (Closing)
            {
                case true:
                    int HT = _OpenHeight;
                    while (!(HT == 30))
                    {
                        this.Height -= 1;
                        HT -= 1;
                    }
                    Up = true;
                    _Checked = false;
                    break;
                case false:
                    while (!(this.Height == _OpenHeight))
                    {
                        this.Height += 1;
                        Update();
                    }
                    Up = false;
                    _Checked = true;
                    break;
            }
        }

        public void ChangeCheck(object sender, MouseEventArgs e)
        {
            if (X >= Width - 22)
            {
                if (Y <= 30)
                {
                    switch (Checked)
                    {
                        case true:
                            if (_Animate)
                            {
                                Animate(true);
                            }
                            else
                            {
                                this.Height = 30;
                                Up = true;
                                _Checked = false;
                            }
                            break;
                        case false:
                            if (_Animate)
                            {
                                Animate(false);
                            }
                            else
                            {
                                this.Height = _OpenHeight;
                                Up = false;
                                _Checked = true;
                            }
                            break;
                    }
                }
            }
        }

        #endregion

        #region "Draw Control"

        public ElegantThemeDropDownSeperator()
        {
            MouseDown += ChangeCheck;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(90, 30);
            MinimumSize = new Size(5, 30);
            this.Font = new Font("Tahoma", 10);
            this.ForeColor = Color.FromArgb(40, 40, 40);
            _Checked = true;

            _Font = new Font("Tahoma", _FontSize);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            var _with8 = G;
            _with8.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with8.SmoothingMode = SmoothingMode.HighQuality;
            _with8.PixelOffsetMode = PixelOffsetMode.HighQuality;
            if (_Checked == true)
            {
                _with8.Clear(Color.FromArgb(250, 250, 250));
                _with8.DrawString(Text, _Font, new SolidBrush(_TextColour), 13, 30 / 2 - _FontSize + 1);
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(0, 30 / 2), new Point(10, 30 / 2));
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point((int)_with8.MeasureString(Text, _Font).Width + 13, 30 / 2), new Point(Width - 25, 30 / 2));
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Width - 7, 30 / 2), new Point(Width, 30 / 2));
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(1, 30 / 2), new Point(1, Height));
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Width - 1, 30 / 2), new Point(Width - 1, Height));
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(1, Height - 1), new Point(Width, Height - 1));
            }
            else
            {
                _with8.Clear(Color.FromArgb(250, 250, 250));
                _with8.DrawString(Text, _Font, new SolidBrush(_TextColour), 13, 30 / 2 - _FontSize + 1);
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(0, 30 / 2), new Point(10, 30 / 2));
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point((int)_with8.MeasureString(Text, _Font).Width + 13, 30 / 2), new Point(Width - 25, 30 / 2));
                _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Width - 7, 30 / 2), new Point(Width, 30 / 2));
            }
            switch (_Checked)
            {
                case false:
                    _with8.DrawLine(new Pen(Color.DarkGray, 2), new Point(Width - 21, 11), new Point(Width - 16, 19));
                    _with8.DrawLine(new Pen(Color.DarkGray, 2), new Point(Width - 16, 19), new Point(Width - 11, 11));
                    break;
                case true:
                    _with8.DrawLine(new Pen(Color.DarkGray, 2), new Point(Width - 21, 19), new Point(Width - 16, 11));
                    _with8.DrawLine(new Pen(Color.DarkGray, 2), new Point(Width - 16, 11), new Point(Width - 11, 19));
                    break;
            }
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }

}


