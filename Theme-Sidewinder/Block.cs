// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Block.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sidewinder
{
    public class SideWinderBlock : GroupBox
    {

        #region " Drawing "


        private Graphics G;
        public SideWinderBlock()
        {
            DoubleBuffered = true;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Color.White);

            using (Pen P = new Pen(Color.FromArgb(220, 220, 220)) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {

                G.DrawRectangle(P, Helpers.FullRectangle(Size, true));
            }

        }


        #endregion


    }

}