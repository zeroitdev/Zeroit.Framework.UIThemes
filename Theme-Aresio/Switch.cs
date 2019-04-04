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
    /// Class AresioSwitch.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class AresioSwitch : Control
    {

        /// <summary>
        /// The toggle location
        /// </summary>
        private int ToggleLocation = 0;
        /// <summary>
        /// The with events field toggle animation
        /// </summary>
        private Timer withEventsField_ToggleAnimation = new Timer { Interval = 1 };
        /// <summary>
        /// Gets or sets the toggle animation.
        /// </summary>
        /// <value>The toggle animation.</value>
        private Timer ToggleAnimation
        {
            get { return withEventsField_ToggleAnimation; }
            set
            {
                if (withEventsField_ToggleAnimation != null)
                {
                    withEventsField_ToggleAnimation.Tick -= Animation;
                }
                withEventsField_ToggleAnimation = value;
                if (withEventsField_ToggleAnimation != null)
                {
                    withEventsField_ToggleAnimation.Tick += Animation;


                }
            }

        }


        /// <summary>
        /// Occurs when [toggled changed].
        /// </summary>
        public event ToggledChangedEventHandler ToggledChanged;
        /// <summary>
        /// Delegate ToggledChangedEventHandler
        /// </summary>
        public delegate void ToggledChangedEventHandler();
        /// <summary>
        /// The toggled
        /// </summary>
        private bool _toggled;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AresioSwitch"/> is toggled.
        /// </summary>
        /// <value><c>true</c> if toggled; otherwise, <c>false</c>.</value>
        public bool Toggled
        {
            get { return _toggled; }
            set
            {
                _toggled = value;
                Invalidate();

                if (ToggledChanged != null)
                {
                    ToggledChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AresioSwitch"/> class.
        /// </summary>
        public AresioSwitch()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            Bar = new Rectangle(0, 10, Width - 1, Height - 21);

        }

        /// <summary>
        /// Creates a handle for the control.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            ToggleAnimation.Start();
        }

        /// <summary>
        /// Animations the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Animation(object sender, EventArgs e)
        {
            if (_toggled)
            {
                if (ToggleLocation < 100)
                {
                    ToggleLocation += 10;
                }
            }
            else
            {
                if (ToggleLocation > 0)
                {
                    ToggleLocation -= 10;
                }
            }

            Invalidate();
        }

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

            Graphics G = e.Graphics;
            Bar = new Rectangle(10, 10, Width - 21, Height - 21);
            G.Clear(Parent.FindForm().BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            DesignFunctions.PillStyle styles = new DesignFunctions.PillStyle();
            styles.Left = true;
            styles.Right = true;
            //Background
            LinearGradientBrush BackLinear = new LinearGradientBrush(new Point(0, Convert.ToInt32((Height / 2) - (Track.Height / 2))), new Point(0, Convert.ToInt32((Height / 2) + (Track.Height / 2))), Color.FromArgb(50, Color.Black), Color.Transparent);
            //G.FillPath(BackLinear, RoundRect(0, CInt((Height / 2) - 4), Width - 1, 8, 3))

            G.FillPath(BackLinear, (GraphicsPath)DesignFunctions.Pill(0, Convert.ToInt32(Height / 2 - Track.Height / 2), Width - 1, Track.Height - 2, new DesignFunctions.PillStyle
            {
                Left = true,
                Right = true
            }));

            G.FillPath(BackLinear, (GraphicsPath)DesignFunctions.Pill(0, Convert.ToInt32(Height / 2 - Track.Height / 2), Width - 1, Track.Height - 2, new DesignFunctions.PillStyle
            {
                Left = true,
                Right = true
            }));
            G.DrawPath(DesignFunctions.ToPen(50, Color.Black), (GraphicsPath)DesignFunctions.Pill(0, Convert.ToInt32(Height / 2 - Track.Height / 2), Width - 1, Track.Height - 2, new DesignFunctions.PillStyle
            {
                Left = true,
                Right = true
            }));

            BackLinear.Dispose();

            //Fill
            if (ToggleLocation > 0)
            {
                G.FillPath(new LinearGradientBrush(new Point(0, Convert.ToInt32((Height / 2) - Track.Height / 2)), new Point(1, Convert.ToInt32((Height / 2) + Track.Height / 2)), Color.FromArgb(250, 200, 70), Color.FromArgb(250, 160, 40)), (GraphicsPath)DesignFunctions.Pill(1, Convert.ToInt32((Height / 2) - Track.Height / 2), Convert.ToInt32(Bar.Width * (ToggleLocation / 100)) + Convert.ToInt32(Track.Width / 2), Track.Height - 3, new DesignFunctions.PillStyle
                {
                    Left = true,
                    Right = true
                }));
                G.DrawPath(DesignFunctions.ToPen(100, Color.White), (GraphicsPath)DesignFunctions.Pill(1, Convert.ToInt32((Height / 2) - Track.Height / 2 + 1), Convert.ToInt32(Bar.Width * (ToggleLocation / 100)) + Convert.ToInt32(Track.Width / 2), Track.Height - 5, new DesignFunctions.PillStyle
                {
                    Left = true,
                    Right = true
                }));
            }

            if (Toggled)
            {
                G.DrawString("ON", new Font("Arial", 6, FontStyle.Bold), DesignFunctions.ToBrush(150, Color.Black), new Rectangle(0, -1, Width - Track.Width + Track.Width / 3, Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            else
            {
                G.DrawString("OFF", new Font("Arial", 6, FontStyle.Bold), DesignFunctions.ToBrush(150, Color.Black), new Rectangle(Track.Width - Track.Width / 3, -1, Width - Track.Width + Track.Width / 3, Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            //Button
            G.FillEllipse(Brushes.White, Bar.X + Convert.ToInt32(Bar.Width * (ToggleLocation / 100)) - Convert.ToInt32(Track.Width / 2), Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width, Track.Height);
            G.DrawEllipse(DesignFunctions.ToPen(50, Color.Black), Bar.X + Convert.ToInt32(Bar.Width * (ToggleLocation / 100) - Convert.ToInt32(Track.Width / 2)), Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width, Track.Height);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Toggled = !Toggled;
        }


    }
    
}