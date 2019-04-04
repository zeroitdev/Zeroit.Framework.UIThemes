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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Xbox
{

    public class XboxCheckBox : ThemeControl
    {
        private bool _cStyle;
        public bool SWTheme
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
        public XboxCheckBox()
        {
            Click += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);

            SWTheme = true;
            CheckedState = false;
        }
        public override void PaintHook()
        {
            G.Clear(Color.LightGray);
            DrawGradient(Color.GhostWhite, Color.LightGray, 0, 0, Width, 20, 90);
            switch (CheckedState)
            {
                case true:
                    //DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(38, 38, 38), 0, 0, 15, 15, 90S)
                    DrawGradient(Color.FromArgb(0, 255, 36), (Color.FromArgb(0, 140, 20)), 4, 4, 7, 7, 90);
                    break;
                case false:
                    DrawGradient(Color.GhostWhite, Color.LightGray, 0, 0, 15, 15, 90);
                    break;
            }
            G.DrawRectangle(Pens.Green, 1, 1, 12, 12);
            G.DrawRectangle(Pens.Green, 1, 1, 12, 12);
            DrawText(HorizontalAlignment.Left, Color.FromArgb(190, 190, 190), 17, 0);
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


