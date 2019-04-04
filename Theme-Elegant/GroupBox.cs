// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Elegant
{

    public class ElegantThemeGroupBox : ContainerControl
    {

        #region "Declarations"
        private Color _MainColour = Color.FromArgb(255, 255, 255);
        private Color _HeaderColour = Color.FromArgb(248, 250, 249);
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        #endregion
        private Color _BorderColour = Color.FromArgb(163, 190, 146);

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
        public ElegantThemeGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(160, 110);
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle Circle = new Rectangle(8, 8, 10, 10);
            var _with7 = G;
            _with7.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with7.SmoothingMode = SmoothingMode.HighQuality;
            _with7.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with7.Clear(BackColor);
            _with7.FillRectangle(new SolidBrush(_MainColour), new Rectangle(0, 28, Width, Height));
            _with7.FillRectangle(new SolidBrush(_HeaderColour), new Rectangle(0, 0, Width, 28));
            _with7.DrawString(Text, Font, new SolidBrush(_TextColour), new Point(5, 5));
            _with7.DrawRectangle(new Pen(_BorderColour), new Rectangle(0, 0, Width, Height));
            _with7.DrawLine(new Pen(_BorderColour), 0, 28, Width, 28);
            _with7.DrawLine(new Pen(_BorderColour, 3), new Point(0, 27), new Point((int)_with7.MeasureString(Text, Font).Width + 7, 27));
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion

    }


}


