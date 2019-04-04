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

namespace Zeroit.Framework.UIThemes.Positron
{

    public class PositronTabControl : TabControl
    {
        private Brush TB;

        private int i = 0;
        protected void DrawBorders(Pen p1, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, G);
        }
        protected void DrawBorders(Pen p1, int offset, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset, G);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset, Graphics G)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2), G);
        }

        public PositronTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            SizeMode = TabSizeMode.Fixed;
            DoubleBuffered = true;
            ItemSize = new Size(30, 120);
            Size = new Size(250, 150);
            TB = new SolidBrush(Color.FromArgb(100, 100, 100));
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            HatchBrush HBS = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(6, Color.Black), Color.Transparent);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(FindForm().BackColor);
            G.FillRectangle(HBS, new Rectangle(0, 0, Width, Height));

            try
            {
                SelectedTab.BackColor = Color.FromArgb(210, 210, 210);
            }
            catch
            {
            }
            for (i = 0; i <= TabCount - 1; i++)
            {
                Rectangle TabRect = GetTabRect(i);
                try
                {
                    LinearGradientBrush LGB1 = new LinearGradientBrush(TabRect, Color.FromArgb(190, 190, 190), Color.FromArgb(220, 220, 220), 90f);
                    LinearGradientBrush LGB2 = new LinearGradientBrush(TabRect, Color.FromArgb(220, 220, 220), Color.FromArgb(190, 190, 190), 90f);

                    if (i == SelectedIndex)
                    {
                        G.FillRectangle(LGB1, TabRect);
                        G.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), TB, TabRect, new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        G.FillRectangle(LGB2, TabRect);
                        G.DrawString(TabPages[i].Text, Font, TB, TabRect, new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), new Point(TabRect.X, TabRect.Y), new Point(ItemSize.Height + 1, TabRect.Y));
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), new Point(), new Point());
                }
                catch
                {
                }
            }
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))), 1, G);
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), 2, G);
            G.DrawLine(new Pen(Color.FromArgb(150, 150, 150)), new Point(ItemSize.Height + 2, Height - (Height - 3)), new Point(ItemSize.Height + 2, Height - 3));

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
            base.OnPaint(e);
        }
    }
}

