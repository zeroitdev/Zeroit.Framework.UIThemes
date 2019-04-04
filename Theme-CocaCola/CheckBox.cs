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

namespace Zeroit.Framework.UIThemes.Cola
{
    public class CCCheckBox : ThemeControl151
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
        public CCCheckBox()
        {
            Click += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);


            CheckedState = false;
        }
        protected override void PaintHook()
        {

            G.Clear(BackColor);

            //G.Clear(Color.FromArgb(192, 0, 0));

            //int Grad = 0;

            //      if(Grad == 1)
            //      {

            //      }
            //Color FontColor = new Color();

            //      switch (1) {
            //	case true:
            //		Grad = 51;
            //		FontColor = Color.White;
            //		break;
            //	case false:
            //		Grad = 200;
            //		FontColor = Color.White;
            //		break;
            //}

            switch (CheckedState)
            {
                case true:
                    //DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(38, 38, 38), 0, 0, 15, 15, 90S)
                    DrawGradient(Color.White, Color.Silver, 3, 3, 9, 9, 90);
                    DrawGradient(Color.WhiteSmoke, Color.Gray, 4, 4, 7, 7, 90);
                    break;
                case false:
                    DrawGradient(Color.FromArgb(192, 0, 0), Color.FromArgb(216, 216, 216), 0, 0, 15, 15, 90);
                    break;
            }
            G.DrawRectangle(Pens.RosyBrown, 0, 0, 14, 14);
            DrawText(new SolidBrush(ForeColor), HorizontalAlignment.Center, 0, 0);
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


        protected override void ColorHook()
        {
        }
    }


}

