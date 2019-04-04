// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Toggle.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Zeroit.Framework.UIThemes.Visible
{
    public class VIToggle : ThemeControl154
    {
        private Pen P1;
        private Pen P2;
        private Brush B1;
        private Brush B2;
        private Brush B3;
        private bool _Checked = false;
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }
        public VIToggle()
        {
            BackColor = Color.Transparent;
            Transparent = true;
            Size = new Size(120, 25);
            SubscribeToEvents();
        }
        public void changeChecked(object sender, EventArgs e)
        {
            switch (_Checked)
            {
                case false:
                    _Checked = true;
                    break;
                case true:
                    _Checked = false;
                    break;
            }
        }
        protected override void ColorHook()
        {
            P1 = new Pen(Color.FromArgb(0, 0, 0));
            P2 = new Pen(Color.FromArgb(24, 24, 24));
            B1 = new SolidBrush(Color.FromArgb(15, Color.FromArgb(26, 26, 26)));
            B2 = new SolidBrush(Color.White);
            B3 = new SolidBrush(Color.FromArgb(0, 0, 0));
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);

            if (_Checked == false)
            {
                G.FillRectangle(B3, 4, 4, 45, 15);
                G.DrawRectangle(P1, 4, 4, 45, 15);
                G.DrawRectangle(P2, 5, 5, 43, 13);
                G.DrawString("OFF", Font, Brushes.Gray, 7, 5);
                G.FillRectangle(new LinearGradientBrush(new Rectangle(32, 2, 13, 19), Color.FromArgb(35, 35, 35), Color.FromArgb(25, 25, 25), 90), 32, 2, 13, 19);
                G.DrawRectangle(P2, 32, 2, 13, 19);
                G.DrawRectangle(P1, 33, 3, 11, 17);
                G.DrawRectangle(P1, 31, 1, 15, 21);
            }
            else
            {
                G.FillRectangle(B3, 4, 4, 45, 15);
                G.DrawRectangle(P1, 4, 4, 45, 15);
                G.DrawRectangle(P2, 5, 5, 43, 13);
                G.DrawString("ON", Font, Brushes.White, 23, 5);
                G.FillRectangle(new LinearGradientBrush(new Rectangle(8, 2, 13, 19), Color.FromArgb(80, 80, 80), Color.FromArgb(60, 60, 60), 90), 8, 2, 13, 19);
                G.DrawRectangle(P2, 8, 2, 13, 19);
                G.DrawRectangle(P1, 9, 3, 11, 17);
                G.DrawRectangle(P1, 7, 1, 15, 21);
            }
            G.FillRectangle(B1, 2, 2, 41, 11);
            DrawText(B2, HorizontalAlignment.Left, 50, 0);
        }


        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.Click += changeChecked;
        }

    }
}


