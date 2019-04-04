// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 08-12-2017
// ***********************************************************************
// <copyright file="Aresio Theme.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Aresio
{

    /// <summary>
    /// Class AresioTrackBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class AresioTrackBar : Control
    {

        #region "Properties"
        /// <summary>
        /// The maximum
        /// </summary>
        int _Maximum = 10;
        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value > 0)
                    _Maximum = value;
                if (value < _Value)
                    _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;
        /// <summary>
        /// Delegate ValueChangedEventHandler
        /// </summary>
        public delegate void ValueChangedEventHandler();
        /// <summary>
        /// The value
        /// </summary>
        int _Value = 0;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get { return _Value; }

            set
            {

                if (value == _Value)
                {
                    return;
                }

                else if (value == 0)
                {
                    _Value = 0;
                }

                else if (value == _Maximum)
                {
                    _Value = _Maximum;
                }

                else
                {
                    _Value = value;
                }

                #region Old Code
                //            switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : Equality
                //_Value:
                //					return;

                //					break;
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //0:
                //					_Value = 0;
                //					break;
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					_Value = _Maximum;
                //					break;
                //				default:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                Invalidate();
                if (ValueChanged != null)
                {
                    ValueChanged();
                }
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AresioTrackBar"/> class.
        /// </summary>
        public AresioTrackBar()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// The capture m
        /// </summary>
        bool CaptureM = false;
        /// <summary>
        /// The bar
        /// </summary>
        Rectangle Bar;

        /// <summary>
        /// The track
        /// </summary>
        Size Track = new Size(20, 20);
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Bar = new Rectangle(0, 10, Width - 1, Height - 21);

            Graphics G = e.Graphics;
            Bar = new Rectangle(10, 10, Width - 21, Height - 21);
            G.Clear(Parent.FindForm().BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            //Background
            LinearGradientBrush BackLinear = new LinearGradientBrush(new Point(0, Convert.ToInt32((Height / 2) - 4)), new Point(0, Convert.ToInt32((Height / 2) + 4)), Color.FromArgb(50, Color.Black), Color.Transparent);
            G.FillPath(BackLinear, DesignFunctions.RoundRect(0, Convert.ToInt32((Height / 2) - 4), Width - 1, 8, 3));
            G.DrawPath(DesignFunctions.ToPen(50, Color.Black), DesignFunctions.RoundRect(0, Convert.ToInt32((Height / 2) - 4), Width - 1, 8, 3));
            BackLinear.Dispose();


            //Fill
            G.FillPath(new LinearGradientBrush(new Point(1, Convert.ToInt32((Height / 2) - 4)), new Point(1, Convert.ToInt32((Height / 2) + 4)), Color.FromArgb(250, 200, 70), Color.FromArgb(250, 160, 40)), DesignFunctions.RoundRect(1, Convert.ToInt32((Height / 2) - 4), Convert.ToInt32(Bar.Width * (Value / Maximum)) + Convert.ToInt32(Track.Width / 2), 8, 3));
            G.DrawPath(DesignFunctions.ToPen(100, Color.White), DesignFunctions.RoundRect(2, Convert.ToInt32((Height / 2) - 2), Convert.ToInt32(Bar.Width * (Value / Maximum)) + Convert.ToInt32(Track.Width / 2), 4, 3));
            G.SetClip(DesignFunctions.RoundRect(1, Convert.ToInt32((Height / 2) - 4), Convert.ToInt32(Bar.Width * (Value / Maximum)) + Convert.ToInt32(Track.Width / 2), 8, 3));
            for (int i = 0; i <= Convert.ToInt32(Bar.Width * (Value / Maximum)) + Convert.ToInt32(Track.Width / 2); i += 10)
            {
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(20, Color.Black)), 4), new Point(i, Convert.ToInt32((Height / 2) - 10)), new Point(i - 10, Convert.ToInt32((Height / 2) + 10)));
            }
            G.SetClip(new Rectangle(0, 0, Width, Height));

            //Button
            G.FillEllipse(Brushes.White, Bar.X + Convert.ToInt32(Bar.Width * (Value / Maximum)) - Convert.ToInt32(Track.Width / 2), Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width, Track.Height);
            G.DrawEllipse(DesignFunctions.ToPen(50, Color.Black), Bar.X + Convert.ToInt32(Bar.Width * (Value / Maximum)) - Convert.ToInt32(Track.Width / 2), Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width, Track.Height);
            G.FillEllipse(new LinearGradientBrush(new Point(0, Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2)), new Point(0, Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2) + Track.Height), Color.FromArgb(200, Color.Black), Color.FromArgb(100, Color.Black)), new Rectangle(Bar.X + Convert.ToInt32(Bar.Width * (Value / Maximum)) - Convert.ToInt32(Track.Width / 2) + 6, Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2) + 6, Track.Width - 12, Track.Height - 12));

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(System.EventArgs e)
        {
            this.BackColor = Color.Transparent;

            base.OnHandleCreated(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            dynamic mp = new Rectangle(new Point(e.Location.X, e.Location.Y), new Size(1, 1));
            Rectangle Bar = new Rectangle(10, 10, Width - 21, Height - 21);
            if (new Rectangle(new Point(Bar.X + Convert.ToInt32(Bar.Width * (Value / Maximum)) - Convert.ToInt32(Track.Width / 2), 0), new Size(Track.Width, Height)).IntersectsWith(mp))
            {
                CaptureM = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CaptureM = false;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (CaptureM)
            {
                Point mp = new Point(e.X, e.Y);
                Rectangle Bar = new Rectangle(10, 10, Width - 21, Height - 21);
                Value = Convert.ToInt32(Maximum * ((mp.X - Bar.X) / Bar.Width));
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            CaptureM = false;
        }

    }

    
}