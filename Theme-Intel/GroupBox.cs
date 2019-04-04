// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Intel
{
    public class iGroupBox : ThemeContainer154
    {
        protected override void ColorHook()
        {
        }

        private bool showTitleText;
        public bool _ShowTitleText
        {
            get { return showTitleText; }
            set
            {
                showTitleText = value;
                Invalidate();
            }
        }

        public iGroupBox()
        {
            ControlMode = true;
            showTitleText = true;
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(45, 45, 45));

            GraphicsPath gp = CreateRound(new Rectangle(0, 0, Width - 1, Height - 1), 8);
            G.FillPath(new SolidBrush(Color.FromArgb(45, 45, 45)), gp);
            if (showTitleText)
            {
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(60, 60, 60))), 0, 19, Width - 1, 19);
                G.DrawLine(Pens.DeepSkyBlue, 0, 20, Width - 1, 20);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(60, 60, 60))), 0, 21, Width - 1, 21);
                G.DrawString(Text, new Font("Verdana", 9), Brushes.Black, new Point(5, 4));
                G.DrawString(Text, new Font("Verdana", 9), Brushes.Silver, new Point(4, 3));
            }
            G.DrawPath(Pens.DeepSkyBlue, gp);

        }

    }


}


