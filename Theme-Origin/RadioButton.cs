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

namespace Zeroit.Framework.UIThemes.Origin
{
    [DefaultEvent("CheckedChanged")]
    public class OriginRadioButton : ThemeControl154
    {

        public OriginRadioButton()
        {
            LockHeight = 17;
            SetColor("Text", Color.Black);
            SetColor("Gradient 1", 245, 245, 245);
            SetColor("Gradient 2", 225, 225, 225);
            SetColor("Glow", 245, 245, 245);
            SetColor("Edges", 170, 170, 170);
            SetColor("Backcolor", Color.FromArgb(245, 245, 245));
            SetColor("Bullet", Color.Orange);
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
            BG = GetColor("Backcolor");
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
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), G1, G2, 90f);
                G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));
                G.FillEllipse(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(14, 7)));
            }
            else
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 16)), G1, G2, 90f);
                G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));
                G.FillEllipse(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(14, 7)));
            }

            if (State == MouseState.Over & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(70, Color.White));
                G.FillEllipse(SB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }
            else if (State == MouseState.Down & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(10, Color.Black));
                G.FillEllipse(SB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }

            //Dim HB As New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(7, Color.Black), Color.Transparent)
            //G.FillEllipse(HB, New Rectangle(New Point(0, 0), New Size(14, 14)))
            G.DrawEllipse(new Pen(Edge), new Rectangle(new Point(0, 0), new Size(14, 14)));

            if (_Checked)
                G.FillEllipse(GetBrush("Bullet"), new Rectangle(new Point(4, 4), new Size(6, 6)));
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
                if (!object.ReferenceEquals(C, this) && C is OriginRadioButton)
                {
                    ((OriginRadioButton)C).Checked = false;
                }
            }
        }

    }

}


