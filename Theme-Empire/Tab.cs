// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empire
{
    public class TheEmpireTabcontrol : TabControl
    {

        #region "Declarations, functions"
        int _IndexOver = -1;
        int X;
        int Y;
        #endregion
        Color EmpirePurple = Color.FromArgb(55, 173, 242);

        #region "Initialization"
        public TheEmpireTabcontrol()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(37, 120);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }
        #endregion

        #region "Mouse Events"

        int _OldIndexOver = 0;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            X = e.Location.X;
            Y = e.Location.Y;
            if (e.X > ItemSize.Height)
            {
                _IndexOver = -1;
            }
            else
            {
                Y = (Y - (Y % ItemSize.Width)) / ItemSize.Width;
                _IndexOver = Y;
            }

            if (_IndexOver != _OldIndexOver)
            {
                Invalidate();
            }

            _OldIndexOver = _IndexOver;
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _IndexOver = -1;
            Invalidate();
            base.OnMouseLeave(e);
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(36, 36, 36));
            e.Graphics.FillRectangle(new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(42, 42, 42), Color.FromArgb(25, 25, 25), 90f), new Rectangle(0, 0, Width, Height));

            e.Graphics.FillRectangle(Brushes.Gainsboro, new Rectangle(ItemSize.Height, 0, Width - ItemSize.Height, Height));
            LinearGradientBrush LinearGB = new LinearGradientBrush(new Rectangle(ItemSize.Height, 0, Width - ItemSize.Height, 4), Color.FromArgb(90, Color.Black), Color.Transparent, 90f);
            e.Graphics.FillRectangle(LinearGB, LinearGB.Rectangle);
            e.Graphics.DrawLine(Pens.Black, new Point(ItemSize.Height, 0), new Point(ItemSize.Height, Height));

            try
            {
                foreach (TabPage T in TabPages)
                {
                    T.BackColor = Color.FromArgb(200, 200, 200);
                }
            }
            catch
            {
            }


            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width, GetTabRect(i).Height));
                Rectangle textrectangle = new Rectangle(x2.Location.X + 34, x2.Location.Y, x2.Width - 34, x2.Height);

                if (i == SelectedIndex)
                {
                    LinearGradientBrush LGB = new LinearGradientBrush(x2, Color.FromArgb(36, 36, 36), Color.FromArgb(25, 25, 25), 90f);
                    e.Graphics.FillRectangle(LGB, LGB.Rectangle);
                    //e.Graphics.FillRectangle(New SolidBrush(EmpirePurple), New Rectangle(x2.Location, New Size(6, x2.Height)))

                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(51, 51, 51)), x2);
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(17, 17, 17)), new Point(x2.Location.X + 1, x2.Location.Y + x2.Height - 1), new Point(x2.Location.X + x2.Width, x2.Location.Y + x2.Height - 1));

                    e.Graphics.DrawString(TabPages[i].Text, Font, Brushes.Gainsboro, textrectangle, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
                else
                {
                    e.Graphics.DrawString(TabPages[i].Text, Font, Brushes.Gray, textrectangle, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(51, 51, 51)), x2);
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(17, 17, 17)), new Point(x2.Location.X + 1, x2.Location.Y + x2.Height - 1), new Point(x2.Location.X + x2.Width, x2.Location.Y + x2.Height - 1));
                }

                if (i == _IndexOver)
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(3, Color.White)), x2);
            }
        }


    }


}