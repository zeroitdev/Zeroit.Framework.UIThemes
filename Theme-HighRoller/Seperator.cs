﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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

  public class HighRollerSeperator : ThemeControl
  {
      private Color _Color1 = Color.ForestGreen;
      public Color Color1
      {
          get
          {
              return _Color1;
          }
          set
          {
              _Color1 = value;
          }
      }

      private Color _Color2 = Color.ForestGreen;
      public Color Color2
      {
          get
          {
              return _Color2;
          }
          set
          {
              _Color2 = value;
          }
      }

      public HighRollerSeperator()
      {
          AllowTransparent();
          BackColor = Color.Transparent;
          Size S = new Size(150, 10);
          Size = S;
      }

      public override void PaintHook()
      {
          G.Clear(BackColor);

          G.DrawLine(new Pen(_Color1), 0, Height / 2, Width, Height / 2); //Draw the first color
          G.DrawLine(new Pen(_Color2), 0, Height / 2 + 1, Width, Height / 2 + 1); //Draw the second color
      }
  }

}
