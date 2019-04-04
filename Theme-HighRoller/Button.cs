// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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

  public class HighRollerButton : ThemeControl154
  {
      private Color ButtonColor;
      private Brush TextColor;
      private Pen Border;

      public HighRollerButton()
      {
          SetColor("Button", Color.ForestGreen);
          SetColor("Text", Color.White);
          SetColor("Border", Color.Black);
      }

      protected override void ColorHook()
      {
          ButtonColor = GetColor("Button");
          TextColor = GetBrush("Text");
          Border = GetPen("Border");
      }

      protected override void PaintHook()
      {
          G.Clear(ButtonColor);
          switch (State)
          {
              case MouseState.None:
                  G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                  DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                  break;
              case MouseState.Over:
                  G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Lime)), new Rectangle(0, 0, Width - 1, Height - 1));
                  G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                  DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                  break;
              case MouseState.Down:
                  G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                  G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                  DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                  break;
          }
      }
  }

}
