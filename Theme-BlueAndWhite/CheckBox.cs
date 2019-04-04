// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
    public class BaWGUICheckBox : Control
    {
        #region " Declarations "
        private Font MFont = new Font("Marlett", 16);
        private GraphicsPath Shape;
        private LinearGradientBrush GB;
        private Pen P1;
        private Rectangle R1;
        private Rectangle R2;
        private SolidBrush B1;
        private SolidBrush B2;

        private StringFormat CSF = new StringFormat { LineAlignment = StringAlignment.Center };
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        #endregion
        private bool _Checked;

        #region " Properties "
        [Category("Appearance")]
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }
        #endregion

        public BaWGUICheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Arial", 12);
            Size = new Size(185, 26);

            P1 = new Pen(Color.FromArgb(160, 160, 160));
            B1 = new SolidBrush(Color.FromArgb(114, 114, 114));
            B2 = new SolidBrush(Color.FromArgb(110, 175, 235));
        }

        protected override void OnClick(EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            Invalidate();

            base.OnClick(e);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(System.EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();

                R1 = new Rectangle(30, 0, Width, Height);
                R2 = new Rectangle(0, 0, Width, Height);

                GB = new LinearGradientBrush(new Rectangle(0, 0, 25, 25), Color.FromArgb(244, 245, 244), Color.FromArgb(227, 227, 227), 90);


                var _with1 = Shape;
                _with1.AddArc(0, 0, 10, 10, 180, 90);
                _with1.AddArc(14, 0, 10, 10, -90, 90);
                _with1.AddArc(14, 14, 10, 10, 0, 90);
                _with1.AddArc(0, 14, 10, 10, 90, 90);
                _with1.CloseAllFigures();

                Height = 26;
            }

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _with2 = e.Graphics;
            _with2.SmoothingMode = SmoothingMode.HighQuality;

            _with2.FillPath(GB, Shape);
            _with2.DrawPath(P1, Shape);

            _with2.DrawString(Text, Font, B1, R1, CSF);

            if (Checked)
            {
                _with2.DrawString("a", MFont, B2, R2, CSF);
            }

            base.OnPaint(e);
        }
    }


}


