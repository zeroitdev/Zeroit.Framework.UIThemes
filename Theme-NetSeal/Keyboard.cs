// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Keyboard.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSKeyboard : Control
    {

        private Bitmap TextBitmap;

        private Graphics TextGraphics;
        const string LowerKeys = "1234567890-=qwertyuiop[]asdfghjkl\\;'zxcvbnm,./`";

        const string UpperKeys = "!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL|:\"ZXCVBNM<>?~";
        public NSKeyboard()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font("Verdana", 8.25f);

            TextBitmap = new Bitmap(1, 1);
            TextGraphics = Graphics.FromImage(TextBitmap);

            MinimumSize = new Size(386, 162);
            MaximumSize = new Size(386, 162);

            Lower = LowerKeys.ToCharArray();
            Upper = UpperKeys.ToCharArray();

            PrepareCache();

            P1 = new Pen(Color.FromArgb(45, 45, 45));
            P2 = new Pen(Color.FromArgb(65, 65, 65));
            P3 = new Pen(Color.FromArgb(24, 24, 24));

            B1 = new SolidBrush(Color.FromArgb(100, 100, 100));
        }

        private Control _Target;
        public Control Target
        {
            get { return _Target; }
            set { _Target = value; }
        }


        private bool Shift;
        private int Pressed = -1;

        private Rectangle[] Buttons;
        private char[] Lower;
        private char[] Upper;
        private string[] Other = {
        "Shift",
        "Space",
        "Back"

    };
        private PointF[] UpperCache;

        private PointF[] LowerCache;
        private void PrepareCache()
        {
            Buttons = new Rectangle[51];
            UpperCache = new PointF[Upper.Length];
            LowerCache = new PointF[Lower.Length];

            int I = 0;

            SizeF S = default(SizeF);
            Rectangle R = default(Rectangle);

            for (int Y = 0; Y <= 3; Y++)
            {
                for (int X = 0; X <= 11; X++)
                {
                    I = (Y * 12) + X;
                    R = new Rectangle(X * 32, Y * 32, 32, 32);

                    Buttons[I] = R;

                    if (!(I == 47) && !char.IsLetter(Upper[I]))
                    {
                        S = TextGraphics.MeasureString(Upper[I].ToString(), Font);
                        UpperCache[I] = new PointF(R.X + (R.Width / 2 - S.Width / 2), R.Y + R.Height - S.Height - 2);

                        S = TextGraphics.MeasureString(Lower[I].ToString(), Font);
                        LowerCache[I] = new PointF(R.X + (R.Width / 2 - S.Width / 2), R.Y + R.Height - S.Height - 2);
                    }
                }
            }

            Buttons[48] = new Rectangle(0, 4 * 32, 2 * 32, 32);
            Buttons[49] = new Rectangle(Buttons[48].Right, 4 * 32, 8 * 32, 32);
            Buttons[50] = new Rectangle(Buttons[49].Right, 4 * 32, 2 * 32, 32);
        }


        private GraphicsPath GP1;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P1;
        private Pen P2;
        private Pen P3;

        private SolidBrush B1;
        private PathGradientBrush PB1;

        private LinearGradientBrush GB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);

            Rectangle R = new Rectangle(0, 0, Width, Height);

            int Offset = 0;
            G.DrawRectangle(P1, 0, 0, (12 * 32) + 1, (5 * 32) + 1);

            for (int I = 0; I <= Buttons.Length - 1; I++)
            {
                R = Buttons[I];

                Offset = 0;
                if (I == Pressed)
                {
                    Offset = 1;

                    GP1 = new GraphicsPath();
                    GP1.AddRectangle(R);

                    PB1 = new PathGradientBrush(GP1);
                    PB1.CenterColor = Color.FromArgb(60, 60, 60);
                    PB1.SurroundColors = new Color[] { Color.FromArgb(55, 55, 55) };
                    PB1.FocusScales = new PointF(0.8f, 0.5f);

                    G.FillPath(PB1, GP1);
                }
                else
                {
                    GB1 = new LinearGradientBrush(R, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90f);
                    G.FillRectangle(GB1, R);
                }

                switch (I)
                {
                    case 48:
                    case 49:
                    case 50:
                        SZ1 = G.MeasureString(Other[I - 48], Font);
                        G.DrawString(Other[I - 48], Font, Brushes.Black, R.X + (R.Width / 2 - SZ1.Width / 2) + Offset + 1, R.Y + (R.Height / 2 - SZ1.Height / 2) + Offset + 1);
                        G.DrawString(Other[I - 48], Font, Brushes.WhiteSmoke, R.X + (R.Width / 2 - SZ1.Width / 2) + Offset, R.Y + (R.Height / 2 - SZ1.Height / 2) + Offset);
                        break;
                    case 47:
                        //DrawArrow(Color.Black, /*R.X +*/ /*Offset +*/ 1, /*R.Y +*/ /*Offset*/ + 1);
                        //DrawArrow(Color.FromArgb(235, 235, 235), R.X + Offset, R.Y + Offset);
                        break;
                    default:
                        if (Shift)
                        {
                            G.DrawString(Upper[I].ToString(), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1);
                            G.DrawString(Upper[I].ToString(), Font, Brushes.WhiteSmoke, R.X + 3 + Offset, R.Y + 2 + Offset);

                            if (!char.IsLetter(Lower[I]))
                            {
                                PT1 = LowerCache[I];
                                G.DrawString(Lower[I].ToString(), Font, B1, PT1.X + Offset, PT1.Y + Offset);
                            }
                        }
                        else
                        {
                            G.DrawString(Lower[I].ToString(), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1);
                            G.DrawString(Lower[I].ToString(), Font, Brushes.WhiteSmoke, R.X + 3 + Offset, R.Y + 2 + Offset);

                            if (!char.IsLetter(Upper[I]))
                            {
                                PT1 = UpperCache[I];
                                G.DrawString(Upper[I].ToString(), Font, B1, PT1.X + Offset, PT1.Y + Offset);
                            }
                        }
                        break;
                }

                G.DrawRectangle(P2, R.X + 1 + Offset, R.Y + 1 + Offset, R.Width - 2, R.Height - 2);
                G.DrawRectangle(P3, R.X + Offset, R.Y + Offset, R.Width, R.Height);

                if (I == Pressed)
                {
                    G.DrawLine(P1, R.X, R.Y, R.Right, R.Y);
                    G.DrawLine(P1, R.X, R.Y, R.X, R.Bottom);
                }
            }
        }

        private void DrawArrow(Color color, int rx, int ry)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            Rectangle R = new Rectangle(rx + 8, ry + 8, 16, 16);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            Pen P = new Pen(color, 1);
            AdjustableArrowCap C = new AdjustableArrowCap(3, 2);
            P.CustomEndCap = C;

            G.DrawArc(P, R, 0f, 290f);

            P.Dispose();
            C.Dispose();
            G.SmoothingMode = SmoothingMode.None;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int Index = ((e.Y / 32) * 12) + (e.X / 32);

            if (Index > 47)
            {
                for (int I = 48; I <= Buttons.Length - 1; I++)
                {
                    if (Buttons[I].Contains(e.X, e.Y))
                    {
                        Pressed = I;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            else
            {
                Pressed = Index;
            }

            HandleKey();
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Pressed = -1;
            Invalidate();
        }

        private void HandleKey()
        {
            if (_Target == null)
                return;
            if (Pressed == -1)
                return;

            switch (Pressed)
            {
                case 47:
                    _Target.Text = string.Empty;
                    break;
                case 48:
                    Shift = !Shift;
                    break;
                case 49:
                    _Target.Text += " ";
                    break;
                case 50:
                    if (!(_Target.Text.Length == 0))
                    {
                        _Target.Text = _Target.Text.Remove(_Target.Text.Length - 1);
                    }
                    break;
                default:
                    if (Shift)
                    {
                        _Target.Text += Upper[Pressed];
                    }
                    else
                    {
                        _Target.Text += Lower[Pressed];
                    }
                    break;
            }
        }

    }

}


