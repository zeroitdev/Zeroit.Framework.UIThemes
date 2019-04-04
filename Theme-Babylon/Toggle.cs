// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Toggle.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Babylon
{
    #region  Toggle Button 

    [DefaultEvent("ToggledChanged")]
    public class BabylonToggle : Control
    {
        #region  Designer 

        
        public class PillStyle
        {
            public bool Left;
            public bool Right;
        }

        public GraphicsPath Pill(Rectangle Rectangle, PillStyle PillStyle)
        {
            GraphicsPath tempPill = null;
            tempPill = new GraphicsPath();

            if (PillStyle.Left)
            {
                tempPill.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270F, 180F);
            }
            else
            {
                tempPill.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y);
            }

            if (PillStyle.Right)
            {
                tempPill.AddArc(new Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90F, 180F);
            }
            else
            {
                tempPill.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
            }
            tempPill.CloseAllFigures();
            return tempPill;
        }

        public object Pill(int X, int Y, int Width, int Height, PillStyle PillStyle)
        {
            return Pill(new Rectangle(X, Y, Width, Height), PillStyle);
        }

        #endregion
        #region  Enums 

        public enum _Type
        {
            YesNo,
            OnOff,
            IO
        }

        #endregion
        #region  Variables 

        private Timer AnimationTimer = new Timer { Interval = 1 };
        private int ToggleLocation = 0;
        public delegate void ToggledChangedEventHandler();
        public event ToggledChangedEventHandler ToggledChanged;
        private bool _Toggled;
        private _Type ToggleType;
        private Rectangle Bar;
        private Size cHandle = new Size(15, 20);

        #endregion
        #region  Properties 

        public bool Toggled
        {
            get
            {
                return _Toggled;
            }
            set
            {
                _Toggled = value;
                Invalidate();
                if (ToggledChanged != null)
                    ToggledChanged();
            }
        }

        public _Type Type
        {
            get
            {
                return ToggleType;
            }
            set
            {
                ToggleType = value;
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs 

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 41;
            Height = 23;
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Toggled = !Toggled;
        }

        #endregion

        public BabylonToggle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            SubscribeToEvents();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationTimer.Start(); // activate the animation timer
        }

        private void Animation(object sender, EventArgs e)
        {
            // Create a slide animation when toggled on/off
            if (_Toggled == true)
            {
                if (ToggleLocation < 100)
                {
                    ToggleLocation += 10;
                    this.Invalidate(false);
                }
            }
            else
            {
                if (ToggleLocation > 0)
                {
                    ToggleLocation -= 10;
                    this.Invalidate(false);
                }
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            LinearGradientBrush Gradient = new LinearGradientBrush(new Point(0, Convert.ToInt32((Height / 2) - (cHandle.Height / 2.0))), new Point(0, Convert.ToInt32((Height / 2) + (cHandle.Height / 2.0))), Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240));
            Bar = new Rectangle(8, 10, Width - 21, Height - 21);

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the control body and border
            G.FillPath(Gradient, Pill(new Rectangle(0, Convert.ToInt32(Height / 2 - cHandle.Height / 2.0), Width - 1, cHandle.Height - 5), new PillStyle { Left = true, Right = true }));
            G.DrawPath(new Pen(Color.FromArgb(177, 177, 176)), Pill(new Rectangle(0, Convert.ToInt32(Height / 2 - cHandle.Height / 2.0), Width - 1, cHandle.Height - 5), new PillStyle { Left = true, Right = true }));

            Gradient.Dispose(); // Dispose GradientBrush object

            // Draw a string based on the toggle boolean value
            switch (ToggleType)
            {
                case _Type.YesNo:
                    if (Toggled)
                    {
                        G.DrawString("Yes", new Font("Segoe UI", 7F, FontStyle.Regular), Brushes.Gray, Bar.X + 7, Bar.Y, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("No", new Font("Segoe UI", 7F, FontStyle.Regular), Brushes.Gray, Bar.X + 18, Bar.Y, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case _Type.OnOff:
                    if (Toggled)
                    {
                        G.DrawString("On", new Font("Segoe UI", 7F, FontStyle.Regular), Brushes.Gray, Bar.X + 7, Bar.Y, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("Off", new Font("Segoe UI", 7F, FontStyle.Regular), Brushes.Gray, Bar.X + 18, Bar.Y, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case _Type.IO:
                    if (Toggled)
                    {
                        G.DrawString("I", new Font("Segoe UI", 7F, FontStyle.Regular), Brushes.Gray, Bar.X + 7, Bar.Y, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("O", new Font("Segoe UI", 7F, FontStyle.Regular), Brushes.Gray, Bar.X + 18, Bar.Y, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
            }

            // Draw the toggle handle
            G.FillEllipse(new SolidBrush(Color.FromArgb(249, 249, 249)), Bar.X + Convert.ToInt32(Bar.Width * (ToggleLocation / 80.0)) - Convert.ToInt32(cHandle.Width / 2.0), Bar.Y + Convert.ToInt32((Bar.Height / 2.0)) - Convert.ToInt32(cHandle.Height / 2.0 - 1), cHandle.Width, cHandle.Height - 5);
            G.DrawEllipse(new Pen(Color.FromArgb(177, 177, 176)), Bar.X + Convert.ToInt32(Bar.Width * (ToggleLocation / 80.0) - Convert.ToInt32(cHandle.Width / 2.0)), Bar.Y + Convert.ToInt32((Bar.Height / 2.0)) - Convert.ToInt32(cHandle.Height / 2.0 - 1), cHandle.Width, cHandle.Height - 5);
        }

        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            AnimationTimer.Tick += Animation;
        }

    }

    #endregion
}