// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;



namespace Zeroit.Framework.UIThemes.MonoFlat
{
    #region  Separator

    public class MonoFlatSeparator : Control
    {

        public MonoFlatSeparator()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.Size = (System.Drawing.Size)(new Point(120, 10));
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(45, 57, 68)), 0, 5, Width, 5);
        }
    }

    #endregion
}