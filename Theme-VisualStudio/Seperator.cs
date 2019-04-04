// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    public class VisualStudioSeperator : Control
    {
        #region Declarations
        private Color _FontColour = Color.FromArgb(153, 153, 153);
        private Color _LineColour = Color.FromArgb(0, 122, 204);
        private Font _Font = new Font("Microsoft Sans Serif", 8);
        private bool _ShowText;
        private StringAlignment _TextAlignment = StringAlignment.Center;
        private __TextLocation _TextLocation = __TextLocation.Left;
        private bool _AddEndNotch = false;
        private bool _UnderlineText = false;
        private bool _ShowTextAboveLine = false;
        private bool _OnlyUnderlineText = false;
        #endregion

        #region Properties

        [Category("Control")]
        public __TextLocation TextLocation
        {
            get
            {
                return _TextLocation;
            }
            set
            {
                _TextLocation = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public StringAlignment TextAlignment
        {
            get
            {
                return _TextAlignment;
            }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool ShowTextAboveLine
        {
            get
            {
                return _ShowTextAboveLine;
            }
            set
            {
                _ShowTextAboveLine = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool OnlyUnderlineText
        {
            get
            {
                return _OnlyUnderlineText;
            }
            set
            {
                _OnlyUnderlineText = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool UnderlineText
        {
            get
            {
                return _UnderlineText;
            }
            set
            {
                _UnderlineText = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool AddEndNotch
        {
            get
            {
                return _AddEndNotch;
            }
            set
            {
                _AddEndNotch = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool ShowText
        {
            get
            {
                return _ShowText;
            }
            set
            {
                _ShowText = value;
                Invalidate();
            }
        }

        [Category("Colours")]
        public Color LineColour
        {
            get
            {
                return _LineColour;
            }
            set
            {
                _LineColour = value;
            }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get
            {
                return _FontColour;
            }
            set
            {
                _FontColour = value;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_ShowText && (Height < Font.Size * 2 + 3))
            {
                this.Size = new Size(Width, Convert.ToInt32(Font.Size * 2 + 3));
            }
            Invalidate();
        }

        public enum __TextLocation
        {
            Left,
            Middle,
            Right
        }

        #endregion

        #region Draw Control

        public VisualStudioSeperator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            if (_ShowText && !_ShowTextAboveLine)
            {
                switch (_TextLocation)
                {
                    case __TextLocation.Left:
                        G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(0, 0, Convert.ToInt32(G.MeasureString(Text, Font).Width + 10), Height), new StringFormat { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                        G.DrawLine(new Pen(_LineColour), new Point(Convert.ToInt32(G.MeasureString(Text, Font).Width + 20), Convert.ToInt32(Height / 2)), new Point(Convert.ToInt32(Width), Convert.ToInt32(Height / 2)));
                        if (_AddEndNotch)
                        {
                            G.DrawLine(new Pen(_LineColour), new Point(Width - 1, Convert.ToInt32((Height / 2) - G.MeasureString(Text, Font).Height / 2.0)), new Point(Width - 1, Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0)));
                        }
                        if (_UnderlineText)
                        {
                            G.DrawLine(new Pen(_LineColour), 0, Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3, Convert.ToInt32(G.MeasureString(Text, Font).Width + 20), Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3);
                            G.DrawLine(new Pen(_LineColour), Convert.ToInt32(G.MeasureString(Text, Font).Width + 20), Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3, Convert.ToInt32(G.MeasureString(Text, Font).Width + 20), Convert.ToInt32(Height / 2));
                        }
                        break;
                    case __TextLocation.Middle:
                        G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(Convert.ToInt32((Width / 2) - (G.MeasureString(Text, Font).Width / 2.0) - 10), 0, Convert.ToInt32(G.MeasureString(Text, Font).Width) + 10, Height), new StringFormat { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                        G.DrawLine(new Pen(_LineColour), new Point(0, Convert.ToInt32(Height / 2)), new Point((Convert.ToInt32((Width / 2) - (G.MeasureString(Text, Font).Width / 2.0) - 20)), Convert.ToInt32(Height / 2)));
                        G.DrawLine(new Pen(_LineColour), new Point((Convert.ToInt32((Width / 2) + (G.MeasureString(Text, Font).Width / 2.0) + 10)), Convert.ToInt32(Height / 2)), new Point(Width, Convert.ToInt32(Height / 2)));
                        if (_AddEndNotch)
                        {
                            G.DrawLine(new Pen(_LineColour), new Point(Width - 1, Convert.ToInt32((Height / 2) - G.MeasureString(Text, Font).Height / 2.0)), new Point(Width - 1, Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0)));
                            G.DrawLine(new Pen(_LineColour), new Point(1, Convert.ToInt32((Height / 2) - G.MeasureString(Text, Font).Height / 2.0)), new Point(1, Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0)));
                        }
                        if (_UnderlineText)
                        {
                            G.DrawLine(new Pen(_LineColour), (Convert.ToInt32((Width / 2) - (G.MeasureString(Text, Font).Width / 2.0) - 20)), Convert.ToInt32(Height / 2), (Convert.ToInt32((Width / 2) - (G.MeasureString(Text, Font).Width / 2.0) - 20)), Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3);
                            G.DrawLine(new Pen(_LineColour), (Convert.ToInt32((Width / 2) + (G.MeasureString(Text, Font).Width / 2.0) + 10)), Convert.ToInt32(Height / 2), (Convert.ToInt32((Width / 2) + (G.MeasureString(Text, Font).Width / 2.0) + 10)), Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3);
                            G.DrawLine(new Pen(_LineColour), (Convert.ToInt32((Width / 2) - (G.MeasureString(Text, Font).Width / 2.0) - 20)), Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3, (Convert.ToInt32((Width / 2) + (G.MeasureString(Text, Font).Width / 2.0) + 10)), Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3);
                        }
                        break;
                    case __TextLocation.Right:
                        G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(Convert.ToInt32(Width - G.MeasureString(Text, Font).Width - 10), 0, Convert.ToInt32(G.MeasureString(Text, Font).Width + 10), Height), new StringFormat { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                        G.DrawLine(new Pen(_LineColour), new Point(0, Convert.ToInt32(Height / 2)), new Point(Convert.ToInt32(Width - G.MeasureString(Text, Font).Width - 20), Convert.ToInt32(Height / 2)));
                        if (_AddEndNotch)
                        {
                            G.DrawLine(new Pen(_LineColour), new Point(1, Convert.ToInt32((Height / 2) - G.MeasureString(Text, Font).Height / 2.0)), new Point(1, Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0)));
                        }
                        if (_UnderlineText)
                        {
                            G.DrawLine(new Pen(_LineColour), Convert.ToInt32(Width - G.MeasureString(Text, Font).Width - 20), Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3, Width, Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3);
                            G.DrawLine(new Pen(_LineColour), Convert.ToInt32(Width - G.MeasureString(Text, Font).Width - 20), Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0) + 3, Convert.ToInt32(Width - G.MeasureString(Text, Font).Width - 20), Convert.ToInt32(Height / 2));
                        }
                        break;
                }
            }
            else if ((_ShowText) && (_ShowTextAboveLine))
            {
                if (_OnlyUnderlineText)
                {
                    G.DrawLine(new Pen(_LineColour), new Point(5, Convert.ToInt32(Height / 2) + 6), new Point(Convert.ToInt32(G.MeasureString(Text, Font).Width + 8), Convert.ToInt32(Height / 2) + 6));
                    G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(5, 0, Width - 10, Convert.ToInt32(Height / 2 + 3)), new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far });
                }
                else
                {
                    G.DrawLine(new Pen(_LineColour), new Point(0, Convert.ToInt32(Height / 2) + 6), new Point(Width, Convert.ToInt32(Height / 2) + 6));
                    if (_AddEndNotch)
                    {
                        G.DrawLine(new Pen(_LineColour), new Point(Width - 1, Convert.ToInt32(Height / 2) - 5), new Point(Width - 1, Convert.ToInt32((Height / 2) + 5)));
                        G.DrawLine(new Pen(_LineColour), new Point(1, Convert.ToInt32(Height / 2) - 5), new Point(1, Convert.ToInt32((Height / 2) + 5)));
                    }
                    G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(5, 0, Width - 10, Convert.ToInt32(Height / 2 + 3)), new StringFormat { Alignment = _TextAlignment, LineAlignment = StringAlignment.Far });
                }
            }
            else
            {
                if (_OnlyUnderlineText)
                {
                    G.DrawLine(new Pen(_LineColour), new Point(5, Convert.ToInt32(Height / 2) + 6), new Point(Convert.ToInt32(G.MeasureString(Text, Font).Width + 8), Convert.ToInt32(Height / 2) + 6));
                    G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(5, 0, Width - 10, Convert.ToInt32(Height / 2 + 3)), new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far });
                }
                else
                {
                    G.DrawLine(new Pen(_LineColour), new Point(0, Convert.ToInt32(Height / 2)), new Point(Width, Convert.ToInt32(Height / 2)));
                    if (_AddEndNotch)
                    {
                        G.DrawLine(new Pen(_LineColour), new Point(Width - 1, Convert.ToInt32((Height / 2) - G.MeasureString(Text, Font).Height / 2.0)), new Point(Width - 1, Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0)));
                        G.DrawLine(new Pen(_LineColour), new Point(1, Convert.ToInt32((Height / 2) - G.MeasureString(Text, Font).Height / 2.0)), new Point(1, Convert.ToInt32((Height / 2) + G.MeasureString(Text, Font).Height / 2.0)));
                    }
                }
            }
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}
