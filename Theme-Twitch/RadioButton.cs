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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchRadiobutton : ThemeControl154
    {
        private int X;

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
                if (!object.ReferenceEquals(C, this) && C is TwitchRadiobutton)
                {
                    ((TwitchRadiobutton)C).Checked = false;
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        Brush textcolor;

        Pen circlecolor;
        protected override void ColorHook()
        {
            textcolor = GetBrush("Text");
            circlecolor = GetPen("Circle");
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;
            if (_Checked)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(195, 195, 195)), new Rectangle(0, 0, Width, Height));
                G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), new Rectangle(0, 0, Width - 1, Height - 1));
                DrawText(new SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0);
            }
            else
            {
                DrawGradient(Color.FromArgb(242, 242, 242), Color.FromArgb(223, 223, 223), new Rectangle(0, 0, Width, Height), 90f);
                G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), new Rectangle(0, 0, Width - 1, Height - 1));
                DrawText(new SolidBrush(Color.FromArgb(30, 30, 30)), HorizontalAlignment.Center, 0, 0);
            }
        }

        public TwitchRadiobutton()
        {
            SetColor("Text", Color.Black);
            SetColor("Circle", Color.FromArgb(0, 239, 255));
            this.Size = new Size(147, 29);
            Cursor = Cursors.Hand;
        }
    }
}

