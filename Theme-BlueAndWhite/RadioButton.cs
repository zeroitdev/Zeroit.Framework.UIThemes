// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.BlueWhite
{

    [DefaultEvent("CheckedChanged")]
    public class BaWGUIRadioButton : Control
    {
        #region " Declarations "
        private LinearGradientBrush GB;
        private Rectangle R1;
        private Pen P1;
        private SolidBrush B1;
        private SolidBrush B2;

        private StringFormat CSF = new StringFormat { LineAlignment = StringAlignment.Center };
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        private bool _Checked;
        #endregion
        private int _Group = 1;

        #region " Properties "
        [Category("Appearance")]
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

        [Category("Custom")]
        public int Group
        {
            get { return _Group; }
            set { _Group = value; }
        }
        #endregion
        public BaWGUIRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Arial", 12);
            Size = new Size(200, 26);

            P1 = new Pen(Color.FromArgb(160, 160, 160));
            B1 = new SolidBrush(Color.FromArgb(114, 114, 114));
            B2 = new SolidBrush(Color.FromArgb(95, 165, 230));
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is BaWGUIRadioButton && ((BaWGUIRadioButton)C).Group == _Group)
                {
                    ((BaWGUIRadioButton)C).Checked = false;
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnClick(e);
        }

        protected override void OnCreateControl()
        {
            InvalidateControls();
            base.OnCreateControl();
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(System.EventArgs e)
        {
            Height = 26;

            R1 = new Rectangle(30, 0, Width, Height);

            GB = new LinearGradientBrush(new Rectangle(0, 0, 25, 25), Color.FromArgb(244, 245, 244), Color.FromArgb(227, 227, 227), 90);

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _with1 = e.Graphics;
            _with1.SmoothingMode = SmoothingMode.HighQuality;

            _with1.FillEllipse(GB, 0, 0, 25, 25);
            _with1.DrawEllipse(P1, 0, 0, 24, 24);

            _with1.DrawString(Text, Font, B1, R1, CSF);

            if (Checked)
            {
                _with1.FillEllipse(B2, 8, 8, 8, 8);
            }

            base.OnPaint(e);
        }
    }

}


