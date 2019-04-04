// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Progress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.RedDwagon
{
    public class RedDwagonProgress : ThemeControl
    {
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
        private int _Value;
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 1;
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

        protected override void ColorHook()
        {
        }
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(34, 34, 34));
            switch (_Value)
            {
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    1:
                    DrawGradient(Color.FromArgb(255, 0, 0), Color.FromArgb(153, 0, 0), 3, 3, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height - 6, 90);
                    DrawGradient(Color.FromArgb(153, 0, 0), Color.FromArgb(255, 0, 0), 4, 4, Convert.ToInt32(_Value / _Maximum * Width) - 8, Height - 8, 90);
                    G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
                    G.DrawRectangle(Pens.Gray, 1, 1, Width - 3, Height - 3);
                    break;
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    0:
                    DrawGradient(Color.FromArgb(255, 0, 0), Color.FromArgb(153, 0, 0), 3, 3, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height - 6, 90);
                    DrawGradient(Color.FromArgb(153, 0, 0), Color.FromArgb(255, 0, 0), 4, 4, Convert.ToInt32(_Value / _Maximum * Width) - 8, Height - 8, 90);
                    G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
                    G.DrawRectangle(Pens.Gray, 1, 1, Width - 3, Height - 3);
                    break;
            }


        }
    }
}

