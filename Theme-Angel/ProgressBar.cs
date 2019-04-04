// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 08-16-2017
// ***********************************************************************
// <copyright file="Angel Theme.cs" company="Zeroit Dev Technologies">
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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Angel
{

    /// <summary>
    /// Class AngelProgressBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class AngelProgressBar : Control
    {

        #region " Back End "

        #region " Declarations "
        /// <summary>
        /// The v
        /// </summary>
        private int V;
        /// <summary>
        /// The minimum
        /// </summary>
        private int Min = 0;
        #endregion
        /// <summary>
        /// The maximum
        /// </summary>
        private int Max = 100;

        #region " Properties "

        #region " Appearance "

        #endregion

        #region " Behaviour "

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Category("Behavior")]
        public int Value
        {
            get { return V; }
            set
            {
                if (!(value > Max))
                {
                    if (!(value < Min))
                    {
                        V = value;
                        Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [Category("Behavior")]
        public int Minimum
        {
            get { return Min; }
            set
            {
                Min = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [Category("Behavior")]
        public int Maximum
        {
            get { return Max; }
            set
            {
                Max = value;
                Invalidate();
            }
        }
        #endregion

        #endregion

        #region " Misc "

        /// <summary>
        /// Initializes a new instance of the <see cref="AngelProgressBar"/> class.
        /// </summary>
        public AngelProgressBar()
        {
            Size = new Size(150, 40);
        }

        /// <summary>
        /// Increments the specified int.
        /// </summary>
        /// <param name="Int">The int.</param>
        public void Increment(int Int)
        {
            Value += Int;
            Invalidate();
        }

        #endregion

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(10, 25, 38));
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(new LinearGradientBrush(new Point(1, 1), new Point(1, Height - 2), Color.FromArgb(52, 78, 108), Color.FromArgb(22, 45, 67)), new Rectangle(1, 1, (V / Max * Width) - 3, Height - 3));
            G.DrawRectangle(new Pen(Color.FromArgb(70, 103, 143)), new Rectangle(1, 1, Width - 3, Height - 3));
        }

    }
    

}