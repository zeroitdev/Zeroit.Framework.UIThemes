// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Booster
{

    [DefaultEvent("CheckedChanged")]
    public class BoosterCheckBox : ThemeControl154
    {

        public BoosterCheckBox()
        {
            Transparent = true;
            BackColor = Color.Transparent;
            LockHeight = 15;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            Rectangle CheckRectangle = new Rectangle(1, 1, Height - 2, Height - 2);

            G.Clear(BackColor);




            switch (_Checked)
            {
                case true:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(129, 10, 10)), CheckRectangle);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 1, 1, Height - 2, Height / 2);
                    break;
                case false:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(51, 28, 28)), CheckRectangle);
                    break;
            }

            G.DrawRectangle(new Pen(Color.FromArgb(92, 92, 92)), 2, 2, Height - 4, Height - 4);
            G.DrawRectangle(Pens.Black, CheckRectangle);

            DrawText(Brushes.White, HorizontalAlignment.Left, 18, 1);
        }


        private bool _Checked { get; set; }
        public bool Checked
        {
            get { return _Checked; }
            set { _Checked = value; }
        }
        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
    }

}

