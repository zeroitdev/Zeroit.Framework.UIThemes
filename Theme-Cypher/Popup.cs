// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Popup.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Cypher
{
    public class Popup : Control
    {
        string[] _items;

        List<Rectangle> ListOfRec = new List<Rectangle>();
        public Popup(string[] items)
        {
            DoubleBuffered = true;
            _items = items;
            FixWidth();
            FixList();

        }
        protected override void OnHandleCreated(System.EventArgs e)
        {
            Console.WriteLine(TopLevelControl.TopLevelControl);
            BringToFront();
            base.OnHandleCreated(e);
        }
        bool MyMousedown = false;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            MyMousedown = true;
            Invalidate();
            _item = Temp_item;
            Console.WriteLine("Item: " + SelectedItem);
            Input = true;
            this.Hide();
            base.OnMouseDown(e);
        }

        public void FixWidth()
        {
            Graphics G = Graphics.FromImage(new Bitmap(1, 1));
            int LongestWidth = 0;
            foreach (string Str in _items)
            {
                if (G.MeasureString(Str, Font).Width > LongestWidth)
                {
                    LongestWidth = (int)G.MeasureString(Str, Font).Width;
                }
            }

            if (LongestWidth < 85)
            {
                Width = 95;
            }
            else
            {
                this.Width = LongestWidth + 9;
            }

        }
        public void FixList()
        {
            dynamic MyHeight = 23 * _items.Length - 1;
            int AantalRecs = MyHeight / 23;
            ListOfRec.Add(new Rectangle(2, 3, Width - 5, 23));
            for (int i = 1; i <= AantalRecs; i++)
            {
                Rectangle rec = new Rectangle(2, 23 * i, Width - 5, 23);
                ListOfRec.Add(rec);
            }

            this.Height = MyHeight + 5;
            Invalidate();
        }
        Rectangle SelectedReg = new Rectangle(0, 0, 0, 0);
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            Rectangle Oldrec = SelectedReg;
            foreach (Rectangle rec in ListOfRec)
            {
                if (rec.Contains(e.Location))
                {
                    SelectedReg = rec;
                }
            }
            if (!(Oldrec == SelectedReg))
            {
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        bool Input = false;
        public void WaitForInput()
        {
            while (Input == false)
            {
                System.Threading.Thread.Sleep(1);
            }
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            SelectedReg = new Rectangle(0, 0, 0, 0);
            this.Visible = false;
            Input = true;
            base.OnMouseLeave(e);
        }

        string _item = "";
        public string SelectedItem
        {
            get { return _item; }
            set { _item = value; }
        }

        string Temp_item = "";
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {

                    Rectangle Fullrec = new Rectangle(0, 0, Width - 1, Height - 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(20, 13, 6)), Fullrec);
                    g.DrawRectangle(new Pen(Color.FromArgb(16, 11, 5)), Fullrec);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(177, 177, 179)), SelectedReg);
                    g.DrawRectangle(new Pen(Color.FromArgb(51, 51, 50)), SelectedReg);

                    if (SelectedReg.Contains(new Point(5, 5)))
                    {
                        g.DrawString(_items[0].ToString(), Font, new SolidBrush(Color.FromArgb(20, 13, 6)), 5, 6);
                        Console.WriteLine("Selected item " + _items[0]);
                        Temp_item = _items[0];
                    }
                    else
                    {
                        g.DrawString(_items[0].ToString(), Font, Brushes.White, 5, 6);
                    }


                    for (int I = 1; I <= _items.Length - 1; I++)
                    {
                        if (SelectedReg.Contains(new Point(5, I * 23 + 5)))
                        {
                            g.DrawString(_items[I].ToString(), Font, new SolidBrush(Color.FromArgb(20, 13, 6)), 5, I * 23 + 5);
                            Console.WriteLine("Selected item: " + _items[I]);
                            Temp_item = _items[I];
                        }
                        else
                        {
                            g.DrawString(_items[I].ToString(), Font, Brushes.White, 5, I * 23 + 5);
                        }
                    }
                    e.Graphics.DrawImage(b, 0, 0);
                }
            }
            base.OnPaint(e);
        }

    }


}
