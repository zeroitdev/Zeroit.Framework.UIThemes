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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Loyal
{

    public class LoyalGroupBox : ContainerControl
    {

        #region " Back End "

        #region " Enums "

        public enum TextAlign
        {
            Left = 0,
            Center = 1,
            Right = 2
        }

        #endregion

        #region " Properties "

        private int _HeaderSize = 35;
        [Category("Header Properties")]
        public int HeaderSize
        {
            get { return _HeaderSize; }
            set
            {
                _HeaderSize = value;
                Invalidate();
            }
        }

        private Color _HeaderColor = Color.FromArgb(102, 51, 153);
        [Category("Header Properties")]
        public Color HeaderColor
        {
            get { return _HeaderColor; }
            set
            {
                _HeaderColor = value;
                Invalidate();
            }
        }

        private TextAlign _TextAlignment = TextAlign.Left;
        public TextAlign TextAlignment
        {
            get { return _TextAlignment; }
            set { _TextAlignment = value; }
        }

        #endregion

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            BackColor = Color.FromArgb(40, 40, 40);
        }

        public LoyalGroupBox()
        {
            Size = new Size(200, 100);
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            var _with3 = G;
            _with3.Clear(Color.FromArgb(40, 40, 40));
            _with3.FillRectangle(new SolidBrush(_HeaderColor), new Rectangle(5, 5, Width - 10, _HeaderSize - 5));
            _with3.DrawLine(new Pen(Color.FromArgb(30, Color.White)), new Point(6, 5), new Point(Width - 6, 5));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, 0, 1, 1));
            _with3.DrawLine(new Pen(Color.FromArgb(70, Color.Black)), new Point(5, _HeaderSize), new Point(Width - 6, _HeaderSize));
            _with3.DrawRectangle(new Pen(Color.FromArgb(18, 18, 18)), new Rectangle(0, 0, Width - 1, Height - 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(5, 5, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(Width - 6, 5, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, Height - 1, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, 0, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, Height - 1, 1, 1));
            StringFormat _StringF = new StringFormat { LineAlignment = StringAlignment.Center };
            switch (_TextAlignment)
            {
                case TextAlign.Center:
                    _StringF.Alignment = StringAlignment.Center;
                    _with3.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(5, 5, Width - 10, _HeaderSize - 5), _StringF);
                    break;
                case TextAlign.Left:
                    _with3.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(12, 5, Width - 10, _HeaderSize - 5), _StringF);
                    break;
                case TextAlign.Right:
                    int _StringLength = TextRenderer.MeasureText(Text, new Font("Arial", 9)).Width + 8;
                    _with3.DrawString(Text, new Font("Arial", 9), Brushes.White, new Rectangle(Width - _StringLength, 5, Width - _StringLength, _HeaderSize - 5), _StringF);
                    break;
            }
        }
    }


}


