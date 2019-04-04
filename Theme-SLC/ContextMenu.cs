// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ContextMenu.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCContextMenu"
    public class SLCContextMenu : ContextMenuStrip
    {

        public SLCContextMenu()
        {
            Renderer = new ToolStripProfessionalRenderer(new SLCColorTable());
            ForeColor = Color.FromArgb(1, 75, 124);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            base.OnPaint(e);
        }

    }

    #endregion

}

