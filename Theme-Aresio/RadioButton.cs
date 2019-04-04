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

using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Aresio
{

    /// <summary>
    /// Class AresioRadioButton.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class AresioRadioButton : Control
    {

        /// <summary>
        /// Occurs when [checked changed].
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;
        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        public delegate void CheckedChangedEventHandler();
        /// <summary>
        /// The checked
        /// </summary>
        private bool _checked;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AresioRadioButton"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;

                Invalidate();
                if (CheckedChanged != null)
                {
                    CheckedChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AresioRadioButton"/> class.
        /// </summary>
        public AresioRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.AntiAlias;

            LinearGradientBrush MLG = new LinearGradientBrush(new Point(Height / 2, 0), new Point(Height / 2, Height), Color.FromArgb(50, Color.Black), Color.Transparent);

            G.FillEllipse(MLG, new Rectangle(0, 0, Height - 1, Height - 1));
            G.DrawEllipse(DesignFunctions.ToPen(50, Color.Black), new Rectangle(0, 0, Height - 1, Height - 1));

            G.DrawString(Text, Font, Brushes.Black, new Rectangle(Height + 5, 0, Width - Height + 4, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });

            if (_checked)
            {
                LinearGradientBrush MLG2 = new LinearGradientBrush(new Point(Height / 2, 3), new Point(Height / 2, Height - 6), Color.FromArgb(200, Color.White), Color.FromArgb(10, Color.White));
                G.FillEllipse(MLG2, new Rectangle(3, 3, Height - 7, Height - 7));
                G.DrawEllipse(DesignFunctions.ToPen(50, Color.Black), new Rectangle(3, 3, Height - 7, Height - 7));
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);

            if (!Checked)
                Checked = true;

            foreach (Control ctl in Parent.Controls)
            {
                if (ctl is AresioRadioButton)
                {
                    if (ctl.Handle == this.Handle)
                        continue;
                    if (ctl.Enabled)
                        ((AresioRadioButton)ctl).Checked = false;
                }
            }
        }
    }

}