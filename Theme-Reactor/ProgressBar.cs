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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Reactor
{
    public class ReactorProgressBar : Control
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
                        return 1;
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            // Dim tmr As New Timer With {.Interval = Speed}
            // AddHandler tmr.Tick, AddressOf Animate
            // tmr.Start()
            System.Threading.Thread T = new System.Threading.Thread(Animate);
            T.IsBackground = true;
            T.Start();
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

        public ReactorProgressBar()
            : base()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            int intValue = Convert.ToInt32(_Value / _Maximum * Width);
            G.Clear(Color.FromArgb(38, 38, 38));

            LinearGradientBrush backGrad = new LinearGradientBrush(new Rectangle(1, 1, intValue - 1, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 90);
            G.FillRectangle(backGrad, new Rectangle(1, 1, intValue - 1, Height - 2));
            HatchBrush hatch = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(175, 219, 78, 0), Color.FromArgb(175, 229, 98, 0));
            G.RenderingOrigin = new Point(OFS, 0);
            G.FillRectangle(hatch, new Rectangle(1, 1, intValue - 2, Height - 2));
            LinearGradientBrush glossGradient = new LinearGradientBrush(new Rectangle(1, 1, intValue - 2, Height / 2 - 1), Color.FromArgb(80, Color.White), Color.FromArgb(50, Color.White), 90);
            G.FillRectangle(glossGradient, new Rectangle(1, 1, intValue - 2, Height / 2 - 1));

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);

        }
    }

}


