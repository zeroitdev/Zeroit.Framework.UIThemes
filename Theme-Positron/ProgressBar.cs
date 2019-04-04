// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Positron
{
    public class PositronProgressBar : ThemeControl154
    {
        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value >= Minimum & value <= _Max)
                {
                    _Value = value;
                }
                Invalidate();
            }
        }

        private Orientation _Orientation;
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                Invalidate();
            }
        }


        private int _Max = 100;
        public int Maximum
        {
            get { return _Max; }
            set
            {
                if (value > _Min)
                {
                    _Max = value;
                }
                Invalidate();
            }
        }

        private int _Min = 0;
        public int Minimum
        {
            get { return _Min; }
            set
            {
                if (value < _Max)
                {
                    _Min = value;
                }
                Invalidate();
            }
        }

        private void Increment(int amount)
        {
            Value += amount;
        }

        private bool _ShowValue = false;
        [Description("Indicates if the value of the progress bar will be shown in the middle of it.")]
        public bool ShowValue
        {
            get { return _ShowValue; }
            set
            {
                _ShowValue = value;
                Invalidate();
            }
        }

        private Brush BT;
        private Pen IB;
        private Pen PB;
        private Color BG;

        private Color IC;
        public PositronProgressBar()
        {
            Transparent = true;
            Value = 50;
            ShowValue = true;
            SetColor("Text", Color.FromArgb(100, 100, 100));
            SetColor("Inside", Color.FromArgb(200, 200, 200));
            SetColor("Border", Color.FromArgb(150, 150, 150));
            SetColor("BG", Color.FromArgb(210, 210, 210));
            SetColor("IC", Color.FromArgb(215, 215, 215));
            MinimumSize = new Size(40, 14);
            Size = new Size(175, 30);
        }

        protected override void ColorHook()
        {
            BT = GetBrush("Text");
            IB = GetPen("Inside");
            PB = GetPen("Border");
            BG = GetColor("BG");
            IC = GetColor("IC");
        }

        protected override void PaintHook()
        {
            switch (_Orientation)
            {
                case System.Windows.Forms.Orientation.Horizontal:

                    int area = Convert.ToInt32((_Value * (Width - 6)) / _Max);
                    G.Clear(BG);
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90f);

                    if (_Value == _Max)
                    {
                        G.FillRectangle(LGB1, new Rectangle(3, 3, Width - 4, Height - 4));
                        DrawBorders(PB, 3);
                    }
                    else if (_Value == _Min)
                    {
                    }
                    else
                    {
                        G.FillRectangle(LGB1, new Rectangle(3, 3, area, Height - 4));
                        G.DrawRectangle(PB, new Rectangle(3, 3, area - 1, Height - 7));
                    }
                    if (_ShowValue)
                    {
                        string val = _Value.ToString();
                        DrawText(BT, val, HorizontalAlignment.Center, 0, 0);
                    }

                    break; // TODO: might not be correct. Was : Exit Select


                    break;
                case System.Windows.Forms.Orientation.Vertical:

                    int area2 = Convert.ToInt32((_Value * (Height - 6)) / _Max);

                    G.Clear(BG);
                    LinearGradientBrush LGB2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90f);

                    if (_Value == _Max)
                    {
                        G.FillRectangle(LGB2, new Rectangle(3, 3, Width - 4, Height - 4));
                        DrawBorders(PB, 3);
                    }
                    else if (_Value == _Min)
                    {
                    }
                    else
                    {
                        G.FillRectangle(LGB2, new Rectangle(3, 3, Width - 4, area2));
                        G.DrawRectangle(PB, new Rectangle(3, 3, Width - 7, area2));
                    }
                    if (_ShowValue)
                    {
                        string val = _Value.ToString();
                        DrawText(BT, val, HorizontalAlignment.Center, 0, 0);
                    }


                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }

            DrawBorders(IB);
            DrawBorders(PB, 1);
        }
    }
}

