// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Cypher
{
    public class CyperxProgressbar : Control
    {
        public CyperxProgressbar()
        {
            Font = new Font("Arial", 8);
            ForeColor = Color.White;
        }

        bool _UseColor = false;
        public bool Colorize
        {
            get { return _UseColor; }
            set
            {
                _UseColor = value;
                Invalidate();
            }
        }
        double Perc = 0;
        public double Percentage
        {
            get { return Perc; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    Rectangle WholeR = new Rectangle(0, 0, Width - 1, Height - 1);
                    Draw.Gradient(g, _Lightcolor, _DarkColor, WholeR);
                    g.DrawRectangle(Pens.Black, WholeR);
                    double OneProcent = Maximum / 100;
                    int ProgressProcent = (int)(_Progress / OneProcent);
                    Console.WriteLine(ProgressProcent);

                    Rectangle ProgressRec = new Rectangle(2, 2, Convert.ToInt32((Width - 4) * (ProgressProcent * 0.01)), Height - 4);
                    Perc = _Progress / (Maximum / 100);
                    switch (_UseColor)
                    {
                        case false:
                            g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Black)), ProgressRec);
                            break;
                        case true:
                            Color Drawcolor = Color.FromArgb(150, 255 - 2 * ProgressProcent, (int)(1.7 * ProgressProcent), 0);
                            g.FillRectangle(new SolidBrush(Color.FromArgb(50, Drawcolor)), ProgressRec);
                            break;
                    }

                    if (Showt)
                        g.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(3, 4));
                    e.Graphics.DrawImage(b, 0, 0);
                }
            }
        }


        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }

        #region " Properties "

        bool Showt = true;
        public bool ShowText
        {
            get { return Showt; }
            set
            {
                Showt = value;
                Invalidate();
            }
        }
        private double _Maximum = 100;
        public double Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                value = _Current / value * 100;
                Invalidate();
            }
        }

        private double _Current;
        public double Current
        {
            get { return _Current; }
            set
            {
                _Current = value;
                value = value / _Maximum * 100;
                Invalidate();
            }
        }

        private int _Progress;
        public double Value
        {
            get { return _Progress; }
            set
            {
                if (value < 0)
                    value = 0;
                else
                    if (value > Maximum)
                    value = Maximum;
                _Progress = Convert.ToInt32(value);
                _Current = value * 0.01 * _Maximum;
                Invalidate();
            }
        }

        public Color DarkColor
        {


            get { return _DarkColor; }
            set
            {
                _DarkColor = value;
                Invalidate();
            }
        }

        public Color Lightcolor
        {
            get { return _Lightcolor; }
            set
            {
                _Lightcolor = value;
                Invalidate();
            }
        }

        #endregion

        #region " Colors "
        Color _Lightcolor = Color.FromArgb(65, 55, 45);
        #endregion
        Color _DarkColor = Color.FromArgb(75, 70, 65);


    }

}
