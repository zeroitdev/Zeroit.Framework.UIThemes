// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.XVisual
{

    public class xVisualProgressBar : Control
    {

        #region " Control Help - Properties & Flicker Control "
        private int OFS = 0;
        private int Speed = 50;

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {

                if (value == _Value)
                {
                    _Value = value;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Value:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                _Maximum = value;
                Invalidate();
            }
        }
        private int _Value = 0;
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 0;
                    default:
                        return _Value;
                }
            }
            set
            {

                if (value == _Maximum)
                {
                    value = _Maximum;

                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					value = _Maximum;
                //					break;
                //			} 
                #endregion

                _Value = value;
                Invalidate();
            }
        }
        private bool _ShowPercentage = false;
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
        }
        public void Animate()
        {
            while (true)
            {
                if (OFS <= Width)
                {
                    OFS += 1;
                }
                else
                {
                    OFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(Speed);
            }
        }
        #endregion

        public xVisualProgressBar() : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(274, 30);
        }

        TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
        Color.FromArgb(55, 52, 48),
        Color.FromArgb(57, 50, 50),
        Color.FromArgb(53, 50, 46)
    });
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            //G.SmoothingMode = SmoothingMode.HighQuality

            int intValue = Convert.ToInt32(_Value / _Maximum * Width);
            G.Clear(BackColor);

            SolidBrush percentColor = new SolidBrush(Color.White);

            G.FillRectangle(InnerTexture, new Rectangle(0, 0, Width - 1, Height - 1));

            ColorBlend blend = new ColorBlend();

            //Add the Array of Color
            Color[] bColors = new Color[] {
            Color.FromArgb(20, Color.White),
            Color.FromArgb(10, Color.Black),
            Color.FromArgb(10, Color.White)
        };
            blend.Colors = bColors;

            //Add the Array Single (0-1) colorpoints to place each Color
            float[] bPts = new float[] {
            0,
            0.8f,
            1
        };
            blend.Positions = bPts;

            using (LinearGradientBrush br = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.White, Color.Black, LinearGradientMode.Vertical))
            {

                //Blend the colors into the Brush
                br.InterpolationColors = blend;

                //Fill the rect with the blend
                G.FillRectangle(br, new Rectangle(0, 0, Width - 1, Height - 1));

            }

            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, 1, Width - 3, 1);
            G.DrawLine(Draw.GetPen(Color.FromArgb(64, 60, 57)), 1, Height - 2, Width - 3, Height - 2);

            ////// Bar Fill
            if (!(intValue == 0))
            {
                G.FillRectangle(new LinearGradientBrush(new Rectangle(2, 2, intValue - 3, Height - 4), Color.FromArgb(114, 203, 232), Color.FromArgb(58, 118, 188), 90), new Rectangle(2, 2, intValue - 3, Height - 4));
                G.DrawLine(Draw.GetPen(Color.FromArgb(235, 255, 255)), 2, 2, intValue - 2, 2);
                //G.DrawLine(GetPen(Color.FromArgb(27, 25, 23)), 2, Height - 2, intValue + 1, Height - 2)
                percentColor = new SolidBrush(Color.White);
            }

            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Arial", 10, FontStyle.Bold), Draw.GetBrush(Color.FromArgb(20, 20, 20)), new Rectangle(1, 2, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Arial", 10, FontStyle.Bold), percentColor, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

