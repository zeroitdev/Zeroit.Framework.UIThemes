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

namespace Zeroit.Framework.UIThemes.Meph
{

    public class MephProgressBar : Control
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
                //            switch (value) {
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
                //            switch (value) {
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

        public MephProgressBar() : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighQuality;

            int intValue = Convert.ToInt32(_Value / _Maximum * Width);
            G.Clear(BackColor);

            SolidBrush percentColor = new SolidBrush(Color.White);

            Color[] c = new Color[] {
            Color.FromArgb(20, 20, 20),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(46, 46, 46),
            Color.FromArgb(47, 47, 47),
            Color.FromArgb(48, 48, 48),
            Color.FromArgb(49, 49, 49),
            Color.FromArgb(50, 50, 50)
        };
            G.FillPath(new SolidBrush(Color.FromArgb(50, 50, 50)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));
            Draw.InnerGlowRounded(G, ClientRectangle, 3, c);

            ////// Bar Fill
            if (!(intValue == 0))
            {
                G.FillPath(new LinearGradientBrush(new Rectangle(1, 1, intValue, Height - 3), Color.FromArgb(30, 30, 30), Color.FromArgb(35, 35, 35), 90), Draw.RoundRect(new Rectangle(1, 1, intValue, Height - 3), 2));
                G.DrawPath(new Pen(Color.FromArgb(45, 45, 45)), Draw.RoundRect(new Rectangle(1, 1, intValue, Height - 3), 2));
                //G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(15, 15, 15))), intValue + 1, 3, intValue + 1, Height - 4)
                percentColor = new SolidBrush(Color.White);
            }



            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Tahoma", 9, FontStyle.Bold), percentColor, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
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


