// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Meph
{

    [DefaultEvent("CheckedChanged")]
    public class MephRadioButton : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        private Rectangle R1;

        private LinearGradientBrush G1;
        private MouseState State = MouseState.None;
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
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 24;
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }
        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InvalidateControls();
        }
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is MephRadioButton)
                {
                    ((MephRadioButton)C).Checked = false;
                }
            }
        }

        private Color _accentColor;
        public Color AccentColor
        {
            get { return _accentColor; }
            set
            {
                _accentColor = value;
                Invalidate();
            }
        }
        #endregion

        public MephRadioButton() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
            Size = new Size(150, 24);
            _accentColor = Color.Maroon;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle radioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);
            Rectangle InnerRect = new Rectangle(5, 5, Height - 11, Height - 11);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            G.Clear(BackColor);

            LinearGradientBrush bgGrad = new LinearGradientBrush(radioBtnRectangle, Color.FromArgb(50, 50, 50), Color.FromArgb(40, 40, 40), 90);
            G.FillEllipse(bgGrad, radioBtnRectangle);
            G.DrawEllipse(new Pen(Color.FromArgb(20, 20, 20)), radioBtnRectangle);
            G.DrawEllipse(new Pen(Color.FromArgb(55, 55, 55)), new Rectangle(1, 1, Height - 3, Height - 3));

            if (Checked)
            {
                LinearGradientBrush fillGradient = new LinearGradientBrush(InnerRect, _accentColor, Color.FromArgb(_accentColor.R + 5, _accentColor.G + 5, _accentColor.B + 5), 90);
                G.FillEllipse(fillGradient, InnerRect);
                G.DrawEllipse(new Pen(Color.FromArgb(25, 25, 25)), InnerRect);
            }

            Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);
            Brush nb = new SolidBrush(Color.FromArgb(200, 200, 200));
            G.DrawString(Text, drawFont, nb, new Point(28, 12), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }

}


