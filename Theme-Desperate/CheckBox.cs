// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Desperate
{

    public class DesperateCheck : ThemeControl
    {
        private bool _cStyle;
        public bool DarkTheme
        {
            get { return _cStyle; }
            set
            {
                _cStyle = value;
                Invalidate();
            }
        }
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
        public DesperateCheck()
        {
            Click += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);

            DarkTheme = true;
            CheckedState = false;
        }
        public override void PaintHook()
        {
            int Grad = 0;
            Color FontColor = default(Color);
            switch (DarkTheme)
            {
                case true:
                    Grad = 51;
                    FontColor = Color.White;
                    break;
                case false:
                    Grad = 200;
                    FontColor = Color.Black;
                    break;
            }
            G.Clear(Color.FromArgb(Grad, Grad, Grad));
            switch (CheckedState)
            {
                case true:
                    //DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(38, 38, 38), 0, 0, 15, 15, 90S)
                    DrawGradient(Color.FromArgb(132, 192, 240), Color.FromArgb(78, 123, 168), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(98, 159, 220), Color.FromArgb(62, 102, 147), 4, 4, 7, 7, 90);
                    break;
                case false:
                    DrawGradient(Color.FromArgb(80, 80, 80), Color.FromArgb(80, 80, 80), 0, 0, 15, 15, 90);
                    break;
            }
            G.DrawRectangle(Pens.Black, 0, 0, 14, 14);
            G.DrawRectangle(Pens.DimGray, 1, 1, 12, 12);
            DrawText(HorizontalAlignment.Left, FontColor, 17, 0);
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


