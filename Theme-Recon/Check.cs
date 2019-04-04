// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Check.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Recon
{
    public class ReconCheck : ThemeControl
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

        public ReconCheck()
        {
            MouseDown += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
        }

        public override void PaintHook()
        {
            G.Clear(BackColor);
            DrawGradient(Color.FromArgb(18, 18, 18), Color.FromArgb(28, 28, 28), 0, 0, 15, 15, 90);

            switch (CheckedState)
            {
                case true:

                    DrawGradient(Color.FromArgb(18, 18, 18), Color.FromArgb(28, 28, 28), 0, 0, 15, 15, 270);
                    DrawGradient(Color.FromArgb(100, 40, 40, 40), Color.Transparent, 0, 0, 15, 15, 90);

                    DrawGradient(Color.FromArgb(5, this.ForeColor), Color.Transparent, 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(9, this.ForeColor), Color.Transparent, 0, 0, 15, 15, 270);

                    G.DrawRectangle(new Pen(Color.FromArgb(10, 10, 10)), 3, 3, 11, 11);
                    DrawGradient(Color.FromArgb(50, 50, 50), Color.FromArgb(30, 30, 30), 0, 0, 15, 15, 90);
                    break;
            }

            DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), new Rectangle(0, 0, 15, 15));
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


