// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.VisualStudio
{
    public class VisualStudioGroupBox : ContainerControl
    {
        #region Declarations
        private Color _MainColour = Color.FromArgb(37, 37, 38);
        private Color _HeaderColour = Color.FromArgb(45, 45, 48);
        private Color _TextColour = Color.FromArgb(129, 129, 131);
        private Color _BorderColour = Color.FromArgb(2, 118, 196);
        #endregion

        #region Properties

        [Category("Colours")]
        public Color BorderColour
        {
            get
            {
                return _BorderColour;
            }
            set
            {
                _BorderColour = value;
            }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get
            {
                return _TextColour;
            }
            set
            {
                _TextColour = value;
            }
        }

        [Category("Colours")]
        public Color HeaderColour
        {
            get
            {
                return _HeaderColour;
            }
            set
            {
                _HeaderColour = value;
            }
        }

        [Category("Colours")]
        public Color MainColour
        {
            get
            {
                return _MainColour;
            }
            set
            {
                _MainColour = value;
            }
        }

        #endregion

        #region Draw Control
        public VisualStudioGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(160, 110);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.FillRectangle(new SolidBrush(_MainColour), new Rectangle(0, 28, Width, Height));
            g.FillRectangle(new SolidBrush(_HeaderColour), new Rectangle(0, 0, Width, 28));
            g.FillRectangle(new SolidBrush(Color.FromArgb(33, 33, 33)), new Rectangle(0, 28, Width, 1));
            g.DrawString(Text, Font, new SolidBrush(_TextColour), new Point(5, 5));
            g.DrawRectangle(new Pen(_BorderColour, 2F), new Rectangle(0, 0, Width, Height));
            g.InterpolationMode = (InterpolationMode)7;
        }
        #endregion

    }

}
