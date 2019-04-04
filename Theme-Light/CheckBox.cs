// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightCheckBox : ThemeControl
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

        public LightCheckBox()
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
            switch (CheckedState)
            {
                case true:
                    HatchBrush hb = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
                    DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, 15, 15, 270);
                    DrawGradient(Color.FromArgb(35, Color.Black), Color.Transparent, 0, 0, 15, 15, 180);
                    G.FillRectangle(hb, 0, 0, 15, 15);
                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(34, 64, 160), 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(34, 64, 160), Color.FromArgb(27, 81, 255), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(27, 81, 255), Color.FromArgb(34, 64, 160), 4, 4, 7, 7, 90);
                    DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));
                    break;
                case false:
                    HatchBrush hb1 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
                    DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, 15, 15, 270);
                    DrawGradient(Color.FromArgb(35, Color.Black), Color.Transparent, 0, 0, 15, 15, 180);
                    G.FillRectangle(hb1, 0, 0, 15, 15);
                    break;
            }

            DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));

            DrawText(HorizontalAlignment.Left, this.ForeColor, 17, 0);
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


