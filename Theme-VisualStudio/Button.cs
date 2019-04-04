// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
    public class VisualStudioButton : Control
    {
        #region Declarations
        private MouseState State = MouseState.None;
        private Color _FontColour = Color.FromArgb(153, 153, 153);
        private Color _BaseColour = Color.FromArgb(45, 45, 48);
        private Color _IconColour = Color.FromArgb(255, 255, 255);
        private Color _BorderColour = Color.FromArgb(15, 15, 18);
        private Color _HoverColour = Color.FromArgb(60, 60, 62);
        private Color _PressedColour = Color.FromArgb(37, 37, 39);
        private bool _ShowBorder = true;
        private bool _ShowImage = false;
        private bool _ShowText;
        private Image _Image = null;
        private StringAlignment _TextAlignment = StringAlignment.Center;
        private __ImageAlignment _ImageAlignment = __ImageAlignment.Left;
        #endregion

        #region Properties

        public enum __ImageAlignment
        {
            Left,
            Middle,
            Right
        }

        [Category("Control")]
        public __ImageAlignment ImageAlignment
        {
            get
            {
                return _ImageAlignment;
            }
            set
            {
                if (_ShowText && (value == __ImageAlignment.Middle))
                {
                    _ImageAlignment = __ImageAlignment.Left;
                }
                else
                {
                    _ImageAlignment = value;
                }
                Invalidate();
            }
        }

        [Category("Control")]
        public Image ImageChoice
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
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
        public bool ShowImage
        {
            get
            {
                return _ShowImage;
            }
            set
            {
                _ShowImage = value;
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
                if ((_ImageAlignment == __ImageAlignment.Middle) && (ShowImage == true) && (value == true))
                {
                    _ImageAlignment = __ImageAlignment.Left;
                }
                _ShowText = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool ShowBorder
        {
            get
            {
                return _ShowBorder;
            }
            set
            {
                _ShowBorder = value;
                Invalidate();
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
        public Color HoverColour
        {
            get
            {
                return _HoverColour;
            }
            set
            {
                _HoverColour = value;
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

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }

        #endregion

        #region Draw Control

        public VisualStudioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = _BaseColour;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            switch (State)
            {
                case MouseState.None:
                    G.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(0, 0, Width, Height));
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(_PressedColour), new Rectangle(0, 0, Width, Height));
                    break;
            }
            if (_ShowBorder)
            {
                G.DrawRectangle(new Pen(_BorderColour, 1F), new Rectangle(0, 0, Width, Height));
            }
            if (_ShowImage)
            {
                if (_ShowText)
                {
                    if ((Width > 50) && (Height > 30))
                    {
                        if (_ImageAlignment == __ImageAlignment.Left)
                        {
                            G.DrawImage(_Image, new Rectangle(10, 10, Height - 20, Height - 20));
                            G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(0 + (Height - 5), 0, (Width - 20) - (Height - 10), Height), new StringFormat { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                        }
                        else if (_ImageAlignment == __ImageAlignment.Right)
                        {
                            G.DrawImage(_Image, new Rectangle((Width - 20) - (Height - 20), 10, Height - 20, Height - 20));
                            G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(10, 0, (Width - 20) - (Height - 20), Height), new StringFormat { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                        }
                    }
                    else
                    {
                        G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(10, 0, Width - 20, Height), new StringFormat { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                    }
                }
                else
                {
                    if (_ImageAlignment == __ImageAlignment.Left)
                    {
                        G.DrawImage(_Image, new Rectangle(10, 10, Height - 20, Height - 20));
                    }
                    else if (_ImageAlignment == __ImageAlignment.Middle)
                    {
                        G.DrawImage(_Image, new Rectangle(Convert.ToInt32((Width / 2) - ((Height - 20) / 2)), 10, Height - 20, Height - 20));
                    }
                    else
                    {
                        G.DrawImage(_Image, new Rectangle((Width - 10) - (Height - 20), 10, Height - 20, Height - 20));
                    }
                }
            }
            else
            {
                if (_ShowText)
                {
                    G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(10, 0, Width - 20, Height), new StringFormat { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                }
            }
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}
