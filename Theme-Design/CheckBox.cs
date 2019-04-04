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

namespace Zeroit.Framework.UIThemes.Design
{

    #region Design Check Box
    [DefaultEvent("CheckedChanged")]
    public class DesignCheckBox : ThemeControl154
    {

        public DesignCheckBox()
        {
            LockHeight = 16;

            SetColor("Border", 26, 26, 26);
            SetColor("Gloss1", 35, Color.White);
            SetColor("Gloss2", 5, Color.White);
            SetColor("Checked1", Color.Transparent);
            SetColor("Checked2", 40, Color.White);
            SetColor("Unchecked1", 8, 8, 8);
            SetColor("Unchecked2", 16, 16, 16);
            SetColor("Glow", 5, Color.White);
            SetColor("Text", Color.White);
            SetColor("InnerOutline", Color.Black);
            SetColor("OuterOutline", Color.Black);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("Gloss1");
            C2 = GetColor("Gloss2");
            C3 = GetColor("Checked1");
            C4 = GetColor("Checked2");
            C5 = GetColor("Unchecked1");
            C6 = GetColor("Unchecked2");

            P1 = new Pen(GetColor("Border"));
            P2 = new Pen(GetColor("InnerOutline"));
            P3 = new Pen(GetColor("OuterOutline"));

            B1 = new SolidBrush(GetColor("Glow"));
            B2 = new SolidBrush(GetColor("Text"));
        }


        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;

        private SolidBrush B2;
        
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(25, 25, 25));
            BackColor = Color.FromArgb(25, 25, 25);

            DrawBorders(P1, 0, 0, _Field, _Field, 1);
            DrawGradient(C1, C2, 0, 0, _Field, _Field / 2);

            if (_Checked)
            {
                DrawGradient(C3, C4, 2, 2, _Field - 4, _Field - 4);
            }
            else
            {
                DrawGradient(C5, C6, 2, 2, _Field - 4, _Field - 4, 90);
            }

            if (State == MouseState.Over)
            {
                G.FillRectangle(B1, 0, 0, _Field, _Field);
            }

            DrawText(B2, HorizontalAlignment.Left, _Field + 3, 0);

            DrawBorders(P2, 0, 0, _Field, _Field, 2);
            DrawBorders(P3, 0, 0, _Field, _Field);

            DrawCorners(BackColor, 0, 0, _Field, _Field);
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
                Invalidate();
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnMouseDown(e);
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

    }
    #endregion
    
}


