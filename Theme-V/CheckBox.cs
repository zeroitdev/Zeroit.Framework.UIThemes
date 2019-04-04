// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.V
{
    public class VCheckBox : ThemeControl154
    {
        private Pen P1;
        private Brush B1;
        private Brush B2;
        private Brush B3;
        private bool _Checked = false;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }
        public VCheckBox()
        {
            Click += changeChecked;
            BackColor = Color.Transparent;
            Transparent = true;
            Size = new Size(150, 16);
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
            B1 = new SolidBrush(Color.FromArgb(15, Color.FromArgb(26, 26, 26)));
            B2 = new SolidBrush(Color.White);
            B3 = new SolidBrush(Color.FromArgb(0, 0, 0));
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.FillRectangle(B3, 0, 0, 45, 15);
            G.DrawRectangle(P1, 0, 0, 45, 15);
            if ((_Checked == false))
            {
                G.DrawString("OFF", Font, Brushes.Gray, 3, 1);
                G.FillRectangle(new LinearGradientBrush(new Rectangle(29, -1, 13, 16), Color.FromArgb(35, 35, 35), Color.FromArgb(25, 25, 25), 90), 29, -1, 13, 16);
            }
            else
            {
                DrawGradient(Color.FromArgb(10, 10, 10), Color.FromArgb(20, 20, 20), 15, 2, 28, 11, 90);
                G.DrawString("ON", Font, Brushes.White, 18, 0);
                G.FillRectangle(new LinearGradientBrush(new Rectangle(2, -1, 13, 16), Color.FromArgb(80, 80, 80), Color.FromArgb(60, 60, 60), 90), 2, -1, 13, 16);
            }
            G.FillRectangle(B1, 2, 2, 41, 11);
            DrawText(B2, HorizontalAlignment.Left, 50, 0);
        }
    }
}




