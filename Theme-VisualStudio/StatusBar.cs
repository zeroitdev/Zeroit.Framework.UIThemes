// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.VisualStudio
{
    public class VisualStudioStatusBar : Control
    {
        #region Variables
        private Color _TextColour = Color.FromArgb(153, 153, 153);
        private Color _BaseColour = Color.FromArgb(45, 45, 48);
        private Color _RectColour = Color.FromArgb(0, 122, 204);
        private Color _BorderColour = Color.FromArgb(27, 27, 29);
        private Color _SeperatorColour = Color.FromArgb(45, 45, 48);
        private bool _ShowLine = true;
        private LinesCount _LinesToShow = LinesCount.One;
        private AmountOfStrings _NumberOfStrings = AmountOfStrings.One;
        private bool _ShowBorder = true;
        private StringFormat _FirstLabelStringFormat;
        private string _FirstLabelText = "Label1";
        private Alignments _FirstLabelAlignment = Alignments.Left;
        private StringFormat _SecondLabelStringFormat;
        private string _SecondLabelText = "Label2";
        private Alignments _SecondLabelAlignment = Alignments.Center;
        private StringFormat _ThirdLabelStringFormat;
        private string _ThirdLabelText = "Label3";
        private Alignments _ThirdLabelAlignment = Alignments.Center;
        #endregion

        #region Properties

        [Category("First Label Options")]
        public string FirstLabelText
        {
            get
            {
                return _FirstLabelText;
            }
            set
            {
                _FirstLabelText = value;
            }
        }

        [Category("First Label Options")]
        public Alignments FirstLabelAlignment
        {
            get
            {
                return _FirstLabelAlignment;
            }
            set
            {
                switch (value)
                {
                    case Alignments.Left:
                        _FirstLabelStringFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                        _FirstLabelAlignment = value;
                        break;
                    case Alignments.Center:
                        _FirstLabelStringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        _FirstLabelAlignment = value;
                        break;
                    case Alignments.Right:
                        _FirstLabelStringFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
                        _FirstLabelAlignment = value;
                        break;
                }
            }
        }

        [Category("Second Label Options")]
        public string SecondLabelText
        {
            get
            {
                return _SecondLabelText;
            }
            set
            {
                _SecondLabelText = value;
            }
        }

        [Category("Second Label Options")]
        public Alignments SecondLabelAlignment
        {
            get
            {
                return _SecondLabelAlignment;
            }
            set
            {
                switch (value)
                {
                    case Alignments.Left:
                        _SecondLabelStringFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                        _SecondLabelAlignment = value;
                        break;
                    case Alignments.Center:
                        _SecondLabelStringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        _SecondLabelAlignment = value;
                        break;
                    case Alignments.Right:
                        _SecondLabelStringFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
                        _SecondLabelAlignment = value;
                        break;
                }
            }
        }

        [Category("Third Label Options")]
        public string ThirdLabelText
        {
            get
            {
                return _ThirdLabelText;
            }
            set
            {
                _ThirdLabelText = value;
            }
        }

        [Category("Third Label Options")]
        public Alignments ThirdLabelAlignment
        {
            get
            {
                return _ThirdLabelAlignment;
            }
            set
            {
                switch (value)
                {
                    case Alignments.Left:
                        _ThirdLabelStringFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                        _ThirdLabelAlignment = value;
                        break;
                    case Alignments.Center:
                        _ThirdLabelStringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        _ThirdLabelAlignment = value;
                        break;
                    case Alignments.Right:
                        _ThirdLabelStringFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
                        _ThirdLabelAlignment = value;
                        break;
                }
            }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get
            {
                return _BaseColour;
            }
            set
            {
                _BaseColour = value;
            }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get
            {
                return _BorderColour;
            }
            set
            {
                _BorderColour = value;
            }
        }

        [Category("Colours")]
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

        public enum LinesCount : int
        {
            None = 0,
            One = 1,
            Two = 2
        }

        public enum AmountOfStrings
        {
            One,
            Two,
            Three
        }

        public enum Alignments
        {
            Left,
            Center,
            Right
        }

        [Category("Control")]
        public AmountOfStrings AmountOfString
        {
            get
            {
                return _NumberOfStrings;
            }
            set
            {
                _NumberOfStrings = value;
            }
        }

        [Category("Control")]
        public LinesCount LinesToShow
        {
            get
            {
                return _LinesToShow;
            }
            set
            {
                _LinesToShow = value;
            }
        }

        public bool ShowBorder
        {
            get
            {
                return _ShowBorder;
            }
            set
            {
                _ShowBorder = value;
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Dock = DockStyle.Bottom;
        }

        [Category("Colours")]
        public Color RectangleColor
        {
            get
            {
                return _RectColour;
            }
            set
            {
                _RectColour = value;
            }
        }

        public bool ShowLine
        {
            get
            {
                return _ShowLine;
            }
            set
            {
                _ShowLine = value;
            }
        }

        #endregion

        #region Draw Control

        public VisualStudioStatusBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9);
            Size = new Size(Width, 20);
            Cursor = Cursors.Arrow;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.FillRectangle(new SolidBrush(BaseColour), Base);
            switch (_LinesToShow)
            {
                case LinesCount.None:
                    if (_NumberOfStrings == AmountOfStrings.One)
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, Width - 5, Height), _FirstLabelStringFormat);
                    }
                    else if (_NumberOfStrings == AmountOfStrings.Two)
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, Convert.ToInt32((Width / 2 - 6)), Height), _FirstLabelStringFormat);
                        G.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32(Width - (Width / 2 + 5)), 1, Convert.ToInt32(Width / 2 - 4), Height), _SecondLabelStringFormat);
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width / 2), 6), new Point(Convert.ToInt32(Width / 2), Height - 6));
                    }
                    else
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, Convert.ToInt32((Width - (Width / 3) * 2) - 6), Height), _FirstLabelStringFormat);
                        G.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32(Width - (Width / 3) * 2 + 5), 1, Convert.ToInt32(Width - (Width / 3) * 2 - 6), Height), _SecondLabelStringFormat);
                        G.DrawString(_ThirdLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32(Width - (Width / 3) + 5), 1, Convert.ToInt32(Width / 3 - 6), Height), _ThirdLabelStringFormat);
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width - (Width / 3) * 2), 6), new Point(Convert.ToInt32(Width - (Width / 3) * 2), Height - 6));
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width - (Width / 3)), 6), new Point(Convert.ToInt32(Width - (Width / 3)), Height - 6));
                    }
                    break;
                case LinesCount.One:
                    if (_NumberOfStrings == AmountOfStrings.One)
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Width, Height), _FirstLabelStringFormat);
                    }
                    else if (_NumberOfStrings == AmountOfStrings.Two)
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Convert.ToInt32((Width / 2 - 24)), Height), _FirstLabelStringFormat);
                        G.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32((Width / 2 + 5)), 1, Convert.ToInt32(Width / 2 - 10), Height), _SecondLabelStringFormat);
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width / 2), 6), new Point(Convert.ToInt32(Width / 2), Height - 6));
                    }
                    else
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Convert.ToInt32((Width - 78) / 3), Height), _FirstLabelStringFormat);
                        G.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32(Width - (Width / 3) * 2 + 5), 1, Convert.ToInt32(Width - (Width / 3) * 2 - 12), Height), _SecondLabelStringFormat);
                        G.DrawString(_ThirdLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32(Width - (Width / 3) + 6), 1, Convert.ToInt32(Width / 3 - 22), Height), _ThirdLabelStringFormat);
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width - (Width / 3) * 2), 6), new Point(Convert.ToInt32(Width - (Width / 3) * 2), Height - 6));
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width - (Width / 3)), 6), new Point(Convert.ToInt32(Width - (Width / 3)), Height - 6));
                    }
                    G.FillRectangle(new SolidBrush(_RectColour), new Rectangle(5, 10, 14, 3));
                    break;
                case LinesCount.Two:
                    if (_NumberOfStrings == AmountOfStrings.One)
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Width - 44, Height), _FirstLabelStringFormat);
                    }
                    else if (_NumberOfStrings == AmountOfStrings.Two)
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Convert.ToInt32((Width - 46) / 2), Height), _FirstLabelStringFormat);
                        G.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32((Width / 2 + 5)), 1, Convert.ToInt32(Width / 2 - 28), Height), _SecondLabelStringFormat);
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width / 2), 6), new Point(Convert.ToInt32(Width / 2), Height - 6));
                    }
                    else
                    {
                        G.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Convert.ToInt32((Width - 78) / 3), Height), _FirstLabelStringFormat);
                        G.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32(Width - (Width / 3) * 2 + 5), 1, Convert.ToInt32(Width - (Width / 3) * 2 - 12), Height), _SecondLabelStringFormat);
                        G.DrawString(_ThirdLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32(Width - (Width / 3) + 6), 1, Convert.ToInt32(Width / 3 - 22), Height), _ThirdLabelStringFormat);
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width - (Width / 3) * 2), 6), new Point(Convert.ToInt32(Width - (Width / 3) * 2), Height - 6));
                        G.DrawLine(new Pen(_SeperatorColour, 1F), new Point(Convert.ToInt32(Width - (Width / 3)), 6), new Point(Convert.ToInt32(Width - (Width / 3)), Height - 6));
                    }
                    G.FillRectangle(new SolidBrush(_SeperatorColour), new Rectangle(5, 10, 14, 3));
                    G.FillRectangle(new SolidBrush(_SeperatorColour), new Rectangle(Width - 20, 10, 14, 3));
                    break;
            }
            if (_ShowBorder)
            {
                G.DrawRectangle(new Pen(_BorderColour, 2F), new Rectangle(0, 0, Width, Height));
            }
            else
            {
            }
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}
