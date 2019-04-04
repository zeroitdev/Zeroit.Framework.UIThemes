// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Hacker
{
    public class HackerCheckBox : ThemeControl154
    {

        #region "Events"
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
        #endregion

        public HackerCheckBox()
        {
            Click += changeChecked;
            Transparent = true;
            Size = new Size(150, 16);
            Font = new Font("Arial", 9);
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.Transparent);
            //Background
            Rectangle rect = new Rectangle(0, 0, 45, 15);
            G.FillRectangle(Brushes.Black, rect);
            //On And Off Switches
            if ((_Checked == false))
            {
                G.DrawString("OFF", Font, Brushes.Red, 3, 1);
                Rectangle offRect = new Rectangle(31, 2, 12, 12);
                LinearGradientBrush offLGB = new LinearGradientBrush(offRect, Color.FromArgb(150, Color.DarkRed), Color.DarkRed, 90f);
                G.FillRectangle(offLGB, offRect);
                G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(255, 200, 0, 0))), new Rectangle(31, 2, 11, 11));
            }
            else
            {
                G.DrawString("ON", Font, Brushes.White, 18, 1);
                Rectangle onRect = new Rectangle(2, 2, 12, 12);
                LinearGradientBrush onLGB = new LinearGradientBrush(onRect, Color.FromArgb(150, Color.Gainsboro), Color.LightGray, 90f);
                G.FillRectangle(onLGB, onRect);
                G.DrawRectangle(Pens.White, new Rectangle(2, 2, 11, 11));
            }
            //Text Area
            Rectangle textAreaRect = new Rectangle(45, 0, Width - 1, Height - 1);
            HatchBrush textAreaHB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(200, 16, 16, 16), Color.FromArgb(200, 14, 14, 14));
            G.FillRectangle(textAreaHB, textAreaRect);
            DrawText(new SolidBrush(Color.Lime), HorizontalAlignment.Left, 50, 0);
            //Border
            DrawBorders(Pens.Black);
        }
    }


}


