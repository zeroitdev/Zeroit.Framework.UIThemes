// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

  public class HighRollerGroupBox : ThemeContainer154
  {
      public HighRollerGroupBox()
      {
          ControlMode = true;
          SetColor("Border", Color.Black);
          SetColor("Header", Color.ForestGreen);
          SetColor("Text", Color.White);
      }

      private Pen Border;
      private Brush HeaderColor;
      private Brush TextColor;

      protected override void ColorHook()
      {
          Border = GetPen("Border");
          HeaderColor = GetBrush("Header");
          TextColor = GetBrush("Text");
      }

      protected override void PaintHook()
      {
          G.Clear(BackColor);
          G.FillRectangle(HeaderColor, new Rectangle(0, 0, Width - 1, 25));
          G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 25));
          G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
          G.DrawString(Text, Font, TextColor, new Point(7, 6));
      }
  }

}
