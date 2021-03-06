﻿// ***********************************************************************
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
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Zeroit.Framework.UIThemes.HighRoller
{

  public class HighRollerProgressBar : ThemeControl
  {

      private int _Maxiumum = 100;
      public int Maximum
      {
          get
          {
              return _Maxiumum;
          }
          set
          {
              if (value < 1)
              {
                  value = 1;
              }
              if (value < _Value)
              {
                  _Value = value;
              }

              _Maxiumum = value;
              Invalidate();
          }
      }


      private int _Value;
      public int Value
      {
          get
          {
              return _Value;
          }
          set
          {
              if (value == _Maxiumum)
              {
                  value = _Maxiumum;
              }

              _Value = value;
              Invalidate();
          }
      }


      public override void PaintHook()
      {
          G.Clear(Color.LightGray);

          G.FillRectangle(Brushes.ForestGreen, 0, 0, Convert.ToInt32((_Value / (double)_Maxiumum) * Width), Height);

          G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
      }
  }

}
