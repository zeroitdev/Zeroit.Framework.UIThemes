// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-19-2019
// ***********************************************************************
// <copyright file="Angel Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Angel
{

    

    #region " Enums "
    public enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    public enum Alignment
    {
        Left = 0,
        Centre = 1,
        Right = 2
    }

    enum State
    {
        Enabled = 0,
        Disabled = 1
    }
    #endregion

    public class AngelTheme : ContainerControl
    {

        #region " Back End "

        #region " Declarations "
        private int H = 52;
        private bool D = false;
        private Point P;
        #endregion
        private Alignment A = Alignment.Left;

        #region " Mouse States "
        
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            D = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (new Rectangle(0, 0, Width, H).Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                P = e.Location;
                D = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (D == true)
            {
                ParentForm.Location = new Point(MousePosition.X - P.X, MousePosition.Y - P.Y);
            }
        }

        #endregion

        #region " Properties "

        #region " Appearance "
        [Category("Appearance")]
        public Alignment TextAlignment
        {
            get { return A; }
            set
            {
                A = value;
                Invalidate();
            }
        }

        #endregion

        #endregion

        #region " Misc "

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Parent.FindForm().AllowTransparency = true;
            Parent.FindForm().TransparencyKey = Color.Fuchsia;
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(17, 33, 47);
            Dock = DockStyle.Fill;
            Font = new Font("Segoe UI", 12);
            Invalidate();
        }

        #endregion

        #endregion
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.Black);
            G.DrawRectangle(new Pen(Color.FromArgb(10, 33, 55)), new Rectangle(0, 0, Width - 1, H));
            G.FillRectangle(new LinearGradientBrush(new Point(1, 1), new Point(1, H), Color.FromArgb(75, 168, 218), Color.FromArgb(33, 112, 177)), new Rectangle(1, 1, Width - 2, H - 1));
            G.FillRectangle(new LinearGradientBrush(new Point(2, 2), new Point(2, H - 1), Color.FromArgb(54, 131, 203), Color.FromArgb(26, 86, 145)), new Rectangle(2, 2, Width - 4, H - 3));
            G.DrawRectangle(new Pen(Color.FromArgb(27, 48, 66)), new Rectangle(1, H + 1, Width - 3, Height - H - 3));
            G.FillRectangle(new SolidBrush(Color.FromArgb(17, 33, 47)), new Rectangle(2, H + 1, Width - 4, Height - H - 3));

            StringFormat F = new StringFormat { LineAlignment = StringAlignment.Center };
            switch (A)
            {
                case Alignment.Left:
                    G.DrawString(Text, Font, Brushes.White, new Rectangle(8, 0, Width, H), F);
                    break;
                case Alignment.Centre:
                    F.Alignment = StringAlignment.Center;
                    G.DrawString(Text, Font, Brushes.White, new Rectangle(0, 0, Width - 1, H), F);
                    break;
                case Alignment.Right:
                    G.DrawString(Text, Font, Brushes.White, new Rectangle(Width - TextRenderer.MeasureText(Text, Font).Width - 8, 0, TextRenderer.MeasureText(Text, Font).Width + 8, H), F);
                    break;
            }

        }

    }

    
}