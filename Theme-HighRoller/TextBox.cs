﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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

  public class HighRollerTextBox : ThemeControl153
  {
      private TextBox txtbox = new TextBox();

      private bool _PassMask;
      public bool UsePasswordMask
      {
          get
          {
              return _PassMask;
          }
          set
          {
              _PassMask = value;
              Invalidate();
          }
      }
      private int _maxchars;
      public int MaxCharacters
      {
          get
          {
              return _maxchars;
          }
          set
          {
              _maxchars = value;
          }
      }

      public HighRollerTextBox()
      {
          txtbox.TextAlign = HorizontalAlignment.Left;
          txtbox.BorderStyle = BorderStyle.None;
          txtbox.Location = new Point(5, 6);
          txtbox.Font = new Font("Segoe UI", 9);
          Controls.Add(txtbox);
          Text = "";
          txtbox.Text = "";
          this.Size = new Size(135, 35);
          Transparent = true;
          BackColor = Color.Transparent;
          SubscribeToEvents();
      }

      private Pen P1;

      protected override void ColorHook()
      {
      }

      protected override void PaintHook()
      {
          G.Clear(Color.ForestGreen);
          switch (UsePasswordMask)
          {
              case true:
                  txtbox.UseSystemPasswordChar = true;
                  break;
              case false:
                  txtbox.UseSystemPasswordChar = false;
                  break;
          }
          Size = new Size(Width, 25);
          txtbox.BackColor = Color.ForestGreen;
          txtbox.ForeColor = Color.White;
          txtbox.Font = Font;
          txtbox.Size = new Size(Width - 10, txtbox.Height - 10);
          txtbox.MaxLength = MaxCharacters;
          DrawBorders(new Pen(new SolidBrush(Color.Black)));
          DrawCorners(BackColor);
      }
      public void TextChngTxtBox(object sender, EventArgs e)
      {
          Text = txtbox.Text;
      }
      public void TextChng(object sender, EventArgs e)
      {
          txtbox.Text = Text;
      }


      private bool EventsSubscribed = false;
      private void SubscribeToEvents()
      {
          if (EventsSubscribed)
              return;
          else
              EventsSubscribed = true;

          txtbox.TextChanged += TextChngTxtBox; ;
          base.TextChanged += TextChng;
      }


  }

}
