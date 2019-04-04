// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using static Zeroit.Framework.UIThemes.Login.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInComboBox : ComboBox
    {

        #region "Declarations"
        private int _StartIndex = 0;
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _FontColour = Color.FromArgb(255, 255, 255);
        private Color _LineColour = Color.FromArgb(23, 119, 151);
        private Color _SqaureColour = Color.FromArgb(47, 47, 47);
        private Color _ArrowColour = Color.FromArgb(30, 30, 30);
        private Color _SqaureHoverColour = Color.FromArgb(52, 52, 52);
        #endregion
        private MouseState State = MouseState.None;

        #region "Properties & Events"

        [Category("Colours")]
        public Color LineColour
        {
            get { return _LineColour; }
            set { _LineColour = value; }
        }

        [Category("Colours")]
        public Color SqaureColour
        {
            get { return _SqaureColour; }
            set { _SqaureColour = value; }
        }

        [Category("Colours")]
        public Color ArrowColour
        {
            get { return _ArrowColour; }
            set { _ArrowColour = value; }
        }

        [Category("Colours")]
        public Color SqaureHoverColour
        {
            get { return _SqaureHoverColour; }
            set { _SqaureHoverColour = value; }
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

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        public int StartIndex
        {
            get { return _StartIndex; }
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Invalidate();
            OnMouseClick(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseUp(e);
        }

        #endregion

        #region "Draw Control"

        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Rectangle Rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 1, e.Bounds.Height + 1);
            try
            {
                var _with24 = e.Graphics;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    _with24.FillRectangle(new SolidBrush(_SqaureColour), Rect);
                    _with24.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(_FontColour), 1, e.Bounds.Top + 2);
                }
                else
                {
                    _with24.FillRectangle(new SolidBrush(_BaseColour), Rect);
                    _with24.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(_FontColour), 1, e.Bounds.Top + 2);
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
            Invalidate();

        }

        public LogInComboBox()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Width = 163;
            Font = new Font("Segoe UI", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var _with25 = g;
            _with25.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with25.SmoothingMode = SmoothingMode.HighQuality;
            _with25.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with25.Clear(BackColor);
            try
            {
                Rectangle Square = new Rectangle(Width - 25, 0, Width, Height);
                _with25.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width - 25, Height));
                switch (State)
                {
                    case MouseState.None:
                        _with25.FillRectangle(new SolidBrush(_SqaureColour), Square);
                        break;
                    case MouseState.Over:
                        _with25.FillRectangle(new SolidBrush(_SqaureHoverColour), Square);
                        break;
                }
                _with25.DrawLine(new Pen(_LineColour, 2), new Point(Width - 26, 1), new Point(Width - 26, Height - 1));
                try
                {
                    _with25.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(3, 0, Width - 20, Height), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
                catch
                {
                }
                _with25.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
                Point[] P = {
                new Point(Width - 17, 11),
                new Point(Width - 13, 5),
                new Point(Width - 9, 11)
            };
                _with25.FillPolygon(new SolidBrush(_BorderColour), P);
                _with25.DrawPolygon(new Pen(_ArrowColour), P);
                Point[] P1 = {
                new Point(Width - 17, 15),
                new Point(Width - 13, 21),
                new Point(Width - 9, 15)
            };
                _with25.FillPolygon(new SolidBrush(_BorderColour), P1);
                _with25.DrawPolygon(new Pen(_ArrowColour), P1);
            }
            catch
            {
            }
            _with25.InterpolationMode = (InterpolationMode)7;

        }

        #endregion

    }

}


