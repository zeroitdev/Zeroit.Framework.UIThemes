// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influence
{
    public class InfluenceProgressBar : Control
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
                //            switch (value)
                //            {
                //                case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Value:
                //                    _Value = value;
                //                    break;
                //            } 
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
                    Invalidate();
                }
                #region Old Code

                //            switch (value)
                //            {
                //                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //                    value = _Maximum;
                //                    break;
                //            } 
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
            // Dim tmr As New Timer With {.Interval = Speed}
            // AddHandler tmr.Tick, AddressOf Animate
            // tmr.Start()
            System.Threading.Thread T = new System.Threading.Thread(Animate);
            T.IsBackground = true;
            //T.Start()
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

        public InfluenceProgressBar()
            : base()
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
            Draw d = new Draw();

            int intValue = Convert.ToInt32(_Value / _Maximum * Width);
            G.Clear(BackColor);

            LinearGradientBrush gB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(16, 16, 16), Color.FromArgb(22, 22, 22), 90);
            G.FillPath(gB, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(0, 0, intValue - 1, Height - 2), Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
            G.FillPath(g1, d.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 2), 2));
            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
            G.FillPath(h1, d.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 2), 2));
            LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
            G.FillPath(s1, d.RoundRect(new Rectangle(0, 0, intValue - 1, Height / 2 - 1), 2));

            G.DrawPath(new Pen(Color.FromArgb(125, 97, 94, 90)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
            G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), d.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 1), 2));
            G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), d.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 1), 2));

            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), Font, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
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

