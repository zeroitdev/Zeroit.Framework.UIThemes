// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightProgressBar : ThemeControl
    {
        private int _Maximum;
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
                //            
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
        private int _Value;
        public int Value
        {
            get { return _Value; }
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
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(51, 51, 51));
            HatchBrush hb = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.White), Color.Transparent);
            HatchBrush hb2 = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(35, Color.White), Color.Transparent);
            G.FillRectangle(new SolidBrush(Color.FromArgb(196, 196, 196)), 0, 0, Width, Height);
            DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, Width, 30, 270);
            DrawGradient(Color.FromArgb(40, Color.White), Color.FromArgb(30, Color.White), 1, 1, Width, Height / 2 - 4, 270);
            //Fill
            switch (_Value)
            {
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    6:
                    DrawGradient(Color.FromArgb(109, 183, 255), Color.FromArgb(40, 154, 255), 3, 3, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height / 2 - 3, 90);
                    DrawGradient(Color.FromArgb(30, 130, 245), Color.FromArgb(15, 100, 170), 3, Height / 2 - 1, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height / 2 - 2, 90);

                    break;
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    1:
                    DrawGradient(Color.FromArgb(109, 183, 255), Color.FromArgb(40, 154, 255), 3, 3, Convert.ToInt32(_Value / _Maximum * Width), Height / 2 - 3, 90);
                    DrawGradient(Color.FromArgb(30, 130, 245), Color.FromArgb(15, 100, 170), 3, Height / 2 - 1, Convert.ToInt32(_Value / _Maximum * Width), Height / 2 - 2, 90);
                    break;
            }

            //Borders
            G.DrawRectangle(Pens.DarkGray, 3, 3, Width - 7, Height - 7);
            G.FillRectangle(hb, 1, 1, Width, Height);
            DrawBorders(Pens.Gray, Pens.White, ClientRectangle);

        }
        public void Increment(int Amount)
        {
            if (this.Value + Amount > Maximum)
            {
                this.Value = Maximum;
            }
            else
            {
                this.Value += Amount;
            }
        }
    }


}


