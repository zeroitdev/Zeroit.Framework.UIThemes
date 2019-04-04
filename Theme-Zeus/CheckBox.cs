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

namespace Zeroit.Framework.UIThemes.Zeus
{
    public class ZeusCheckBox : ThemeControl
    {

        #region " Properties "


        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }


        //private  _ChangeCheck;
        public void ChangeCheck(object sender, EventArgs e)
        {
            switch (Checked)
            {
                case true:
                    Checked = false;
                    break;
                case false:
                    Checked = true;
                    break;
            }
        }

        #endregion

        #region " Options "

        public ZeusCheckBox()
        {
            Click += ChangeCheck;
            Checked = false;
            this.Size = new Size(115, 23);
            this.MinimumSize = new Size(0, 23);
            this.MaximumSize = new Size(900, 23);
        }

        #endregion

        #region " PaintHook "


        public override void PaintHook()
        {
            Color C1 = Color.FromArgb(38, 38, 38);
            Color C2 = Color.AliceBlue;
            Color C3 = Color.FromArgb(150, 255, 255);
            Pen P1 = Pens.Black;
            Pen P2 = Pens.AliceBlue;

            G.Clear(C1);

            switch (MouseState)
            {

                case State.MouseNone:
                    DrawText(HorizontalAlignment.Center, C2, 0, 1);
                    break;
                case State.MouseOver:
                    DrawText(HorizontalAlignment.Center, C2, 0, 1);
                    G.DrawRectangle(P2, 0, 0, Width - 1, Height - 1);
                    break;
                case State.MouseDown:
                    DrawText(HorizontalAlignment.Center, C2, 0, 1);
                    break;
            }

            switch (Checked)
            {
                case true:
                    DrawGradient(C2, C3, 6, 6, 10, 10, 90);
                    G.DrawRectangle(P2, 6, 6, 10, 10);
                    G.DrawRectangle(P1, 5, 5, 11, 11);
                    break;
                case false:
                    DrawGradient(C1, C1, 6, 6, 5, 5, 90);
                    G.DrawRectangle(P2, 6, 6, 10, 10);
                    break;
            }

        }

        #endregion


    }

}


