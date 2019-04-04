// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInSeperator : Control
    {

        #region "Declarations"
        private Color _SeperatorColour = Color.FromArgb(35, 35, 35);
        private Style _Alignment = Style.Horizontal;
        #endregion
        private float _Thickness = 1;

        #region "Properties"

        public enum Style
        {
            Horizontal,
            Verticle
        }

        [Category("Control")]
        public float Thickness
        {
            get { return _Thickness; }
            set { _Thickness = value; }
        }

        [Category("Control")]
        public Style Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }

        [Category("Colours")]
        public Color SeperatorColour
        {
            get { return _SeperatorColour; }
            set { _SeperatorColour = value; }
        }

        #endregion

        #region "Draw Control"
        public LogInSeperator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(20, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            var _with13 = G;
            _with13.SmoothingMode = SmoothingMode.HighQuality;
            _with13.PixelOffsetMode = PixelOffsetMode.HighQuality;
            switch (_Alignment)
            {
                case Style.Horizontal:
                    _with13.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(0, Convert.ToInt32(Height / 2)), new Point(Width, Convert.ToInt32(Height / 2)));
                    break;
                case Style.Verticle:
                    _with13.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Convert.ToInt32(Width / 2), 0), new Point(Convert.ToInt32(Width / 2), Height));
                    break;
            }
            _with13.InterpolationMode = (InterpolationMode)7;
        }
        #endregion

    }

}


