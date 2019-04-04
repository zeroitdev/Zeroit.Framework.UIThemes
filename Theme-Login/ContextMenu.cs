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

using System.Drawing.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInContextMenu : ContextMenuStrip
    {

        #region "Declarations"


        private Color _FontColour = Color.FromArgb(55, 255, 255);
        #endregion

        #region "Properties"

        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        #endregion

        #region "Draw Control"

        public LogInContextMenu()
        {
            Renderer = new ToolStripProfessionalRenderer(new LogInColourTable());
            ShowCheckMargin = false;
            ShowImageMargin = false;
            ForeColor = Color.FromArgb(255, 255, 255);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            base.OnPaint(e);
        }

        #endregion

    }

}


