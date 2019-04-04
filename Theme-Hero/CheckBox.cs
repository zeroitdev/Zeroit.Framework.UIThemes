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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Hero
{
    public class HeroCheckBox : ThemeControl
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

        public HeroCheckBox()
        {
            Click += changeCheck;
            //Default properties
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
        }

        public override void PaintHook()
        {
            G.Clear(BackColor);

            switch (CheckedState)
            {
                case true:

                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(38, 38, 38), 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(80, 80, 80), Color.FromArgb(60, 60, 60), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(80, 80, 80), Color.FromArgb(60, 60, 60), 4, 4, 7, 7, 90);
                    break;
                case false:
                    DrawGradient(Color.FromArgb(211, 211, 211), Color.FromArgb(200, 200, 200), 0, 0, 15, 15, 90);
                    break;
            }


            DrawBorders(Pens.Black, Pens.DimGray, new Rectangle(0, 0, 15, 15));
            DrawText(HorizontalAlignment.Left, Color.FromArgb(30, 30, 30), 17, 0);
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


