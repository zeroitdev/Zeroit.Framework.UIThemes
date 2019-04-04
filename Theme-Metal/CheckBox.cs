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

namespace Zeroit.Framework.UIThemes.Metal
{
    public class Checkbox : ThemeControl
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
        public Checkbox()
        {
            Click += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
        }
        private Pen P1;
        private Pen P2;
        public override void PaintHook()
        {
            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(90, 90, 90));

            G.Clear(Color.FromArgb(63, 63, 63));

            switch (CheckedState)
            {
                case true:
                    DrawGradient(Color.FromArgb(30, 30, 30), Color.FromArgb(20, 20, 20), 3, 3, 9, 9, 90);
                    break;
                case false:
                    DrawGradient(Color.FromArgb(60, 60, 60), Color.FromArgb(60, 60, 60), 0, 0, 15, 15, 90);

                    break;
            }
            G.DrawRectangle(P2, 0, 0, 14, 14);
            G.DrawRectangle(P1, 1, 1, 12, 12);
            DrawText(HorizontalAlignment.Left, Color.White, 17, 0);

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
