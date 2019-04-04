// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.iTalk
{
    #region  Separator 

    public class iTalkSeparator : Control
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            myPen = new Pen(myBrush);
        }

        #region  Variables 

        private SolidBrush myBrush = new SolidBrush(Color.FromArgb(184, 183, 188));
        private Pen myPen;

        #endregion

        public iTalkSeparator()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.Size = new Size(120, 10);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(myPen, 0, 5, Width, 5); // Draw the line
        }
    }

    #endregion
}