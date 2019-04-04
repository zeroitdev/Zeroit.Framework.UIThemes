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
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Vitality
{
    [DefaultEvent("CheckedChanged")]
    public class VitalityCheckbox : ThemeControl154
    {
        Color BG;

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
                _Checked = false;
            else
                _Checked = true;
        }

        public VitalityCheckbox()
        {
            LockHeight = 22;
            SetColor("G1", Color.White);
            SetColor("G2", Color.LightGray);
            SetColor("BG", Color.FromArgb(240, 240, 240));
        }

        protected override void ColorHook()
        {
            BG = GetColor("BG");
        }

        protected override void PaintHook()
        {
            G.Clear(BG);

            if (_Checked)
                G.DrawString("a", new Font("Marlett", 14), Brushes.Gray, new Point(0, 1));

            if (State == MouseState.Over)
            {
                G.FillRectangle(Brushes.White, new Rectangle(new Point(3, 3), new Size(15, 15)));
                if (_Checked)
                    G.DrawString("a", new Font("Marlett", 14), Brushes.Gray, new Point(0, 1));
            }

            G.DrawRectangle(Pens.White, 2, 2, 17, 17);
            G.DrawRectangle(Pens.LightGray, 3, 3, 15, 15);
            G.DrawRectangle(Pens.LightGray, 1, 1, 19, 19);

            G.DrawString(Text, new Font("Segoe UI", 9), Brushes.Gray, 22, 3);
        }
    }

}

