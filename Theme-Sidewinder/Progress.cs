// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Progress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sidewinder
{
    public class SideWinderProgress : Control
    {

        #region " Drawing "

        private int _Val = 0;
        private int _Min = 0;

        private int _Max = 100;
        public int Value
        {
            get { return _Val; }
            set
            {
                _Val = value;
                Invalidate();
            }
        }

        public int Minimum
        {
            get { return _Min; }
            set
            {
                _Min = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _Max; }
            set
            {
                _Max = value;
                Invalidate();
            }
        }

        public SideWinderProgress()
        {
            DoubleBuffered = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            //G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Color.White);

            if (!(Value == 0))
            {
                Helpers.FillRoundRect(G, new Rectangle(0, 0, Value / (Maximum * Width) - 1, Height - 1), 8, Color.FromArgb(213, 228, 150));
            }

            Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 8, Color.FromArgb(232, 235, 242));

        }

        #endregion

    }

}