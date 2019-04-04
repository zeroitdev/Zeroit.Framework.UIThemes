// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="NumericUpDown.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Preview
{
    public class PVNumericUD : ThemedControl
    {
        private PVTextbox TxtBox = new PVTextbox();
        private PVButton BtnUp = new PVButton();
        private PVButton BtnDown = new PVButton();
        private int _ButtonChange = 1;
        public int ButtonChange
        {
            get
            {
                return _ButtonChange;
            }
            set
            {
                _ButtonChange = value;
            }
        }
        private int _Minimum = 1;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
            }
        }
        private int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
            }
        }

        //| Used the MouseDown event because it doesn't use a delay like the click one does.
        protected void BtnUp_Down(object Sender, System.EventArgs e)
        {
            Value = Value + ButtonChange;
        }
        protected void BtnDown_Down(object Sender, System.EventArgs e)
        {
            Value = Value - ButtonChange;
        }

        public int Value
        {
            get
            {
                int Ret = 0;
                Ret = Convert.ToInt32(TxtBox.Text);
                return Ret;

            }


            set
            {
                if (value <= Maximum && value >= Minimum)
                {
                    TxtBox.Text = value.ToString();

                    Invalidate();
                }
            }
        }
        public PVNumericUD() : base()
        {
            Size = new Size(300, 300);
            Font = new Font("Trebuchet MS", 10.0F);
            TxtBox.Text = 0.ToString();
            Controls.Add(TxtBox);
            Controls.Add(BtnUp);
            Controls.Add(BtnDown);
            SubscribeToEvents();

        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            G.Clear(this.Parent.BackColor);
            Height = 30;
            BtnUp.MinimumSize = new Size(15, 15);
            BtnUp.Size = new Size(10, 10);
            BtnUp.Location = new Point(Size.Width - BtnUp.Width, 0);
            BtnUp.Font = new Font("Trebuchet MS", 10.0F);
            BtnUp.Text = "ᴧ";
            BtnDown.MinimumSize = new Size(15, 15);
            BtnDown.Size = new Size(10, 10);
            BtnDown.Location = new Point(Size.Width - BtnUp.Width, BtnUp.Size.Height);
            BtnDown.Font = new Font("Trebuchet MS", 10.0F, FontStyle.Bold);
            BtnDown.Text = "v";
            TxtBox.Location = new Point(0, 0);
            TxtBox.Multiline = true;
            TxtBox.Height = 30;
            TxtBox.Width = BtnUp.Location.X - 2;
        }


        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            BtnUp.MouseDown += BtnUp_Down;
            BtnDown.MouseDown += BtnDown_Down;
        }


    }
}
