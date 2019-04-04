// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Facebook
{
    public class FacebookComboBox : ComboBox
    {

        #region "Declarations"
        private int _StartIndex = 0;
        private Color _BorderColour = Color.FromArgb(73, 185, 213);
        private Color _BaseColour = Color.White;
        #endregion
        private Color _FontColour = Color.FromArgb(50, 50, 50);

        #region "Properties & Events"

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

        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Rectangle Rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 1, e.Bounds.Height + 1);
            try
            {
                var _with12 = e.Graphics;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    _with12.FillRectangle(Brushes.LightSteelBlue, Rect);
                    _with12.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(_FontColour), 1, e.Bounds.Top + 2);
                }
                else
                {
                    _with12.FillRectangle(new SolidBrush(Color.White), Rect);
                    _with12.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(_FontColour), 1, e.Bounds.Top + 2);
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
            this.Invalidate();

        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.Invalidate();
            base.OnMouseClick(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.Invalidate();
            base.OnMouseUp(e);
        }

        #endregion

        #region "Draw Control"

        public FacebookComboBox()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            this.Width = 163;
            Font = new Font("Segoe UI", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            dynamic G = Graphics.FromImage(B);
            var _with13 = G;
            _with13.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with13.SmoothingMode = SmoothingMode.HighQuality;
            _with13.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with13.Clear(BackColor);
            try
            {
                Rectangle Square = new Rectangle(Width - 22, 0, Width, Height);
                _with13.FillRectangle(new SolidBrush(Color.FromArgb(237, 237, 237)), Square);
                _with13.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width - 22, Height));
                _with13.DrawLine(new Pen(_BorderColour), new Point(Width - 23, 0), new Point(Width - 23, Height));
                try
                {
                    _with13.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(3, 0, Width - 20, Height), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
                catch
                {
                }
                _with13.DrawLine(new Pen(_BorderColour), 0, 0, 0, 0);
                _with13.DrawRectangle(new Pen(_BorderColour), new Rectangle(0, 0, Width, Height));
                Point[] P = {
                new Point(Width - 18, 9),
                new Point(Width - 12, 18),
                new Point(Width - 6, 9)
            };
                _with13.FillPolygon(new SolidBrush(_BorderColour), P);
                _with13.DrawPolygon(new Pen(Color.Gainsboro), P);
            }
            catch
            {
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

