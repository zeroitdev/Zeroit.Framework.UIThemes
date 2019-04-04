// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
