// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

//using System;
//using System.Drawing.Drawing2D;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;
//using System.Collections.Generic;

//namespace Zeroit.Framework.UIThemes.Morphic
//{
//    [DefaultEvent("TextChanged")]
//    public class MorphicTextBox : Control
//    {
//        private DrawingHelper dh = new DrawingHelper();
//        private Graphics g;

//        private int _maxLength = 32767;
//        public int MaxLength
//        {
//            get
//            {
//                return _maxLength;
//            }
//            set
//            {
//                _maxLength = value;
//                if (baseTextBox.MaxLength != null)
//                {
//                    baseTextBox.MaxLength = value;
//                }
//            }
//        }

//        private bool _readOnly;
//        public bool ReadOnly
//        {
//            get
//            {
//                return _readOnly;
//            }
//            set
//            {
//                _readOnly = value;
//                if (baseTextBox.ReadOnly != null)
//                {
//                    baseTextBox.ReadOnly = value;
//                }
//            }
//        }

//        private bool _useSystemPasswordChar;
//        public bool UseSystemPasswordChar
//        {
//            get
//            {
//                return _useSystemPasswordChar;
//            }
//            set
//            {
//                _useSystemPasswordChar = value;
//                if (baseTextBox.UseSystemPasswordChar != null)
//                {
//                    baseTextBox.UseSystemPasswordChar = value;
//                }
//            }
//        }

//        private bool _multiline;
//        public new bool Multiline
//        {
//            get
//            {
//                return _multiline;
//            }
//            set
//            {
//                _multiline = value;
//                if (baseTextBox.Multiline != null)
//                {
//                    baseTextBox.Multiline = value;

//                    if (value)
//                    {
//                        baseTextBox.Height = Height - 11;
//                    }
//                    else
//                    {
//                        Height = baseTextBox.Height + 11;
//                    }
//                }
//            }
//        }

//        public override string Text
//        {
//            get
//            {
//                return baseTextBox.Text;
//            }
//            set
//            {
//                baseTextBox.Text = value;
//                if (baseTextBox.Text != null)
//                {
//                    baseTextBox.Text = value;
//                }
//            }
//        }

//        public override Font Font
//        {
//            get
//            {
//                return baseTextBox.Font;
//            }
//            set
//            {
//                baseTextBox.Font = value;
//                if (baseTextBox.Font != null)
//                {
//                    baseTextBox.Font = value;
//                    baseTextBox.Location = new Point(3, 5);
//                    baseTextBox.Width = Width - 6;
//                }
//            }
//        }

//        protected override void OnCreateControl()
//        {
//            base.OnCreateControl();
//            if (!(Controls.Contains(baseTextBox)))
//            {
//                Controls.Add(baseTextBox);
//            }
//        }

//        private TextBox baseTextBox = new TextBox();

//        public MorphicTextBox()
//        {

//            //Font = new Font("Segoe UI", 9);
//            Cursor = Cursors.IBeam;

            
//            baseTextBox.Font = Font;
//            baseTextBox.Text = Text;
//            baseTextBox.ForeColor = Preferences.TextColor;
//            baseTextBox.MaxLength = _maxLength;
//            baseTextBox.Multiline = _multiline;
//            baseTextBox.ReadOnly = _readOnly;
//            baseTextBox.UseSystemPasswordChar = _useSystemPasswordChar;
//            baseTextBox.BorderStyle = BorderStyle.None;
//            baseTextBox.Location = new Point(5, 5);
//            baseTextBox.Width = Width - 10;

//            if (_multiline)
//            {
//                baseTextBox.Height = Height - 11;
//            }
//            else
//            {
//                Height = baseTextBox.Height + 11;
//            }

//            base.TextChanged += OnBaseTextChanged;
//            base.KeyDown += OnBaseKeyDown;

//        }

//        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
//        {
//            base.OnPaint(e);

//            g = e.Graphics;

//            g.SmoothingMode = SmoothingMode.HighQuality;
//            g.Clear(Parent.BackColor);

//            Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
//            GraphicsPath mainPath = dh.RoundRect(mainRect, Preferences.Rounding);
//            g.FillPath(new SolidBrush(Preferences.SecondaryBackColor), mainPath);
//            g.DrawPath(new Pen(Preferences.BorderColor), mainPath);

//            baseTextBox.BackColor = Preferences.SecondaryBackColor;

//        }

//        private void OnBaseTextChanged(object s, EventArgs e)
//        {
//            Text = baseTextBox.Text;
//        }

//        private void OnBaseKeyDown(object s, KeyEventArgs e)
//        {
//            if (e.Control && e.KeyCode == Keys.A)
//            {
//                baseTextBox.SelectAll();
//                e.SuppressKeyPress = true;
//            }
//        }

//        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
//        [Category("Options")]
//        public HorizontalAlignment TextAlign
//        {
//            get
//            {
//                return _TextAlign;
//            }
//            set
//            {
//                _TextAlign = value;
//                if (baseTextBox != null)
//                {
//                    baseTextBox.TextAlign = value;
//                }
//            }
//        }

//        protected override void OnResize(EventArgs e)
//        {
//            base.OnResize(e);
//            baseTextBox.Location = new Point(6, 6);

//            baseTextBox.Width = Width - 10;
//            baseTextBox.Height = Height - 11;

//            if (!_multiline)
//            {
//                Size = new Size(Width, base.Height + 12);
//            }

            
//        }

//        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
//        {
//            base.OnMouseDown(e);
//            baseTextBox.SelectionStart = baseTextBox.TextLength;
//            baseTextBox.Focus();
//        }

//    }
//}
