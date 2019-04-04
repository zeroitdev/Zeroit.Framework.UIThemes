// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Earn
{
    public class EarnControlBox : ThemeControl154
    {
        private int X;
        Color BG;
        Color Icons;

        SolidBrush glow;
        int a;
        int b;

        int c;
        protected override void ColorHook()
        {
            Icons = GetColor("Icon");
            BG = GetColor("Background");
            glow = GetBrush("Glow");
        }

        public EarnControlBox()
        {
            IsAnimated = true;
            SetColor("Icons", Color.FromArgb(240, 240, 240));
            SetColor("Icon", Color.FromArgb(240, 240, 240));
            SetColor("Background", Color.FromArgb(75, 77, 89));
            SetColor("Glow", Color.FromArgb(240, 240, 240));
            this.Size = new Size(44, 18);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if (X <= 22)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else
            {
                Parent.FindForm().Close();
            }
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(75, 77, 89));
            G.DrawString("0", new Font("Marlett", 8.25f), GetBrush("Icon"), new Point(5, 4));
            G.DrawString("r", new Font("Marlett", 10), GetBrush("Icon"), new Point(24, 5));
        }
    }


}

