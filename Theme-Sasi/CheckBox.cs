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
namespace Zeroit.Framework.UIThemes.Sasi
{

    [DefaultEvent("CheckedChanged")]
    public class SasisCheckbox : ThemeControl154
    {
        private bool _Checked;

        private int X;
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


        protected override void ColorHook()
        {
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 20 + textSize;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_Checked == true)
                _Checked = false;
            else
                _Checked = true;
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(239, 254, 213));
            HatchBrush asdf = default(HatchBrush);
            asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black), Color.FromArgb(0, Color.Gray));
            G.FillRectangle(new SolidBrush(Color.FromArgb(239, 254, 213)), new Rectangle(0, 0, Width, Height));
            asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
            G.FillRectangle(asdf, 0, 0, Width, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(239, 254, 213)), 0, 0, Width, Height);

            G.FillRectangle(new SolidBrush(Color.FromArgb(218, 240, 139)), 3, 3, 10, 10);
            if (_Checked)
            {
                ColorBlend cblend = new ColorBlend(2);
                cblend.Colors[0] = Color.FromArgb(218, 240, 139);
                cblend.Colors[1] = Color.FromArgb(218, 240, 139);
                cblend.Positions[0] = 0;
                cblend.Positions[1] = 1;
                DrawGradient(cblend, new Rectangle(3, 3, 10, 10));
                cblend.Colors[0] = Color.FromArgb(218, 240, 139);
                cblend.Colors[1] = Color.FromArgb(218, 240, 139);
                DrawGradient(cblend, new Rectangle(3, 3, 10, 4));
                HatchBrush hatch = default(HatchBrush);
                hatch = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(60, Color.Black), Color.FromArgb(0, Color.Gray));
                G.FillRectangle(hatch, 3, 3, 10, 10);
            }
            else
            {
                HatchBrush hatch = default(HatchBrush);
                hatch = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(20, Color.White), Color.FromArgb(0, Color.Gray));
                G.FillRectangle(hatch, 3, 3, 10, 10);
            }

            if (State == MouseState.Over & X < 15)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Gray)), new Rectangle(3, 3, 10, 10));
            }
            else if (State == MouseState.Down)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), new Rectangle(3, 3, 10, 10));
            }

            G.DrawRectangle(Pens.Black, 0, 0, 15, 15);
            G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, 13, 13);
            G.DrawString(Text, Font, Brushes.Black, 17, 1);
        }

        public SasisCheckbox()
        {
            this.Size = new Size(16, 50);
        }
    }

}

