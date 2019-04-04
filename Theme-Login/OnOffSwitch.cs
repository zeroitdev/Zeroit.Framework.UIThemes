// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="OnOffSwitch.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    [DefaultEvent("ToggleChanged")]
    public class LogInOnOffSwitch : Control
    {

        #region "Declarations"

        public event ToggleChangedEventHandler ToggleChanged;
        public delegate void ToggleChangedEventHandler(object sender);
        private Toggles _Toggled = Toggles.NotToggled;
        private int MouseXLoc;
        private int ToggleLocation = 0;
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _TextColour = Color.FromArgb(255, 255, 255);
        private Color _NonToggledTextColour = Color.FromArgb(125, 125, 125);

        private Color _ToggledColour = Color.FromArgb(23, 119, 151);
        #endregion

        #region "Properties & Events"

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set
            {
                _BaseColour = value;
                Invalidate();
            }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set
            {
                _BorderColour = value;
                Invalidate();
            }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set
            {
                _TextColour = value;
                Invalidate();
            }
        }

        [Category("Colours")]
        public Color NonToggledTextColourderColour
        {
            get { return _NonToggledTextColour; }
            set
            {
                _NonToggledTextColour = value;
                Invalidate();
            }
        }

        [Category("Colours")]
        public Color ToggledColour
        {
            get { return _ToggledColour; }
            set
            {
                _ToggledColour = value;
                Invalidate();
            }
        }

        public enum Toggles
        {
            Toggled,
            NotToggled
        }

        public event ToggledChangedEventHandler ToggledChanged;
        public delegate void ToggledChangedEventHandler();

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MouseXLoc = e.Location.X;
            Invalidate();
            if (e.X < Width - 40 && e.X > 40)
                Cursor = Cursors.IBeam;
            else
                Cursor = Cursors.Arrow;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (MouseXLoc > Width - 39)
            {
                _Toggled = Toggles.Toggled;
                ToggledValue();
            }
            else if (MouseXLoc < 39)
            {
                _Toggled = Toggles.NotToggled;
                ToggledValue();
            }
            Invalidate();
        }

        public Toggles Toggled
        {
            get { return _Toggled; }
            set
            {
                _Toggled = value;
                Invalidate();
            }
        }

        private void ToggledValue()
        {
            if (Convert.ToBoolean(_Toggled))
            {
                if (ToggleLocation < 100)
                {
                    ToggleLocation += 10;
                }
            }
            else
            {
                if (ToggleLocation > 0)
                {
                    ToggleLocation -= 10;
                }
            }
            Invalidate();
        }

        #endregion

        #region "Draw Control"

        public LogInOnOffSwitch()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            BackColor = Color.FromArgb(54, 54, 54);
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            var _with23 = G;
            _with23.Clear(BackColor);
            _with23.SmoothingMode = SmoothingMode.HighQuality;
            _with23.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with23.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with23.InterpolationMode = InterpolationMode.HighQualityBicubic;
            _with23.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, 39, Height));
            _with23.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(Width - 40, 0, Width, Height));
            _with23.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(38, 9, Width - 40, 5));
            Point[] P = {
            new Point(0, 0),
            new Point(39, 0),
            new Point(39, 9),
            new Point(Width - 40, 9),
            new Point(Width - 40, 0),
            new Point(Width - 2, 0),
            new Point(Width - 2, Height - 1),
            new Point(Width - 40, Height - 1),
            new Point(Width - 40, 14),
            new Point(39, 14),
            new Point(39, Height - 1),
            new Point(0, Height - 1),
            new Point()
        };
            _with23.DrawLines(new Pen(_BorderColour, 2), P);
            if (_Toggled == Toggles.Toggled)
            {
                _with23.FillRectangle(new SolidBrush(_ToggledColour), new Rectangle(Convert.ToInt32(Width / 2), 10, Convert.ToInt32(Width / 2 - 38), 3));
                _with23.FillRectangle(new SolidBrush(_ToggledColour), new Rectangle(Width - 39, 2, 36, Height - 5));
                _with23.DrawString("ON", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(_TextColour), new Rectangle(2, -1, Convert.ToInt32(Width - 20 + 20 / 3), Height), new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                });
                _with23.DrawString("OFF", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(_NonToggledTextColour), new Rectangle(Convert.ToInt32(20 - 20 / 3 - 6), -1, Convert.ToInt32(Width - 20 + 20 / 3), Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });
            }
            else if (_Toggled == Toggles.NotToggled)
            {
                _with23.DrawString("OFF", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(_TextColour), new Rectangle(Convert.ToInt32(20 - 20 / 3 - 6), -1, Convert.ToInt32(Width - 20 + 20 / 3), Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });
                _with23.DrawString("ON", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(_NonToggledTextColour), new Rectangle(2, -1, Convert.ToInt32(Width - 20 + 20 / 3), Height), new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                });
            }
            _with23.DrawLine(new Pen(_BorderColour, 2), new Point(Convert.ToInt32(Width / 2), 0), new Point(Convert.ToInt32(Width / 2), Height));

        }

        #endregion

    }

}


