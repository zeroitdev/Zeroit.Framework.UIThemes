// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Intel
{
    public class iControlBox : ThemeControl154
    {
        protected override void ColorHook()
        {
        }

        public iControlBox()
        {
            MouseClick += ControlBoxClicked;
            IsAnimated = true;
            LockWidth = 52;
            LockHeight = 16;
            Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }

        private bool overMin;
        private bool overMax;

        private bool overExit;
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Location = new Point(Parent.FindForm().Width - 59, 4);
        }

        private int X;
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            if (e.X > 0 && e.X < 17)
            {
                overMin = true;
                overMax = false;
                overExit = false;
            }
            else if (e.X > 17 && e.X < 35)
            {
                overMin = false;
                overMax = true;
                overExit = false;
            }
            else if (e.X > 35 && e.X < 52)
            {
                overMin = false;
                overMax = false;
                overExit = true;
            }
            else
            {
                overMin = false;
                overMax = false;
                overExit = false;
            }
        }

        private void ControlBoxClicked(object sender, EventArgs e)
        {
            var _with1 = FindForm();
            if (overMin)
            {
                _with1.WindowState = FormWindowState.Minimized;
            }
            else if (overMax)
            {
                if (_with1.WindowState == FormWindowState.Normal)
                {
                    _with1.WindowState = FormWindowState.Maximized;
                }
                else if (_with1.WindowState == FormWindowState.Maximized)
                {
                    _with1.WindowState = FormWindowState.Normal;
                }
            }
            else if (overExit)
            {
                _with1.Close();
            }
        }

        private int minGlow;
        private int maxGlow;
        private int exitGlow;
        protected override void OnAnimation()
        {
            base.OnAnimation();
            if (overMin)
            {
                if (minGlow < 120)
                    minGlow += 5;
            }
            else
            {
                if (minGlow >= 3)
                    minGlow -= 3;
            }
            if (overMax)
            {
                if (maxGlow < 120)
                    maxGlow += 5;
            }
            else
            {
                if (maxGlow >= 3)
                    maxGlow -= 3;
            }
            if (overExit)
            {
                if (exitGlow < 120)
                    exitGlow += 5;
            }
            else
            {
                if (exitGlow >= 3)
                    exitGlow -= 3;
            }
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            overMin = false;
            overMax = false;
            overExit = false;
            Invalidate();
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(45, 45, 45));
            G.DrawString("0", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(120 + minGlow, Color.SteelBlue)), new Point(2, 3));
            if (Parent.FindForm().WindowState != FormWindowState.Maximized)
            {
                G.DrawString("1", new Font("Marlett", 9), new SolidBrush(Color.FromArgb(120 + maxGlow, Color.SteelBlue)), new Point(20, 4));
            }
            else
            {
                G.DrawString("2", new Font("Marlett", 9), new SolidBrush(Color.FromArgb(120 + maxGlow, Color.SteelBlue)), new Point(20, 4));
            }
            G.DrawString("r", new Font("Marlett", 10), new SolidBrush(Color.FromArgb(120 + exitGlow, Color.SteelBlue)), new Point(37, 3));
        }
    }


}


