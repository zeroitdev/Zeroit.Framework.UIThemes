// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Positron
{

    public class PositronControlBox : ThemeControl154
    {
        private Color TG;
        private Color BG;
        private Brush TC;
        private Brush H;
        private Pen B;

        private Pen IB;
        public PositronControlBox()
        {
            SetColor("TopG", Color.FromArgb(220, 220, 220));
            SetColor("BottomG", Color.FromArgb(200, 200, 200));
            SetColor("Text", Color.FromArgb(100, 100, 100));
            SetColor("Border", Color.FromArgb(150, 150, 150));
            SetColor("Inside", Color.FromArgb(200, 200, 200));
            SetColor("Hover", Color.FromArgb(210, 210, 210));
            LockHeight = 22;
            LockWidth = 22;
        }
        protected override void ColorHook()
        {
            TG = GetColor("TopG");
            BG = GetColor("BottomG");
            TC = GetBrush("Text");
            B = GetPen("Border");
            IB = GetPen("Inside");
            H = GetBrush("Hover");
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
        }

        protected override void PaintHook()
        {
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), TG, BG, 90f);
                    G.FillRectangle(LGB1, new Rectangle(0, 0, 22, 22));
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                case MouseState.Over:
                    G.FillRectangle(H, new Rectangle(0, 0, 22, 22));
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                case MouseState.Down:
                    LinearGradientBrush LGB3 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), BG, TG, 90f);
                    G.FillRectangle(LGB3, new Rectangle(0, 0, 22, 22));
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }
            DrawBorders(IB);
            G.DrawString("r", new Font("Marlett", 8), TC, 4, 6);
        }
    }
}

