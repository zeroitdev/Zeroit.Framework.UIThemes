// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSControlButton : Control
    {

        public enum Button : byte
        {
            None = 0,
            Minimize = 1,
            MaximizeRestore = 2,
            Close = 3
        }

        private Button _ControlButton = Button.Close;
        public Button ControlButton
        {
            get { return _ControlButton; }
            set
            {
                _ControlButton = value;
                Invalidate();
            }
        }

        public NSControlButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Width = 18;
            Height = 20;

            MinimumSize = Size;
            MaximumSize = Size;

            Margin = new Padding(0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.Clear(BackColor);

            switch (_ControlButton)
            {
                case Button.Minimize:
                    DrawMinimize(3, 10);
                    break;
                case Button.MaximizeRestore:
                    if (FindForm().WindowState == FormWindowState.Normal)
                    {
                        DrawMaximize(3, 5);
                    }
                    else
                    {
                        DrawRestore(3, 4);
                    }
                    break;
                case Button.Close:
                    DrawClose(4, 5);
                    break;
            }
        }

        private void DrawMinimize(int x, int y)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G.FillRectangle(Brushes.WhiteSmoke, x, y, 12, 5);
            G.DrawRectangle(Pens.Black, x, y, 11, 4);
        }

        private void DrawMaximize(int x, int y)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G.DrawRectangle(new Pen(Color.FromArgb(235, 235, 235), 2), x + 2, y + 2, 8, 6);
            G.DrawRectangle(Pens.Black, x, y, 11, 9);
            G.DrawRectangle(Pens.Black, x + 3, y + 3, 5, 3);
        }

        private void DrawRestore(int x, int y)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G.FillRectangle(Brushes.WhiteSmoke, x + 3, y + 1, 8, 4);
            G.FillRectangle(Brushes.WhiteSmoke, x + 7, y + 5, 4, 4);
            G.DrawRectangle(Pens.Black, x + 2, y + 0, 9, 9);

            G.FillRectangle(Brushes.WhiteSmoke, x + 1, y + 3, 2, 6);
            G.FillRectangle(Brushes.WhiteSmoke, x + 1, y + 9, 8, 2);
            G.DrawRectangle(Pens.Black, x, y + 2, 9, 9);
            G.DrawRectangle(Pens.Black, x + 3, y + 5, 3, 3);
        }

        private GraphicsPath ClosePath;
        private void DrawClose(int x, int y)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = this.CreateGraphics();

            //ClosePath = new GraphicsPath();

            if (ClosePath == null)
            {
                ClosePath = new GraphicsPath();
                ClosePath.AddLine(x + 1, y, x + 3, y);
                ClosePath.AddLine(x + 5, y + 2, x + 7, y);
                ClosePath.AddLine(x + 9, y, x + 10, y + 1);
                ClosePath.AddLine(x + 7, y + 4, x + 7, y + 5);
                ClosePath.AddLine(x + 10, y + 8, x + 9, y + 9);
                ClosePath.AddLine(x + 7, y + 9, x + 5, y + 7);
                ClosePath.AddLine(x + 3, y + 9, x + 1, y + 9);
                ClosePath.AddLine(x + 0, y + 8, x + 3, y + 5);
                ClosePath.AddLine(x + 3, y + 4, x + 0, y + 1);
            }
            G.FillPath(Brushes.WhiteSmoke, ClosePath);
            G.DrawPath(Pens.Black, ClosePath);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                System.Windows.Forms.Form F = FindForm();

                switch (_ControlButton)
                {
                    case Button.Minimize:
                        F.WindowState = FormWindowState.Minimized;
                        break;
                    case Button.MaximizeRestore:
                        if (F.WindowState == FormWindowState.Normal)
                        {
                            F.WindowState = FormWindowState.Maximized;
                        }
                        else
                        {
                            F.WindowState = FormWindowState.Normal;
                        }
                        break;
                    case Button.Close:
                        F.Close();
                        break;
                }

            }

            Invalidate();
            base.OnMouseClick(e);
        }

    }


}


