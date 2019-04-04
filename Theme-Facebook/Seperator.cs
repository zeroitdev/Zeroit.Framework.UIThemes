// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Facebook
{

    public class FacebookSeperator : Control
    {

        #region "Declarations"
        private Color _SeperatorColour = Color.FromArgb(14, 44, 109);
        #endregion
        private Style _Alignment = Style.Horizontal;

        #region "Properties"

        public enum Style
        {
            Horizontal,
            Verticle
        }
        [Category("Control")]
        public Style Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }

        [Category("Colours")]
        public Color SeperatorColour
        {
            get { return _SeperatorColour; }
            set { _SeperatorColour = value; }
        }

        #endregion

        #region "Draw Control"
        public FacebookSeperator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(30, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            dynamic G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            var _with15 = G;
            _with15.SmoothingMode = SmoothingMode.HighQuality;
            _with15.PixelOffsetMode = PixelOffsetMode.HighQuality;
            switch (_Alignment)
            {
                case Style.Horizontal:
                    _with15.DrawLine(new Pen(_SeperatorColour, 0.5f), new Point(0, Height / 2), new Point(Width, Height / 2));
                    break;
                case Style.Verticle:
                    _with15.DrawLine(new Pen(_SeperatorColour, 0.5f), new Point(Width / 2, 0), new Point(Width / 2, Height));
                    break;
            }
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion



    }


}

