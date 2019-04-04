// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonBase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;



namespace Zeroit.Framework.UIThemes.PlayUI
{
    #region  Button Base

    public class PlayUIButtonBase : ContainerControl
    {

        public PlayUIButtonBase()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(110, 50);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;

            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(36, 38, 41), Color.FromArgb(36, 38, 41), 90.0F);

            G.FillEllipse(LGB1, new Rectangle(0, 9, 30, 30));
            G.FillEllipse(LGB1, new Rectangle(29, 0, 48, 48));
            G.FillEllipse(LGB1, new Rectangle(76, 9, 30, 30));

            LGB1.Dispose();
        }
    }

    #endregion
}