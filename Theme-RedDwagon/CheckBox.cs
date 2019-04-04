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

namespace Zeroit.Framework.UIThemes.RedDwagon
{
    public class RedDwagonCheckBox : ThemeControl
    {
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
        public RedDwagonCheckBox()
        {
            Click += changeCheck;
            Size = new Size(158, 16);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            Color FontColor = default(Color);
            FontColor = Color.Red;

            G.Clear(Color.FromArgb(34, 34, 34));
            switch (CheckedState)
            {
                case true:
                    DrawGradient(Color.FromArgb(255, 0, 0), Color.FromArgb(153, 0, 0), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(255, 0, 0), Color.FromArgb(153, 0, 0), 4, 4, 7, 7, 90);
                    break;
                case false:
                    DrawGradient(Color.FromArgb(34, 34, 34), Color.FromArgb(34, 34, 34), 0, 0, 15, 15, 90);
                    break;
            }
            G.DrawRectangle(Pens.Black, 0, 0, 14, 14);
            G.DrawRectangle(Pens.Red, 1, 1, 12, 12);
            DrawText(Brushes.Red, HorizontalAlignment.Left, 17, 0);
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

