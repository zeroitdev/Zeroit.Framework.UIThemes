// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Positron
{
    [DefaultEvent("CheckedChanged")]
    public class PositronCheckBox : ThemeControl154
    {
        private Color BG;
        private Brush TB;
        private Brush IN;
        private Pen IB;

        private Pen B;
        private bool _Checked;
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_Checked == true)
            {
                _Checked = false;
            }
            else
            {
                _Checked = true;
            }
        }

        public PositronCheckBox()
        {
            LockHeight = 22;
            SetColor("BG", Color.FromArgb(240, 240, 240));
            SetColor("Texts", Color.FromArgb(100, 100, 100));
            SetColor("Inside", Color.FromArgb(175, 175, 175));
            SetColor("IB", Color.FromArgb(200, 200, 200));
            SetColor("B", Color.FromArgb(150, 150, 150));
            Size = new Size(150, 22);
        }

        protected override void ColorHook()
        {
            BG = GetColor("BG");
            TB = GetBrush("Texts");
            IN = GetBrush("Inside");
            IB = GetPen("IB");
            B = GetPen("B");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (_Checked)
            {
                G.DrawString("a", new Font("Marlett", 12), TB, new Point(-1, 1));
            }

            if (State == MouseState.Over)
            {
                G.FillRectangle(IN, new Rectangle(new Point(4, 4), new Size(10, 10)));
                if (_Checked)
                {
                    G.DrawString("a", new Font("Marlett", 12), TB, new Point(-1, 1));
                }
            }

            G.DrawRectangle(B, 2, 2, 14, 14);
            G.DrawRectangle(IB, 1, 1, 16, 16);
            G.DrawString(Text, Font, TB, 19, 3);
        }
    }
}

