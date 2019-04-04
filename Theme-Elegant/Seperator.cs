// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Elegant
{

    public class ElegantThemeSeperator : Control
    {

        #region "Declarations"
        private Color _SeperatorColour = Color.FromArgb(163, 190, 146);
        private int _FontSize = 11;
        private Font _Font;
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        private Style _Alignment = Style.Horizontal;
        private float _Thickness = 1;
        #endregion
        private bool _ShowText = true;

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

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        [Category("Control")]
        public bool ShowText
        {
            get { return _ShowText; }
            set { _ShowText = value; }
        }

        #endregion

        #region "Draw Control"

        public ElegantThemeSeperator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(20, 40);

            _Font = new Font("Tahoma", _FontSize);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            var _with5 = G;
            _with5.SmoothingMode = SmoothingMode.HighQuality;
            _with5.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with5.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with5.Clear(Color.FromArgb(250, 250, 250));
            switch (_Alignment)
            {
                case Style.Horizontal:
                    if (_ShowText == true)
                    {
                        _with5.DrawString(Text, _Font, new SolidBrush(_TextColour), 0, Height / 2 - _FontSize + 1);
                        _with5.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point((int)_with5.MeasureString(Text, _Font).Width + 2, Height / 2), new Point(Width, Height / 2));
                    }
                    else
                    {
                        _with5.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(0, Height / 2), new Point(Width, Height / 2));
                    }
                    break;
                case Style.Verticle:
                    _with5.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Width / 2, 0), new Point(Width / 2, Height));
                    break;
            }
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }


}


