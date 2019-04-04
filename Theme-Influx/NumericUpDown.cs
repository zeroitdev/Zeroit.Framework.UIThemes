// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="NumericUpDown.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Influx
{
    [DefaultEvent("TextChanged")]
    public class InfluxNumericUpDown : ThemeControl154
    {
        private Point pntMouseLocation;
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
        public int Value
        {
            get
            {
                if (string.IsNullOrEmpty(base.Text))
                {
                    return 0;
                }
                else if (base.Text.StartsWith("InfluxNumericUpDown"))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(base.Text);
                }
            }
            set
            {
                base.Text = value.ToString();
                if (Base != null)
                {
                    if (value >= _MinValue & value <= _MaxValue)
                    {
                        Base.Text = value.ToString();
                    }
                    else if (value < _MinValue)
                    {
                        Base.Text = _MinValue.ToString();
                        Base.Select(Base.Text.Length, 0);
                    }
                    else if (value > _MaxValue)
                    {
                        Base.Text = _MaxValue.ToString();
                        Base.Select(Base.Text.Length, 0);
                    }
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

                }
            }
        }
        private int _MaxValue = 100;
        public int MaxValue
        {
            get { return _MaxValue; }
            set
            {
                _MaxValue = value;
                if (Base != null)
                {
                    int intBaseValue = Convert.ToInt32(Base.Text);
                    if (intBaseValue > value)
                    {
                        Base.Text = value.ToString();
                    }
                }
            }
        }
        private int _MinValue = 0;
        public int MinValue
        {
            get { return _MinValue; }
            set
            {
                _MinValue = value;
                if (Base != null)
                {
                    int intBaseValue = Convert.ToInt32(Base.Text);
                    if (intBaseValue < value)
                    {
                        Base.Text = value.ToString();
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
        public InfluxNumericUpDown()
        {
            Base = new TextBox();

            Width = 125;
            Text = "";
            Base.Text = "";
            Value = 0;
            Base.Font = Font;
            Base.Text = Value.ToString();
            Base.ReadOnly = _ReadOnly;

            Base.BorderStyle = BorderStyle.None;

            Base.Location = new Point(4, 4);
            Base.Width = Width - 10;


            Base.TextChanged += OnBaseTextChanged;
            Base.KeyDown += OnBaseKeyDown;
            Base.LostFocus += OnBaseFocusLost;


            SetColor("Text", Color.FromArgb(229, 229, 229));
            SetColor("TextBackColor", Color.FromArgb(73, 73, 73));
            SetColor("OuterBorder", Color.FromArgb(81, 81, 81));
            SetColor("InnerBorder", Color.FromArgb(60, 60, 60));
        }

        private Color TextBackColor;
        private Pen InnerBorder;

        private Pen OuterBorder;
        protected override void ColorHook()
        {
            TextBackColor = GetColor("TextBackColor");

            InnerBorder = GetPen("InnerBorder");
            OuterBorder = GetPen("OuterBorder");

            Base.ForeColor = GetColor("Text");
            Base.BackColor = GetColor("TextBackColor");
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            pntMouseLocation = e.Location;
            Invalidate();
        }

        private Rectangle GetButtonBounds()
        {
            return new Rectangle(Width - 20, 3, 17, Height - 7);
        }

        private Rectangle GetUpButtonBounds()
        {
            Rectangle ButtonBounds = GetButtonBounds();
            return new Rectangle(ButtonBounds.Location, new Size(16, Convert.ToInt32(Height / 2) - 5));
        }

        private Rectangle GetDownButtonBounds()
        {
            Rectangle ButtonBounds = GetButtonBounds();
            return new Rectangle(ButtonBounds.Location.X, ButtonBounds.Location.Y + Convert.ToInt32(Height / 2) - 3, 16, Convert.ToInt32(Height / 2) - 5);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (GetUpButtonBounds().Contains(e.Location))
            {
                if (Value + 1 <= _MaxValue)
                {
                    Value += 1;
                }
            }
            else if (GetDownButtonBounds().Contains(e.Location))
            {
                if (Value - 1 >= _MinValue)
                {
                    Value -= 1;
                }
            }
            base.OnMouseDown(e);
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(77, 77, 77));

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillRectangle(new SolidBrush(TextBackColor), new Rectangle(1, 1, Width - 3, Height - 3));
            //Draw up/down buttons
            if (GetUpButtonBounds().Contains(pntMouseLocation))
            {
                if (State == MouseState.Down)
                {
                    LinearGradientBrush ButtonGradient = new LinearGradientBrush(GetUpButtonBounds(), Color.FromArgb(110, 110, 110), Color.FromArgb(97, 97, 97), 90);
                    G.FillPath(ButtonGradient, CreateRound(GetUpButtonBounds(), 2));
                }
                else
                {
                    LinearGradientBrush ButtonGradient = new LinearGradientBrush(GetUpButtonBounds(), Color.FromArgb(100, 100, 100), Color.FromArgb(87, 87, 87), 90);
                    G.FillPath(ButtonGradient, CreateRound(GetUpButtonBounds(), 2));
                }
            }
            else
            {
                LinearGradientBrush ButtonGradient = new LinearGradientBrush(GetUpButtonBounds(), Color.FromArgb(90, 90, 90), Color.FromArgb(77, 77, 77), 90);
                G.FillPath(ButtonGradient, CreateRound(GetUpButtonBounds(), 2));
            }
            if (GetDownButtonBounds().Contains(pntMouseLocation))
            {
                if (State == MouseState.Down)
                {
                    LinearGradientBrush ButtonGradient = new LinearGradientBrush(GetUpButtonBounds(), Color.FromArgb(110, 110, 110), Color.FromArgb(97, 97, 97), 90);
                    G.FillPath(ButtonGradient, CreateRound(GetDownButtonBounds(), 2));
                }
                else
                {
                    LinearGradientBrush ButtonGradient = new LinearGradientBrush(GetUpButtonBounds(), Color.FromArgb(100, 100, 100), Color.FromArgb(87, 87, 87), 90);
                    G.FillPath(ButtonGradient, CreateRound(GetDownButtonBounds(), 2));
                }
            }
            else
            {
                LinearGradientBrush ButtonGradient = new LinearGradientBrush(GetUpButtonBounds(), Color.FromArgb(77, 77, 77), Color.FromArgb(90, 90, 90), 90);
                G.FillPath(ButtonGradient, CreateRound(GetDownButtonBounds(), 2));
            }
            G.DrawPath(new Pen(Color.FromArgb(65, 65, 65)), CreateRound(GetUpButtonBounds(), 2));
            G.DrawPath(new Pen(Color.FromArgb(65, 65, 65)), CreateRound(GetDownButtonBounds(), 2));
            //Draw up sign
            G.SmoothingMode = SmoothingMode.AntiAlias;
            Point pntCheckPointOneTop = new Point(GetUpButtonBounds().X + 6, GetUpButtonBounds().Y + GetUpButtonBounds().Height - 3);
            Point[] CheckPointsTop = {
            pntCheckPointOneTop,
            new Point(pntCheckPointOneTop.X + 3, pntCheckPointOneTop.Y - 2),
            new Point(pntCheckPointOneTop.X + 6, pntCheckPointOneTop.Y)
        };
            if (GetUpButtonBounds().Contains(pntMouseLocation))
            {
                G.DrawLines(new Pen(Color.White), CheckPointsTop);
            }
            else
            {
                G.DrawLines(new Pen(Color.FromArgb(220, 220, 220)), CheckPointsTop);
            }
            //Draw down sign
            Point pntCheckPointOneBottom = new Point(GetDownButtonBounds().X + 6, GetDownButtonBounds().Y + 3);
            Point[] CheckPointsBottom = {
            pntCheckPointOneBottom,
            new Point(pntCheckPointOneBottom.X + 3, pntCheckPointOneBottom.Y + 2),
            new Point(pntCheckPointOneBottom.X + 6, pntCheckPointOneBottom.Y)
        };
            if (GetDownButtonBounds().Contains(pntMouseLocation))
            {
                G.DrawLines(new Pen(Color.White), CheckPointsBottom);
            }
            else
            {
                G.DrawLines(new Pen(Color.FromArgb(220, 220, 220)), CheckPointsBottom);
            }
            //Draw border
            G.DrawPath(OuterBorder, CreateRound(new Rectangle(0, 0, Width - 1, Height - 1), 4));
            G.DrawPath(InnerBorder, CreateRound(new Rectangle(1, 1, Width - 3, Height - 3), 4));
        }
        private void OnBaseFocusLost(object s, EventArgs e)
        {
            if (string.IsNullOrEmpty(Base.Text))
            {
                Base.Text = "0";
                Value = 0;
            }
        }
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            if (Base.Text != "-")
            {
                if (Base.Text.Contains("-") & !Base.Text.StartsWith("-"))
                {
                    Base.Text = Base.Text.Substring(Base.Text.IndexOf("-")) + Base.Text.Substring(0, Base.Text.IndexOf("-"));
                    Base.Select(Base.Text.Length, 0);
                }
                if (!string.IsNullOrEmpty(Base.Text))
                {
                    if (Convert.ToInt32(Base.Text) <= _MaxValue)
                    {
                        if (Convert.ToInt32(Base.Text) >= _MinValue)
                        {
                            Value = Convert.ToInt32(Base.Text);
                        }
                        else
                        {
                            Value = _MinValue;
                            Base.Text = _MinValue.ToString();
                        }
                    }
                    else
                    {
                        Value = _MaxValue;
                        Base.Text = _MaxValue.ToString();
                    }
                }
            }
        }
        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                Base.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.OemMinus | e.KeyCode == Keys.Subtract)
            {
                e.SuppressKeyPress = true;
                if (!Base.Text.StartsWith("-"))
                {
                    Base.Text = "-" + Base.Text;
                    Base.Select(Base.Text.Length, 0);
                }
            }
            if (!this.IsNumeric(e))
            {
                e.SuppressKeyPress = true;
            }
        }
        private bool IsNumeric(KeyEventArgs e)
        {
            Keys k = e.KeyCode;
            return (k == Keys.NumPad0 | k == Keys.NumPad1 | k == Keys.NumPad2 | k == Keys.NumPad3 | k == Keys.NumPad4 | k == Keys.NumPad5 | k == Keys.NumPad6 | k == Keys.NumPad7 | k == Keys.NumPad8 | k == Keys.NumPad9 | (e.Shift & (k == Keys.D0 | k == Keys.D1 | k == Keys.D2 | k == Keys.D3 | k == Keys.D4 | k == Keys.D5 | k == Keys.D6 | k == Keys.D7 | k == Keys.D8 | k == Keys.D9)) | k == Keys.Back | k == Keys.Delete | k == Keys.Right | k == Keys.Left | k == Keys.OemMinus | k == Keys.Subtract);
        }
        protected override void OnResize(EventArgs e)
        {
            Base.Location = new Point(5, 4);
            Base.Width = Width - 31;

            base.OnResize(e);
        }
    }


}


