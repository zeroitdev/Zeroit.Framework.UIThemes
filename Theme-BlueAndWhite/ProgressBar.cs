// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.BlueWhite
{

    public class BaWGUIProgressBar : Control
    {

        #region " Declarations "
        private GraphicsPath OPath;
        private GraphicsPath IPath;
        private GraphicsPath Indicator;
        private int FillValue;
        private LinearGradientBrush OGB;
        private LinearGradientBrush IGB;
        private LinearGradientBrush IOGB;
        private LinearGradientBrush IndicatorGB;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;

        private TextureBrush TB = new TextureBrush(Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAACUElEQVQYGa3BwY1dVRBF0X2q6mExtWDgAQEQIDmRDzn0wBISYtL9771Vx/81CBNAr6Xffv9jbEAC8WRukrh5jBBgbiED5mYbSZjAFrf6/PlnelrDPyRhm5swIQMmUoREBk/GNjdJgBiER9QvX35in8E2Bsx30lDRRIiqoFJkBhFgG9uAwMEguqG+/vkX3WZsbgYskEQGXAlVyVVBVZApxCDANm2YgbPNOkN9/fuBARMYc5NERHBl8qmSa4pyED1IwzsZD3QPezVrN2dD8MFqzYVsJJ4aMaChqvgUw4/xRqoIJ27hEIOw4fSwz7B2s07TberNCTPIjQJSSWXRmXQFO0wTyMkgGDEjdg/7HHbD2uYcmDF1zmA30ASgK1AlUQWZWMHhyWIQbnHarDZ7iXXE2qJHYFGeg+YA5gpxKbhkYoaQcAxjwMKIGbHW4W1t9m5OmxnAxojgg1WvB4GpK0iJSpGCwPQsZgYIPGIs9mleXw9vj81pA8IGI5CoZbgqqUx0JY6iBWNjGww2jM3eh7Wa18dm78YWtgAB5laugAy4iongYGyBjQfaQfewT/NYzVrN3mYc2DwFQtwkU0FTAakBNzR0G9kMwZ7g7Obx2KxHs1bTBpRgnpqbAiJE8MHqh7hIBTHAiOHJ4BmOmz2wVvN4O+zddPMkYLB5FyEyxBWi3laxG0oCjLiJGTg9PPZh78M+5rTBAoTNO8nIphS0Tb28vBASGAKDzM0ztGEkZoYZY/Mv8Z25RYgMqF+/FE8WAyOk4D8ShLANBO8k/s9usAEDwzcn97xOZ2JTrwAAAABJRU5ErkJggg=="))), WrapMode.Tile);
        private int _Value = 0;
        #endregion
        private int _Maximum = 100;

        #region " Properties "
        [Category("Control")]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < _Value)
                    _Value = value;
                _Maximum = value;
                FillValue = Convert.ToInt32((_Value / _Maximum) * (Width - 50));
                ChangePaths();
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
                        FillValue = Convert.ToInt32((_Value / _Maximum) * (Width - 50));
                        ChangePaths();
                        Invalidate();
                        break;
                    default:
                        return _Value;
                        FillValue = Convert.ToInt32((_Value / _Maximum) * (Width - 50));
                        ChangePaths();
                        Invalidate();
                        break;
                }
            }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                FillValue = Convert.ToInt32((_Value / _Maximum) * (Width - 50));
                ChangePaths();
                Invalidate();
            }
        }
        #endregion

        public BaWGUIProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Arial", 16);
            MinimumSize = new Size(60, 80);

            TB.TranslateTransform(0, -5, MatrixOrder.Prepend);

            P3 = new Pen(Color.FromArgb(190, 190, 190));
            B1 = new SolidBrush(Color.FromArgb(84, 83, 81));
        }

        protected override void OnResize(EventArgs e)
        {
            FillValue = Convert.ToInt32((_Value / _Maximum) * (Width - 50));

            OPath = new GraphicsPath();

            var _with1 = OPath;
            _with1.AddArc(14, Height - 31, 20, 20, 180, 90);
            _with1.AddArc(Width - 44, Height - 31, 20, 20, -90, 90);
            _with1.AddArc(Width - 44, Height - 21, 20, 20, 0, 90);
            _with1.AddArc(14, Height - 21, 20, 20, 90, 90);
            _with1.CloseAllFigures();
            ChangePaths();

            Height = 80;

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _with2 = e.Graphics;
            _with2.SmoothingMode = SmoothingMode.HighQuality;

            switch (_Value)
            {
                case 0:
                    _with2.FillPath(IGB, OPath);
                    _with2.DrawPath(P1, OPath);
                    break;
                default:
                    _with2.FillPath(IGB, OPath);
                    _with2.DrawPath(P1, OPath);
                    _with2.FillPath(TB, IPath);
                    _with2.DrawPath(P2, IPath);

                    _with2.FillPath(IndicatorGB, Indicator);
                    _with2.DrawPath(P3, Indicator);

                    switch (_Value)
                    {
                        case  // ERROR: Case labels with binary operators are unsupported : LessThan
    10:
                            _with2.DrawString(_Value + "%", Font, B1, FillValue + 6, 7);
                            break;
                        case  // ERROR: Case labels with binary operators are unsupported : LessThan
    100:
                            _with2.DrawString(_Value + "%", Font, B1, FillValue - 5, 7);
                            break;
                        default:
                            _with2.DrawString(_Value + "%", Font, B1, FillValue - 11, 7);
                            break;
                    }
                    break;
            }

            base.OnPaint(e);
        }

        private void ChangePaths()
        {
            if (Width > 0 && Height > 0)
            {
                IPath = new GraphicsPath();
                Indicator = new GraphicsPath();

                OGB = new LinearGradientBrush(new Rectangle(Width - 44, Height - 31, 31, 31), Color.FromArgb(173, 173, 173), Color.FromArgb(195, 195, 195), 90);
                IGB = new LinearGradientBrush(new Rectangle(Width - 43, Height - 30, 30, 30), Color.FromArgb(201, 201, 201), Color.FromArgb(225, 225, 225), 90);
                IOGB = new LinearGradientBrush(new Rectangle(19, Height - 26, Width - 6, Height - 26), Color.FromArgb(125, 175, 225), Color.FromArgb(55, 130, 205), -90);
                IndicatorGB = new LinearGradientBrush(new Rectangle(FillValue - 11, 0, FillValue + 19, 45), Color.FromArgb(232, 232, 232), Color.FromArgb(202, 202, 202), 90);

                P1 = new Pen(OGB);
                P2 = new Pen(IOGB);


                if (FillValue >= 13)
                {
                    var _with3 = IPath;
                    _with3.AddArc(19, Height - 26, 20, 20, 180, 90);
                    _with3.AddArc(FillValue, Height - 26, 20, 20, -90, 90);
                    _with3.AddArc(FillValue, Height - 26, 20, 20, 0, 90);
                    _with3.AddArc(19, Height - 26, 20, 20, 90, 90);
                }
                var _with4 = Indicator;
                _with4.AddArc(FillValue - 11, 0, 8, 8, 180, 90);
                _with4.AddArc(FillValue + 40, 0, 8, 8, -90, 90);
                _with4.AddArc(FillValue + 40, 27, 8, 8, 0, 90);
                _with4.AddLine(FillValue + 24, 35, FillValue + 19, 45);
                _with4.AddLine(FillValue + 14, 35, FillValue - 3, 35);
                _with4.AddArc(FillValue - 11, 27, 8, 8, 90, 90);
                _with4.CloseFigure();
            }
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }
    }


}


