// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonSubText.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Border
{


    public class BorderButtonSubText : ThemeControl152
    {
        protected override void ColorHook()
        {
        }
        private string _subtext;
        public string TextSub
        {
            get { return _subtext; }
            set
            {
                _subtext = value;
                Invalidate();
            }
        }
        private Brush B1;
        protected override void PaintHook()
        {
            G.Clear(BackColor);
            switch (State)
            {
                case MouseState.None:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), ClientRectangle);
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), ClientRectangle);
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), ClientRectangle);
                    break;
            }
            G.DrawString(Text, Font, Brushes.White, new Point(6, 8));
            Font SubFont = new Font(DefaultFont.FontFamily, Font.Size - 1);
            G.DrawString(_subtext, SubFont, new SolidBrush(Color.FromArgb(48, 48, 48)), new Point(6, 21));
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            DrawCorners(Color.FromArgb(15, 15, 15));
        }
    }
    
}


