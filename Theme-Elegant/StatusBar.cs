// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="StatusBar.cs" company="Zeroit Dev Technologies">
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

    public class ElegantThemeStatusBar : Control
    {

        #region "Variables"
        private Color _BaseColour = Color.FromArgb(240, 242, 241);
        private Color _BorderColour = Color.FromArgb(183, 210, 166);
        private Color _TextColour = Color.FromArgb(120, 120, 120);
        private Color _RectColour = Color.FromArgb(21, 117, 149);
        private Color _SeperatorColour = Color.FromArgb(110, 110, 110);
        private bool _ShowLine = true;
        private LinesCount _LinesToShow = LinesCount.One;
        private AmountOfStrings _NumberOfStrings = AmountOfStrings.One;
        private bool _ShowBorder = true;
        private StringFormat _FirstLabelStringFormat;
        private string _FirstLabelText = "Label1";
        private Alignments _FirstLabelAlignment = Alignments.Center;
        private StringFormat _SecondLabelStringFormat;
        private string _SecondLabelText = "Label2";
        private Alignments _SecondLabelAlignment = Alignments.Center;
        private StringFormat _ThirdLabelStringFormat;
        private string _ThirdLabelText = "Label3";
        #endregion
        private Alignments _ThirdLabelAlignment = Alignments.Center;

        #region "Properties"

        [Category("First Label Options")]
        public string FirstLabelText
        {
            get { return _FirstLabelText; }
            set { _FirstLabelText = value; }
        }

        [Category("First Label Options")]
        public Alignments FirstLabelAlignment
        {
            get { return _FirstLabelAlignment; }
            set
            {
                switch (value)
                {
                    case Alignments.Left:
                        _FirstLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Center
                        };
                        _FirstLabelAlignment = value;
                        break;
                    case Alignments.Center:
                        _FirstLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        _FirstLabelAlignment = value;
                        break;
                    case Alignments.Right:
                        _FirstLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        };
                        _FirstLabelAlignment = value;
                        break;
                }
            }
        }

        [Category("Second Label Options")]
        public string SecondLabelText
        {
            get { return _SecondLabelText; }
            set { _SecondLabelText = value; }
        }

        [Category("Second Label Options")]
        public Alignments SecondLabelAlignment
        {
            get { return _SecondLabelAlignment; }
            set
            {
                switch (value)
                {
                    case Alignments.Left:
                        _SecondLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Center
                        };
                        _SecondLabelAlignment = value;
                        break;
                    case Alignments.Center:
                        _SecondLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        _SecondLabelAlignment = value;
                        break;
                    case Alignments.Right:
                        _SecondLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        };
                        _SecondLabelAlignment = value;
                        break;
                }
            }
        }

        [Category("Third Label Options")]
        public string ThirdLabelText
        {
            get { return _ThirdLabelText; }
            set { _ThirdLabelText = value; }
        }

        [Category("Third Label Options")]
        public Alignments ThirdLabelAlignment
        {
            get { return _ThirdLabelAlignment; }
            set
            {
                switch (value)
                {
                    case Alignments.Left:
                        _ThirdLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Center
                        };
                        _ThirdLabelAlignment = value;
                        break;
                    case Alignments.Center:
                        _ThirdLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        _ThirdLabelAlignment = value;
                        break;
                    case Alignments.Right:
                        _ThirdLabelStringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        };
                        _ThirdLabelAlignment = value;
                        break;
                }
            }
        }

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
            get { return _NumberOfStrings; }
            set { _NumberOfStrings = value; }
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

        public ElegantThemeStatusBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9);
            ForeColor = Color.White;
            Size = new Size(Width, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with9 = G;
            _with9.SmoothingMode = SmoothingMode.HighQuality;
            _with9.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with9.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with9.Clear(BaseColour);
            _with9.FillRectangle(new SolidBrush(BaseColour), Base);
            switch (_LinesToShow)
            {
                case LinesCount.None:
                    if (_NumberOfStrings == AmountOfStrings.One)
                    {
                        _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, Width - 5, Height), _FirstLabelStringFormat);
                    }
                    else if (_NumberOfStrings == AmountOfStrings.Two)
                    {
                        _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, (Width / 2 - 6), Height), _FirstLabelStringFormat);
                        _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 2 + 5), 1, Width / 2 - 4, Height), _SecondLabelStringFormat);
                        _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width / 2, 6), new Point(Width / 2, Height - 6));
                    }
                    else
                    {
                        _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, (Width - (Width / 3) * 2) - 6, Height), _FirstLabelStringFormat);
                        _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 3) * 2 + 5, 1, Width - (Width / 3) * 2 - 6, Height), _SecondLabelStringFormat);
                        _with9.DrawString(_ThirdLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 3) + 5, 1, Width / 3 - 6, Height), _ThirdLabelStringFormat);
                        _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width - (Width / 3) * 2, 6), new Point(Width - (Width / 3) * 2, Height - 6));
                        _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width - (Width / 3), 6), new Point(Width - (Width / 3), Height - 6));
                    }
                    break;
                case LinesCount.One:
                    if (_NumberOfStrings == AmountOfStrings.One)
                    {
                        _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Width, Height), _FirstLabelStringFormat);
                        _with9.FillRectangle(new SolidBrush(_RectColour), new Rectangle(5, 9, 14, 3));
                    }
                    else if (_NumberOfStrings == AmountOfStrings.Two)
                    {
                        _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, (Width / 2 - 24), Height), _FirstLabelStringFormat);
                        _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle((Width / 2 + 5), 1, Width / 2 - 10, Height), _SecondLabelStringFormat);
                        _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width / 2, 6), new Point(Width / 2, Height - 6));
                    }
                    else
                    {
                    }
                    _with9.FillRectangle(new SolidBrush(_SeperatorColour), new Rectangle(5, 10, 14, 3));
                    break;
                case LinesCount.Two:
                    if (_NumberOfStrings == AmountOfStrings.One)
                    {
                        _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Width - 44, Height), _FirstLabelStringFormat);
                    }
                    else if (_NumberOfStrings == AmountOfStrings.Two)
                    {
                        _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, (Width - 46) / 2, Height), _FirstLabelStringFormat);
                        _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle((Width / 2 + 5), 1, Width / 2 - 28, Height), _SecondLabelStringFormat);
                        _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width / 2, 6), new Point(Width / 2, Height - 6));
                    }
                    else
                    {
                        _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, (Width - 78) / 3, Height), _FirstLabelStringFormat);
                        _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 3) * 2 + 5, 1, Width - (Width / 3) * 2 - 12, Height), _SecondLabelStringFormat);
                        _with9.DrawString(_ThirdLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 3) + 6, 1, Width / 3 - 22, Height), _ThirdLabelStringFormat);
                        _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width - (Width / 3) * 2, 6), new Point(Width - (Width / 3) * 2, Height - 6));
                        _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width - (Width / 3), 6), new Point(Width - (Width / 3), Height - 6));

                    }
                    _with9.FillRectangle(new SolidBrush(_SeperatorColour), new Rectangle(5, 10, 14, 3));
                    _with9.FillRectangle(new SolidBrush(_SeperatorColour), new Rectangle(Width - 20, 10, 14, 3));
                    break;
            }
            if (_ShowBorder)
            {
                _with9.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
            }
            else
            {
            }
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }


}


