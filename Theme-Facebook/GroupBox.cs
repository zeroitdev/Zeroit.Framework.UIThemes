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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Facebook
{
    public class FacebookGroupBox : ContainerControl
    {

        #region "Declarations"
        private Color _MainColour = Color.FromArgb(237, 239, 244);
        private Color _HeaderColour = Color.FromArgb(109, 132, 180);
        private Color _TextColour = Color.FromArgb(255, 255, 255);
        private Color _CircleColour = Color.FromArgb(93, 170, 64);
        private Color _BorderColour = Color.FromArgb(14, 44, 109);
        #endregion
        private bool _DrawCircle = true;

        #region "Colour & Other Properties"
        [Category("Colours")]
        public Color MainColour
        {
            get { return _MainColour; }
            set { _MainColour = value; }
        }
        [Category("Colours")]
        public Color HeaderColour
        {
            get { return _HeaderColour; }
            set { _HeaderColour = value; }
        }
        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }
        [Category("Colours")]
        public Color CircleColour
        {
            get { return _CircleColour; }
            set { _CircleColour = value; }
        }
        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }
        [Category("Misc")]
        public bool DrawCircle
        {
            get { return _DrawCircle; }
            set { _DrawCircle = value; }
        }
        #endregion

        #region "Draw Control"
        public FacebookGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(160, 110);
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            dynamic G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle Circle = new Rectangle(8, 8, 10, 10);
            var _with4 = G;
            _with4.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with4.SmoothingMode = SmoothingMode.HighQuality;
            _with4.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with4.Clear(BackColor);
            _with4.FillRectangle(new SolidBrush(_MainColour), Base);
            _with4.FillRectangle(new SolidBrush(_HeaderColour), new Rectangle(0, 0, Width - 1, 26));
            _with4.DrawRectangle(new Pen(new SolidBrush(_BorderColour)), new Rectangle(0, 0, Width, Height));
            if (_DrawCircle)
            {
                _with4.FillEllipse(new SolidBrush(_CircleColour), Circle);
                _with4.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(23, 4, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near
                });
            }
            else
            {
                _with4.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(5, 4, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near
                });
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

