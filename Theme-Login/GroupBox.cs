// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInGroupBox : ContainerControl
    {

        #region "Declarations"
        private Color _MainColour = Color.FromArgb(47, 47, 47);
        private Color _HeaderColour = Color.FromArgb(42, 42, 42);
        private Color _TextColour = Color.FromArgb(255, 255, 255);
        #endregion
        private Color _BorderColour = Color.FromArgb(35, 35, 35);

        #region "Properties"

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        [Category("Colours")]
        public Color HeaderColour
        {
            get { return _HeaderColour; }
            set { _HeaderColour = value; }
        }

        [Category("Colours")]
        public Color MainColour
        {
            get { return _MainColour; }
            set { _MainColour = value; }
        }

        #endregion

        #region "Draw Control"
        public LogInGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(160, 110);
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var _with12 = g;
            _with12.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with12.SmoothingMode = SmoothingMode.HighQuality;
            _with12.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with12.Clear(Color.FromArgb(54, 54, 54));
            _with12.FillRectangle(new SolidBrush(_MainColour), new Rectangle(0, 28, Width, Height));
            _with12.FillRectangle(new SolidBrush(_HeaderColour), new Rectangle(0, 0, Convert.ToInt32(_with12.MeasureString(Text, Font).Width + 7), 28));
            _with12.DrawString(Text, Font, new SolidBrush(_TextColour), new Point(5, 5));
            Point[] P = {
            new Point(0, 0),
            new Point(Convert.ToInt32(_with12.MeasureString(Text, Font).Width + 7), 0),
            new Point(Convert.ToInt32(_with12.MeasureString(Text, Font).Width + 7), 28),
            new Point(Width - 1, 28),
            new Point(Width - 1, Height - 1),
            new Point(1, Height - 1),
            new Point(1, 1)
        };
            _with12.DrawLines(new Pen(_BorderColour), P);
            _with12.DrawLine(new Pen(_BorderColour, 2), new Point(0, 28), new Point(Convert.ToInt32(_with12.MeasureString(Text, Font).Width + 7), 28));
            _with12.InterpolationMode = (InterpolationMode)7;
        }
        #endregion

    }

}


