// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Valley
{
    public class ValleyProgressbar : Control
    {
        #region  Variables

        private int _Value = 0;
        private int _Maximum = 100;

        #endregion

        #region  Control
        [Category("Control")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 0;
                        Invalidate();
                        break;
                    default:
                        return _Value;
                        Invalidate();
                        break;
                }
            }
            set
            {
                
                if (value > _Maximum)
                {
                    value = _Maximum;
                    Invalidate();
                }
                _Value = value;
                Invalidate();
            }
        }
        #endregion

        #region Events
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 25;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Height = 25;
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }
        #endregion

        public ValleyProgressbar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;

            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(Color.FromArgb(223, 223, 223));
            int ProgVal = Convert.ToInt32(_Value / _Maximum * Width);
           
            if (Value == 0)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(223, 223, 223)), new Rectangle(0, 0, Width, Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, 124, 244)), new Rectangle(0, 0, ProgVal - 1, Height));
            }
            //ORIGINAL LINE: Case _Maximum
            else if (Value == _Maximum)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(223, 223, 223)), new Rectangle(0, 0, Width, Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, 124, 244)), new Rectangle(0, 0, ProgVal - 1, Height));
            }
            //ORIGINAL LINE: Case Else
            else
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(223, 223, 223)), new Rectangle(0, 0, Width, Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, 124, 244)), new Rectangle(0, 0, ProgVal - 1, Height));
            }
            G.InterpolationMode = (InterpolationMode)7;
            base.OnPaint(e);


        }
    }
}


