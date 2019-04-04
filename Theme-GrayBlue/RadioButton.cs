// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GrayBlue
{
    public class GrayBlueRadioButton : Control
    {
        public delegate void CheckedChangedEventHandler();
        public event CheckedChangedEventHandler CheckedChanged;
        private bool _checked;
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;

                Invalidate();
                if (CheckedChanged != null)
                    CheckedChanged();
            }
        }

        public enum State
        {
            None,
            Over
        }

        private State MouseState;

        public GrayBlueRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            Checked = false;
            Size = new Size(15, 15);
            MouseState = State.None;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (Checked)
            {
                G.FillEllipse(new LinearGradientBrush(new Point(Height / 2, 0), new Point(Height / 2, Height), Color.FromArgb(75, 130, 195), Color.FromArgb(40, 80, 135)), new Rectangle(0, 0, Height - 1, Height - 1));
                G.FillEllipse(DesignFunctions.ToBrush(150, Color.Black), new Rectangle(4, 4, Height - 9, Height - 9));
            }
            else
            {
                if (MouseState == State.Over)
                {
                    G.FillEllipse(new LinearGradientBrush(new Point(Height / 2, 0), new Point(Height / 2, Height), Color.FromArgb(75, 130, 195), Color.FromArgb(40, 80, 135)), new Rectangle(0, 0, Height - 1, Height - 1));
                }
                else
                {
                    G.FillEllipse(new LinearGradientBrush(new Point(Height / 2, 0), new Point(Height / 2, Height), Color.FromArgb(127, 127, 127), Color.FromArgb(93, 93, 93)), new Rectangle(0, 0, Height - 1, Height - 1));
                }
            }

            G.DrawEllipse(DesignFunctions.ToPen(50, Color.White), new Rectangle(0, 1, Height - 1, Height - 2));
            G.DrawEllipse(Pens.Black, new Rectangle(0, 0, Height - 1, Height - 1));
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);

            if (!Checked)
            {
                Checked = true;
            }

            foreach (Control ctl in Parent.Controls)
            {
                if (ctl is GrayBlueRadioButton)
                {
                    if (ctl.Handle == this.Handle)
                    {
                        continue;
                    }
                    if (ctl.Enabled)
                    {
                        ((GrayBlueRadioButton)ctl).Checked = false;
                    }
                }
            }
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseState = State.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = State.None;
            Invalidate();
        }
    }
}
