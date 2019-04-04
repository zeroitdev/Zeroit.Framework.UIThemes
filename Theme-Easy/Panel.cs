// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Panel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Easy
{
    public class EasyPanel : Panel
    {
        public string _PanelText;

        [Category("Appearance")]
        public string PanelText
        {
            get
            {
                return _PanelText;
            }
            set
            {
                _PanelText = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            int x = ClientSize.Width;
            int y = ClientSize.Height;

            g.FillRectangle(new SolidBrush(Color.FromArgb(25, 0, 0, 0)), new Rectangle(0, 0, x, 25));

            if (PanelText == null)
            {
                _PanelText = Name;
            }

            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), new Rectangle(0, 0, x, y));
            g.DrawString(_PanelText, Font, new SolidBrush(Color.White), new Point(5, 5));

            g.Dispose();
        }
    }
}
