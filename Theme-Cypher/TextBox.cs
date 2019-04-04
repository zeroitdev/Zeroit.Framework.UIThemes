// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Cypher
{
    public class CyperxTextbox : Control
    {

        Color Stroke = Color.FromArgb(80, 71, 62);
        Color Bg = Color.FromArgb(67, 60, 53);
        TextBox tbox;
        public CyperxTextbox()
        {
            this.Text = "";
            tbox = null;
            tbox = new TextBox();
            tbox.Text = Text;
            tbox.BorderStyle = BorderStyle.None;
            tbox.BackColor = Color.FromArgb(25, 18, 12);
            tbox.Location = new Point(3, 4);
            tbox.Width = Width - 7;
            tbox.Font = Font;
            tbox.UseSystemPasswordChar = Pwbox;
            tbox.ForeColor = Color.White;
            this.Controls.Add(tbox);
            tbox.TextChanged += TextChange;
        }

        bool Pwbox = false;
        bool DrawRounded = true;
        public bool Rounded
        {
            get { return DrawRounded; }
            set { DrawRounded = value; }
        }

        public bool UseSystemPasswordChar
        {
            get { return Pwbox; }
            set
            {
                Pwbox = value;
                tbox = null;
                tbox = new TextBox();
                tbox.Text = Text;
                tbox.BorderStyle = BorderStyle.None;
                tbox.BackColor = Color.FromArgb(25, 18, 12);
                tbox.Location = new Point(3, 4);
                tbox.Width = Width - 7;
                tbox.Font = Font;
                tbox.UseSystemPasswordChar = Pwbox;
                tbox.ForeColor = Color.White;
                this.Controls.Add(tbox);
                tbox.TextChanged += TextChange;
            }
        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            tbox = new TextBox();
            tbox.Text = Text;
            tbox.BorderStyle = BorderStyle.None;
            tbox.BackColor = Color.FromArgb(25, 18, 12);
            tbox.Location = new Point(3, 4);
            tbox.Width = Width - 7;
            tbox.Font = Font;
            tbox.UseSystemPasswordChar = Pwbox;
            tbox.ForeColor = Color.White;
            this.Controls.Add(tbox);
            tbox.TextChanged += TextChange;
            base.OnHandleCreated(e);
        }

        private void TextChange(object sender, EventArgs e)
        {
            this.Text = tbox.Text;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(25, 18, 12)), new Rectangle(0, 0, Width, Height));
                    if (DrawRounded)
                    {
                        GraphicsPath Outline = Draw.RoundedRectangle(0, 0, Width - 1, Height - 1, 10, 1);
                        g.DrawPath(new Pen(Stroke), Outline);
                    }
                    else
                    {
                        Rectangle rec = new Rectangle(0, 0, Width - 1, Height - 1);
                        g.FillRectangle(new SolidBrush(Color.FromArgb(25, 18, 12)), rec);
                        g.DrawRectangle(new Pen(Stroke), rec);
                    }
                    e.Graphics.DrawImage(b, 0, 0);
                }
            }
            base.OnPaint(e);
        }
    }

}
