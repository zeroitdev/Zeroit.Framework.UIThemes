// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Switch.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightSwitch : ThemeControl
    {

        #region " Properties "
        private bool _CheckedState;
        public bool CheckedState
        {
            get { return _CheckedState; }
            set
            {
                _CheckedState = value;
                Invalidate();
            }
        }
        #endregion

        public LightSwitch()
        {
            MouseDown += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
        }

        public override void PaintHook()
        {
            G.Clear(this.Parent.BackColor);
            this.ForeColor = this.Parent.ForeColor;
            HatchBrush hb = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
            DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, 30, 15, 270);
            DrawGradient(Color.FromArgb(35, Color.Black), Color.Transparent, 0, 0, 15, 15, 180);
            DrawGradient(Color.FromArgb(35, Color.Black), Color.Transparent, 15, 0, 16, 15, 0);
            G.FillRectangle(hb, 1, 1, Width, Height);
            switch (CheckedState)
            {
                case true:
                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(4, 128, 7), 0, 0, 13, 15, 90);
                    DrawGradient(Color.FromArgb(4, 128, 7), Color.FromArgb(17, 196, 21), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(17, 196, 21), Color.FromArgb(4, 128, 7), 4, 4, 7, 7, 90);
                    G.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, 13, 14));
                    break;
                case false:
                    DrawGradient(Color.FromArgb(160, 0, 0), Color.FromArgb(109, 16, 16), 15, 0, 13, 15, 90);
                    DrawGradient(Color.FromArgb(109, 16, 16), Color.FromArgb(212, 20, 20), 18, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(212, 20, 20), Color.FromArgb(109, 16, 16), 19, 4, 7, 7, 90);
                    G.DrawRectangle(Pens.LightGray, new Rectangle(15, 0, 13, 14));
                    break;
            }

            DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 30, 15));
            DrawText(HorizontalAlignment.Left, this.ForeColor, 32, 0);
        }

        public void changeCheck(object sender, EventArgs e)
        {
            switch (CheckedState)
            {
                case true:
                    CheckedState = false;
                    break;
                case false:
                    CheckedState = true;
                    break;
            }
        }
    }

}


