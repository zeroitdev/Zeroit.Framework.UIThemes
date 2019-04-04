// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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
