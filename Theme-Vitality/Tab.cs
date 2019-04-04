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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Vitality
{
    public class VitalityTabControl : TabControl
    {

        public VitalityTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            try
            {
                SelectedTab.BackColor = Color.FromArgb(240, 240, 240);
            }
            catch
            {
            }
            G.Clear(Parent.BackColor);
            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (!(i == SelectedIndex))
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 2, GetTabRect(i).Height);
                    LinearGradientBrush G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height), Color.White, Color.LightGray);
                    G.FillRectangle(G1, x2);
                    G1.Dispose();
                    G.DrawRectangle(Pens.LightGray, x2);
                    G.DrawRectangle(Pens.LightGray, new Rectangle(x2.X + 1, x2.Y + 1, x2.Width - 2, x2.Height));
                    G.DrawString(TabPages[i].Text, Font, Brushes.Gray, x2, new StringFormat
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Center
                    });
                }
            }

            G.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), 0, ItemSize.Height, Width, Height);
            G.DrawRectangle(Pens.LightGray, 0, ItemSize.Height, Width - 1, Height - ItemSize.Height - 1);
            G.DrawRectangle(Pens.LightGray, 1, ItemSize.Height + 1, Width - 3, Height - ItemSize.Height - 3);
            if (!(SelectedIndex == -1))
            {
                Rectangle x1 = new Rectangle(GetTabRect(SelectedIndex).X - 2, GetTabRect(SelectedIndex).Y, GetTabRect(SelectedIndex).Width + 3, GetTabRect(SelectedIndex).Height);
                LinearGradientBrush GradientBrush = new LinearGradientBrush(new Rectangle(x1.X + 2, x1.Y + 2, x1.Width - 2, x1.Height), Color.White, Color.LightGray, 90f);
                G.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), new Rectangle(x1.X + 2, x1.Y + 2, x1.Width - 2, x1.Height));
                G.DrawLine(Pens.LightGray, new Point(x1.X, x1.Y + x1.Height - 2), new Point(x1.X, x1.Y));
                G.DrawLine(Pens.LightGray, new Point(x1.X, x1.Y), new Point(x1.X + x1.Width, x1.Y));
                G.DrawLine(Pens.LightGray, new Point(x1.X + x1.Width, x1.Y), new Point(x1.X + x1.Width, x1.Y + x1.Height - 2));

                G.DrawLine(Pens.LightGray, new Point(x1.X + 1, x1.Y + x1.Height - 1), new Point(x1.X + 1, x1.Y + 1));
                G.DrawLine(Pens.LightGray, new Point(x1.X + 1, x1.Y + 1), new Point(x1.X + x1.Width - 1, x1.Y + 1));
                G.DrawLine(Pens.LightGray, new Point(x1.X + x1.Width - 1, x1.Y + 1), new Point(x1.X + x1.Width - 1, x1.Y + x1.Height - 1));

                G.DrawString(TabPages[SelectedIndex].Text, Font, Brushes.Gray, x1, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
            }

            G.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), new Point(0, 1), new Point(0, 2));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}

