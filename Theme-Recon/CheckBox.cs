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

namespace Zeroit.Framework.UIThemes.Recon
{
    public class ReconCheckBox : ThemeControl
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

        public ReconCheckBox()
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
            DrawGradient(Color.FromArgb(22, 22, 22), Color.FromArgb(32, 32, 32), 0, 0, 15, 15, 90);
            switch (CheckedState)
            {
                case true:
                    DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), new Rectangle(0, 0, 15, 15));
                    G.DrawString("a", new Font("Marlett", 12), Brushes.Black, new Point(-3, -1));
                    break;
                case false:
                    DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), new Rectangle(0, 0, 15, 15));
                    break;
            }

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


