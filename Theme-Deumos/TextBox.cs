// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Deumos
{

    [DefaultEvent("TextChanged")]
    public class DeumosTextBox : ThemeControl153
    {

        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        public HorizontalAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                if (Base != null)
                {
                    Base.TextAlign = value;
                }
            }
        }

        private int _MaxLength = 32767;
        public int MaxLength
        {
            get { return _MaxLength; }
            set
            {
                _MaxLength = value;
                if (Base != null)
                {
                    Base.MaxLength = value;
                }
            }
        }

        private bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (Base != null)
                {
                    Base.ReadOnly = value;
                }
            }
        }

        private bool _UseSystemPasswordChar;
        public bool UseSystemPasswordChar
        {
            get { return _UseSystemPasswordChar; }
            set
            {
                _UseSystemPasswordChar = value;
                if (Base != null)
                {
                    Base.UseSystemPasswordChar = value;
                }
            }
        }

        private bool _Multiline;
        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (Base != null)
                {
                    Base.Multiline = value;

                    if (value)
                    {
                        LockHeight = 0;
                        Base.Height = Height - 11;
                    }
                    else
                    {
                        LockHeight = Base.Height + 11;
                    }
                }
            }
        }


        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (Base != null)
                {
                    Base.Text = value;
                }
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (Base != null)
                {
                    Base.Font = value;
                    Base.Location = new Point(3, 5);
                    Base.Width = Width - 6;

                    if (!_Multiline)
                    {
                        LockHeight = Base.Height + 11;
                    }
                }
            }
        }


        protected override void OnCreation()
        {
            if (!Controls.Contains(Base))
            {
                Controls.Add(Base);
            }
        }

        private TextBox Base;
        public DeumosTextBox()
        {
            Base = new TextBox();

            Base.Font = Font;
            Base.Text = Text;
            Base.MaxLength = _MaxLength;
            Base.Multiline = _Multiline;
            Base.ReadOnly = _ReadOnly;
            Base.UseSystemPasswordChar = _UseSystemPasswordChar;

            Base.BorderStyle = BorderStyle.None;

            Base.Location = new Point(5, 5);
            Base.Width = Width - 10;

            if (_Multiline)
            {
                Base.Height = Height - 11;
            }
            else
            {
                LockHeight = Base.Height + 11;
            }

            Base.TextChanged += OnBaseTextChanged;
            Base.KeyDown += OnBaseKeyDown;


            SetColor("Text", Color.White);
            SetColor("Back", 7, 7, 7);
            SetColor("Border1", Color.Black);
            SetColor("Border2", 20, 20, 20);
        }

        private Color C1;
        private Pen P1;

        private Pen P2;
        protected override void ColorHook()
        {
            C1 = GetColor("Back");

            P1 = GetPen("Border1");
            P2 = GetPen("Border2");

            Base.ForeColor = GetColor("Text");
            Base.BackColor = C1;
        }

        protected override void PaintHook()
        {
            G.Clear(C1);

            DrawBorders(P1, 1);
            DrawBorders(P2);
        }


        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = Base.Text;
        }

        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                Base.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Base.Location = new Point(5, 5);
            Base.Width = Width - 10;

            if (_Multiline)
            {
                Base.Height = Height - 11;
            }


            base.OnResize(e);
        }

    }


}


