// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Uplay
{

    [DefaultEvent("CheckedChanged")]
    public class UPlayRadioButton : ThemeControl154
    {

        public UPlayRadioButton()
        {
            LockHeight = 17;
            SetColor("Text", Color.Black);
            SetColor("Gradient 1", 230, 230, 230);
            SetColor("Gradient 2", 210, 210, 210);
            SetColor("Glow", 230, 230, 230);
            SetColor("Edges", 170, 170, 170);
            SetColor("Backcolor", BackColor);
            SetColor("Bullet", 40, 40, 40);
            Width = 180;
        }

        private int X;
        private Color TextColor;
        private Color G1;
        private Color G2;
        private Color Glow;
        private Color Edge;

        private Color BG;
        protected override void ColorHook()
        {
            TextColor = GetColor("Text");
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            Glow = GetColor("Glow");
            Edge = GetColor("Edges");
            BG = Color.FromArgb(221, 221, 221);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void PaintHook()
        {
            G.Clear(BG);
            G.SmoothingMode = SmoothingMode.HighQuality;
            if (_Checked)
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(9, 9)), G1, G2, 90f);
                G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(9, 9)));
                G.FillEllipse(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(9, 4)));
            }
            else
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(9, 11)), G1, G2, 90f);
                G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(9, 9)));
                G.FillEllipse(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(9, 4)));
            }

            if (State == MouseState.Over & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(70, Color.White));
                G.FillEllipse(SB, new Rectangle(new Point(0, 0), new Size(9, 9)));
            }
            else if (State == MouseState.Down & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(10, Color.Black));
                G.FillEllipse(SB, new Rectangle(new Point(0, 0), new Size(9, 9)));
            }

            HatchBrush HB = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(7, Color.Black), Color.Transparent);
            G.FillEllipse(HB, new Rectangle(new Point(0, 0), new Size(9, 9)));
            G.DrawEllipse(new Pen(Edge), new Rectangle(new Point(0, 0), new Size(9, 9)));

            if (_Checked)
                G.FillEllipse(GetBrush("Bullet"), new Rectangle(new Point(2, 2), new Size(5, 5)));
            DrawText(new SolidBrush(TextColor), HorizontalAlignment.Left, 19, -1);
        }

        private int _Field = 16;
        public int Field
        {
            get { return _Field; }
            set
            {
                if (value < 4)
                    return;
                _Field = value;
                LockHeight = value;
                Invalidate();
            }
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        protected override void OnCreation()
        {
            InvalidateControls();
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is RadioButton)
                {
                    ((RadioButton)C).Checked = false;
                }
            }
        }
    }

}


