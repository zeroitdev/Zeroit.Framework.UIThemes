// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ContextMenuStrip.cs" company="Zeroit Dev Technologies">
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
    #region  ContextMenuStrip 

    public class iTalkContextMenuStrip : ContextMenuStrip
    {
        public iTalkContextMenuStrip()
        {
            this.Renderer = new ControlRenderer();
        }

        public ControlRenderer Renderer
        {
            get
            {
                return (ControlRenderer)base.Renderer;
            }
            set
            {
                base.Renderer = value;
            }
        }
    }

    #endregion
}