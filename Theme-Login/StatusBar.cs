// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="StatusBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInStatusBar : Control
    {

        #region "Variables"
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _TextColour = Color.White;
        private Color _RectColour = Color.FromArgb(21, 117, 149);
        private bool _ShowLine = true;
        private LinesCount _LinesToShow = LinesCount.One;
        private Alignments _Alignment = Alignments.Left;
        #endregion
        private bool _ShowBorder = true;

        #region "Properties"

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        public enum LinesCount : int
        {
            One = 1,
            Two = 2
        }

        public enum Alignments
        {
            Left,
            Center,
            Right
        }

        [Category("Control")]
        public Alignments Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }

        [Category("Control")]
        public LinesCount LinesToShow
        {
            get { return _LinesToShow; }
            set { _LinesToShow = value; }
        }

        public bool ShowBorder
        {
            get { return _ShowBorder; }
            set { _ShowBorder = value; }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Dock = DockStyle.Bottom;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        [Category("Colours")]
        public Color RectangleColor
        {
            get { return _RectColour; }
            set { _RectColour = value; }
        }

        public bool ShowLine
        {
            get { return _ShowLine; }
            set { _ShowLine = value; }
        }

        #endregion

        #region "Draw Control"

        public LogInStatusBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9);
            ForeColor = Color.White;
            Size = new Size(Width, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with22 = G;
            _with22.SmoothingMode = SmoothingMode.HighQuality;
            _with22.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with22.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with22.Clear(BaseColour);
            _with22.FillRectangle(new SolidBrush(BaseColour), Base);
            if (_ShowLine == true)
            {
                switch (_LinesToShow)
                {
                    case LinesCount.One:
                        if (_Alignment == Alignments.Left)
                        {
                            _with22.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(22, 2, Width, Height), new StringFormat
                            {
                                Alignment = StringAlignment.Near,
                                LineAlignment = StringAlignment.Near
                            });
                        }
                        else if (_Alignment == Alignments.Center)
                        {
                            _with22.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(0, 0, Width, Height), new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            });
                        }
                        else
                        {
                            _with22.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(0, 0, Width - 5, Height), new StringFormat
                            {
                                Alignment = StringAlignment.Far,
                                LineAlignment = StringAlignment.Center
                            });
                        }
                        _with22.FillRectangle(new SolidBrush(_RectColour), new Rectangle(5, 9, 14, 3));
                        break;
                    case LinesCount.Two:
                        if (_Alignment == Alignments.Left)
                        {
                            _with22.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(22, 2, Width, Height), new StringFormat
                            {
                                Alignment = StringAlignment.Near,
                                LineAlignment = StringAlignment.Near
                            });
                        }
                        else if (_Alignment == Alignments.Center)
                        {
                            _with22.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(0, 0, Width, Height), new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            });
                        }
                        else
                        {
                            _with22.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(0, 0, Width - 22, Height), new StringFormat
                            {
                                Alignment = StringAlignment.Far,
                                LineAlignment = StringAlignment.Center
                            });
                        }
                        _with22.FillRectangle(new SolidBrush(_RectColour), new Rectangle(5, 9, 14, 3));
                        _with22.FillRectangle(new SolidBrush(_RectColour), new Rectangle(Width - 20, 9, 14, 3));
                        break;
                }
            }
            else
            {
                _with22.DrawString(Text, Font, Brushes.White, new Rectangle(5, 2, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near
                });
            }
            if (_ShowBorder)
            {
                _with22.DrawLine(new Pen(_BorderColour, 2), new Point(0, 0), new Point(Width, 0));
            }
            else
            {
            }
            _with22.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}


