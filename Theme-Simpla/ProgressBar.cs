// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Simpla
{

    public class SimplaProgressBar : Control
    {

        #region " Control Help - Properties & Flicker Control "
        private int OFS = 0;
        private int Speed = 50;

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {

                if (value == _Value)
                {
                    _Value = value;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Value:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                _Maximum = value;
                Invalidate();
            }
        }
        private int _Value = 0;
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 0;
                    default:
                        return _Value;
                }
            }
            set
            {

                if (value == _Maximum)
                {
                    value = _Maximum;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					value = _Maximum;
                //					break;
                //			} 
                #endregion

                _Value = value;
                Invalidate();
            }
        }
        private bool _ShowPercentage = false;
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            // Dim tmr As New Timer With {.Interval = Speed}
            // AddHandler tmr.Tick, AddressOf Animate
            // tmr.Start()
            System.Threading.Thread T = new System.Threading.Thread(Animate);
            T.IsBackground = true;
            //T.Start()
        }
        public void Animate()
        {
            while (true)
            {
                if (OFS <= Width)
                {
                    OFS += 1;
                }
                else
                {
                    OFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(Speed);
            }
        }
        #endregion

        public enum ColorSchemes
        {
            DarkGray,
            Green,
            Blue,
            White,
            Red
        }
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                Invalidate();
            }
        }

        public SimplaProgressBar() : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighQuality;

            int intValue = Convert.ToInt32(_Value / _Maximum * Width);
            G.Clear(BackColor);


            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(26, 26, 26))), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));

            SolidBrush percentColor = new SolidBrush(Color.White);
            ////// Bar Fill
            if (!(intValue == 0))
            {
                switch (ColorScheme)
                {
                    case ColorSchemes.DarkGray:
                        LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(23, 23, 23), Color.FromArgb(17, 17, 17), 90);
                        G.FillPath(g1, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.White);
                        break;
                    case ColorSchemes.Green:
                        LinearGradientBrush g11 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(121, 185, 0), Color.FromArgb(94, 165, 1), 90);
                        G.FillPath(g11, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.White);
                        break;
                    case ColorSchemes.Blue:
                        LinearGradientBrush g12 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(0, 124, 186), Color.FromArgb(0, 97, 166), 90);
                        G.FillPath(g12, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.White);
                        break;
                    case ColorSchemes.White:
                        LinearGradientBrush g13 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(245, 245, 245), Color.FromArgb(246, 246, 246), 90);
                        G.FillPath(g13, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.FromArgb(20, 20, 20));
                        break;
                    case ColorSchemes.Red:
                        LinearGradientBrush g14 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(185, 0, 0), Color.FromArgb(170, 0, 0), 90);
                        G.FillPath(g14, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.White);
                        break;
                }
            }

            ////// Outer Rectangle
            G.DrawPath(new Pen(Color.FromArgb(190, 56, 56, 56)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            ////// Bar Size
            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));

            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Tahoma", 9, FontStyle.Bold), percentColor, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
}

