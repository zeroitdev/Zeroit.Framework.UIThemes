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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Babylon
{
    #region  RadioButton 

    [DefaultEvent("CheckedChanged")]
    public class BabylonRadioButton : Control
    {
        #region  Enums 

        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }

        #endregion
        #region  Variables 

        private bool _Checked;
        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;

        #endregion
        #region  Properties 

        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                    CheckedChanged(this);
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs 

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 15;
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
            {
                Checked = true;
            }
            base.OnMouseDown(e);
        }

        #endregion

        public BabylonRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 10);
            Width = 132;
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
            {
                return;
            }

            foreach (Control _Control in Parent.Controls)
            {
                if (_Control != this && _Control is BabylonRadioButton)
                {
                    ((BabylonRadioButton)_Control).Checked = false;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(Color.FromArgb(246, 246, 246));
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Fill the body of the ellipse with a gradient
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240), 90);
            e.Graphics.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));

            GraphicsPath GP = new GraphicsPath();
            GP.AddEllipse(new Rectangle(0, 0, 14, 14));
            e.Graphics.SetClip(GP);
            e.Graphics.ResetClip();

            // Draw ellipse border
            e.Graphics.DrawEllipse(new Pen(Color.FromArgb(160, 160, 160)), new Rectangle(new Point(0, 0), new Size(14, 14)));

            if (_Checked) // Draw an ellipse inside the body
            {
                SolidBrush EllipseColor = new SolidBrush(Color.FromArgb(142, 142, 142));
                e.Graphics.FillEllipse(EllipseColor, new Rectangle(new Point(4, 4), new Size(6, 6)));
            }
            e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(142, 142, 142)), 16, 8, new StringFormat() { LineAlignment = StringAlignment.Center });
            e.Dispose();
        }
    }

    #endregion
}