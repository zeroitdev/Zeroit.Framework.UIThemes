// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Icon.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    public class MetroDiskIcon : Button
    {

        #region " Variables"

        private Color _MDColor_border;
        private Color _MDColor_click;

        private Color _MDColor_hover;
        #endregion

        #region " Properties"
        public Color MDcolor_border
        {
            get { return _MDColor_border; }
            set { _MDColor_border = value; }
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


        public MetroDiskIcon()
        {
            MouseUp += Metro_MouseUp;
            MouseLeave += Metro_MouseLeave;
            MouseHover += MDIcon_MouseHover;
            MouseEnter += Metro_MouseEnter;
            MouseDown += Metro_MouseDown;
            this.Size = new Size(33, 33);
            this.Text = "";
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = BackColor;
            this.Font = new System.Drawing.Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
            this.ForeColor = Color.White;
            this.FlatAppearance.BorderColor = _MDColor_border;
            this.FlatAppearance.MouseDownBackColor = _MDColor_click;
            this.FlatAppearance.MouseOverBackColor = _MDColor_hover;
            this.FlatAppearance.BorderSize = 2;
        }

        private void Metro_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.BackColor = _MDColor_click;
        }

        private void Metro_MouseEnter(object sender, System.EventArgs e)
        {
            this.BackColor = _MDColor_hover;
        }

        private void MDIcon_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = _MDColor_hover;
        }

        private void Metro_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = BackColor;
        }

        private void Metro_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.BackColor = _MDColor_hover;
        }

    }
}