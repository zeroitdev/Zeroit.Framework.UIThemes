// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBarBlue.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Effectual
{

    public class EffectualProgressBarBlue : Control
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

        public EffectualProgressBarBlue() : base()
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

            LinearGradientBrush gB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(203, 201, 205), Color.FromArgb(188, 186, 190), 90);
            G.FillPath(gB, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 1));
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(75, Color.White))), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 1));

            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 1, Height - 2), Color.FromArgb(123, 190, 216), Color.FromArgb(108, 175, 201), 90);
            G.FillPath(g1, Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 2), 1));
            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(40, Color.White), Color.FromArgb(20, Color.White));
            G.FillPath(h1, Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 2), 1));

            //G.DrawPath(New Pen(Color.FromArgb(125, 97, 94, 90)), Draw.RoundRect(New Rectangle(0, 1, Width - 1, Height - 3), 2))
            G.DrawPath(new Pen(Color.FromArgb(117, 120, 117)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 1), 2));
            G.DrawPath(new Pen(Color.FromArgb(60, 113, 132)), Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 1), 2));
            //colored bar outline

            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), Font, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
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
