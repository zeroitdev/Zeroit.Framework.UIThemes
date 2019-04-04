// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Bonfire
{
    public class BonfireTabControl : TabControl
    {
        public BonfireTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            ItemSize = new Size(0, 30);
            Font = new Font("Verdana", 8);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics G = e.Graphics;

            Pen borderPen = new Pen(Color.FromArgb(225, 225, 225));

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Parent.BackColor);

            Rectangle fillRect = new Rectangle(2, ItemSize.Height + 2, Width - 6, Height - ItemSize.Height - 3);
            G.FillRectangle(Brushes.White, fillRect);
            G.DrawRectangle(borderPen, fillRect);

            Color FontColor = new Color();

            for (var i = 0; i < TabCount; i++)
            {

                Rectangle mainRect = GetTabRect(i);

                if (i == SelectedIndex)
                {

                    G.FillRectangle(new SolidBrush(Color.White), mainRect);
                    G.DrawRectangle(borderPen, mainRect);
                    G.DrawLine(new Pen(Color.FromArgb(20, 160, 230)), new Point(mainRect.X + 1, mainRect.Y), new Point(mainRect.X + mainRect.Width - 1, mainRect.Y));
                    G.DrawLine(Pens.White, new Point(mainRect.X + 1, mainRect.Y + mainRect.Height), new Point(mainRect.X + mainRect.Width - 1, mainRect.Y + mainRect.Height));
                    FontColor = Color.FromArgb(20, 160, 230);

                }
                else
                {

                    G.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 245)), mainRect);
                    G.DrawRectangle(borderPen, mainRect);
                    FontColor = Color.FromArgb(160, 160, 160);

                }

                int titleX = Convert.ToInt32((mainRect.Location.X + mainRect.Width / 2.0) - (G.MeasureString(TabPages[i].Text, Font).Width / 2.0));
                int titleY = Convert.ToInt32((mainRect.Location.Y + mainRect.Height / 2.0) - (G.MeasureString(TabPages[i].Text, Font).Height / 2.0));
                G.DrawString(TabPages[i].Text, Font, new SolidBrush(FontColor), new Point(titleX, titleY));

                try
                {
                    TabPages[i].BackColor = Color.White;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }


            }

        }

    }
}
