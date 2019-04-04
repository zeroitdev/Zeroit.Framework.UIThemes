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
    /// Class AresioProgressBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class AresioProgressBar : Control
    {

        #region " Properties "

        /// <summary>
        /// The minimum
        /// </summary>
        private int _minimum;
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;

                if (value > _maximum)
                    _maximum = value;
                if (value > _value)
                    _value = value;

                Invalidate();
            }
        }

        /// <summary>
        /// The maximum
        /// </summary>
        private int _maximum;
        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;

                if (value < _minimum)
                    _minimum = value;
                if (value < _value)
                    _value = value;

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
        private int _value;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < _minimum)
                {
                    _value = _minimum;
                }
                else if (value > _maximum)
                {
                    _value = _maximum;
                }
                else
                {
                    _value = value;
                }

                Invalidate();
                if (ValueChanged != null)
                {
                    ValueChanged();
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AresioProgressBar"/> class.
        /// </summary>
        public AresioProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            _maximum = 100;
            _minimum = 0;
            _value = 0;
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            G.Clear(Parent.FindForm().BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            //Background
            LinearGradientBrush BackLinear = new LinearGradientBrush(new Point(0, Convert.ToInt32((Height / 2) - 4)), new Point(0, Convert.ToInt32((Height / 2) + 4)), Color.FromArgb(50, Color.Black), Color.Transparent);
            G.FillPath(BackLinear, DesignFunctions.RoundRect(0, Convert.ToInt32((Height / 2) - 4), Width - 1, 8, 3));
            G.DrawPath(DesignFunctions.ToPen(50, Color.Black), DesignFunctions.RoundRect(0, Convert.ToInt32((Height / 2) - 4), Width - 1, 8, 3));
            BackLinear.Dispose();

            //Fill
            if (_value > 0)
            {
                G.FillPath(new LinearGradientBrush(new Point(1, Convert.ToInt32((Height / 2) - 4)), new Point(1, Convert.ToInt32((Height / 2) + 4)), Color.FromArgb(250, 200, 70), Color.FromArgb(250, 160, 40)), DesignFunctions.RoundRect(1, Convert.ToInt32((Height / 2) - 4), Convert.ToInt32((Width - 2) * (Value / Maximum)), 8, 3));
                G.DrawPath(DesignFunctions.ToPen(100, Color.White), DesignFunctions.RoundRect(2, Convert.ToInt32((Height / 2) - 2), Convert.ToInt32((Width - 4) * (Value / Maximum)), 4, 3));
            }
        }
    }

    
}