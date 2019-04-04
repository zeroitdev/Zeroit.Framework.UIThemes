// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;


namespace Zeroit.Framework.UIThemes.Desperate
{

    public class DesperateTopButton : ThemeControl
    {
        private Color _aColor;
        public Color AccentColor
        {
            get { return _aColor; }
            set
            {
                _aColor = value;
                Invalidate();
            }
        }
        private bool _cStyle;
        public bool DarkTheme
        {
            get { return _cStyle; }
            set
            {
                _cStyle = value;
                Invalidate();
            }
        }
        public DesperateTopButton()
        {
            Size = new Size(11, 5);
            AccentColor = Color.DodgerBlue;
            DarkTheme = true;
        }
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(102, 102, 102));
            int GradA = 0;
            int GradB = 0;
            int GradC = 0;
            switch (DarkTheme)
            {
                case true:
                    GradA = 61;
                    GradB = 49;
                    GradC = 51;
                    break;
                case false:
                    GradA = 200;
                    GradB = 155;
                    GradC = 155;
                    break;
            }
            switch (MouseState)
            {
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(GradA, GradA, GradA), Color.FromArgb(GradB, GradB, GradB), 0, 0, Width, Height, 90);
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(GradA, GradA, GradA), Color.FromArgb(GradB, GradB, GradB), 0, 0, Width, Height, 90);
                    break;
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(GradB, GradB, GradB), Color.FromArgb(GradA, GradA, GradA), 0, 0, Width, Height, 90);
                    break;
            }
            DrawBorders(new Pen(new SolidBrush(AccentColor)), Pens.Transparent, ClientRectangle);
            DrawCorners(Color.FromArgb(GradC, GradC, GradC), ClientRectangle);
        }
    }

}


