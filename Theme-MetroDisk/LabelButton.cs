// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="LabelButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    public class MetroDisklblButton : Label
    {

        #region " Variables"

        private Color _MDColor_normal;
        private Color _MDColor_click;

        private Color _MDColor_hover;
        #endregion

        #region " Properties"
        public Color MDcolor_normal
        {
            get { return _MDColor_normal; }
            set { _MDColor_normal = value; }
        }

        public Color MDcolor_click
        {
            get { return _MDColor_click; }
            set { _MDColor_click = value; }
        }

        public Color MDcolor_hover
        {
            get { return _MDColor_hover; }
            set { _MDColor_hover = value; }
        }

        #endregion


        public MetroDisklblButton()
        {
            MouseUp += Metro_MouseUp;
            MouseLeave += Metro_MouseLeave;
            MouseHover += MDIcon_MouseHover;
            MouseEnter += Metro_MouseEnter;
            MouseDown += Metro_MouseDown;
            _MDColor_click = Color.DarkGray;
            _MDColor_hover = Color.LightGray;
            _MDColor_normal = Color.Silver;


            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;
            this.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
            this.ForeColor = _MDColor_normal;
        }

        private void Metro_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.ForeColor = _MDColor_click;
        }

        private void Metro_MouseEnter(object sender, System.EventArgs e)
        {
            this.ForeColor = _MDColor_hover;
        }

        private void MDIcon_MouseHover(object sender, EventArgs e)
        {
            this.ForeColor = _MDColor_hover;
        }

        private void Metro_MouseLeave(object sender, System.EventArgs e)
        {
            this.ForeColor = _MDColor_normal;
        }

        private void Metro_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.ForeColor = _MDColor_hover;
        }

    }

}