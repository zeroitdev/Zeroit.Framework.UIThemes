// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Ghost
{

    public class GhostComboBox : ComboBox
    {

        private int X;
        public GhostComboBox() : base()
        {
            TextChanged += GhostCombo_TextChanged;
            DropDownClosed += GhostComboBox_DropDownClosed;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 20;
            BackColor = Color.FromArgb(30, 30, 30);
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            X = -1;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(DropDownStyle == ComboBoxStyle.DropDownList))
                DropDownStyle = ComboBoxStyle.DropDownList;
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(Color.FromArgb(50, 50, 50));
            LinearGradientBrush GradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 5 * 2), Color.FromArgb(20, 0, 0, 0), Color.FromArgb(15, Color.White), 90f);
            G.FillRectangle(GradientBrush, new Rectangle(0, 0, Width, Height / 5 * 2));
            HatchBrush hatch = default(HatchBrush);
            hatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.FromArgb(0, Color.Gray));
            G.FillRectangle(hatch, 0, 0, Width, Height);

            int S1 = (int)G.MeasureString("...", Font).Height;
            if (SelectedIndex != -1)
            {
                G.DrawString(Items[SelectedIndex].ToString(), Font, new SolidBrush(Color.White), 4, Height / 2 - S1 / 2);
            }
            else
            {
                if ((Items != null) & Items.Count > 0)
                {
                    G.DrawString(GetItemText(Items[0]), Font, new SolidBrush(Color.White), 4, Height / 2 - S1 / 2);
                }
                else
                {
                    G.DrawString("...", Font, new SolidBrush(Color.White), 4, Height / 2 - S1 / 2);
                }
            }

            if (MouseButtons == MouseButtons.None & X > Width - 25)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(7, Color.White)), Width - 25, 1, Width - 25, Height - 3);
            }
            else if (MouseButtons == MouseButtons.None & X < Width - 25 & X >= 0)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(7, Color.White)), 2, 1, Width - 27, Height - 3);
            }

            G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, Width - 3, Height - 3);
            G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), Width - 25, 1, Width - 25, Height - 3);
            G.DrawLine(Pens.Black, Width - 24, 0, Width - 24, Height);
            G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), Width - 23, 1, Width - 23, Height - 3);

            G.FillPolygon(Brushes.Black, Triangle(new Point(Width - 14, Height / 2), new Size(5, 3)));
            G.FillPolygon(Brushes.White, Triangle(new Point(Width - 15, Height / 2 - 1), new Size(5, 3)));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Rectangle rect = new Rectangle();
            rect.X = e.Bounds.X;
            rect.Y = e.Bounds.Y;
            rect.Width = e.Bounds.Width - 1;
            rect.Height = e.Bounds.Height - 1;

            e.DrawBackground();
            if (e.State == DrawItemState.Selected /*785*/ | e.State == DrawItemState.Focus /*| e.State == DrawItemState.None*/  /* 17*/)
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
                Rectangle x2 = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 1, e.Bounds.Height));
                Rectangle x3 = new Rectangle(x2.Location, new Size(x2.Width, (x2.Height / 2) - 1));
                LinearGradientBrush G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height), Color.FromArgb(60, 60, 60), Color.FromArgb(50, 50, 50));
                HatchBrush H = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.Black), Color.Transparent);
                e.Graphics.FillRectangle(G1, x2);
                G1.Dispose();
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), x3);
                e.Graphics.FillRectangle(H, x2);
                G1.Dispose();
                e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
                e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
            }
            base.OnDrawItem(e);
        }

        public Point[] Triangle(Point Location, Size Size)
        {
            Point[] ReturnPoints = new Point[4];
            ReturnPoints[0] = Location;
            ReturnPoints[1] = new Point(Location.X + Size.Width, Location.Y);
            ReturnPoints[2] = new Point(Location.X + Size.Width / 2, Location.Y + Size.Height);
            ReturnPoints[3] = Location;

            return ReturnPoints;
        }

        private void GhostComboBox_DropDownClosed(object sender, System.EventArgs e)
        {
            DropDownStyle = ComboBoxStyle.Simple;
            Application.DoEvents();
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void GhostCombo_TextChanged(object sender, System.EventArgs e)
        {
            Invalidate();
        }
    }


}
