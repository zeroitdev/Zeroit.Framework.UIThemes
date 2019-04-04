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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Meph
{

    public class MephTabcontrol : TabControl
    {
        public GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public MephTabcontrol()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(35, 85);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Font FF = new Font("Verdana", 8, FontStyle.Regular);
            try
            {
                SelectedTab.BackColor = Color.FromArgb(50, 50, 50);
            }
            catch
            {
            }
            G.Clear(Parent.FindForm().BackColor);

            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), new Rectangle(0, 0, ItemSize.Height + 3, Height - 1));
            //Full Tab Background

            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    ColorBlend myBlend = new ColorBlend();
                    myBlend.Colors = new Color[]{
                    Color.FromArgb(50, 50, 50),
                    Color.FromArgb(50, 50, 50),
                    Color.FromArgb(50, 50, 50)
                };
                    //Full Tab Background Gradient Accents
                    myBlend.Positions = new float[]{
                    0f,
                    0.5f,
                    1f
                };
                    LinearGradientBrush lgBrush = new LinearGradientBrush(x2, Color.Black, Color.Black, 90f);
                    lgBrush.InterpolationColors = myBlend;
                    G.FillRectangle(lgBrush, x2);
                    //G.DrawRectangle(New Pen(Color.FromArgb(20, 20, 20)), x2) 'Full Tab Highlight Outline
                    Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X + 4, GetTabRect(i).Location.Y + 2, GetTabRect(i).Size.Width + 10, GetTabRect(i).Size.Height - 11);
                    G.FillPath(new SolidBrush(Color.FromArgb(50, 50, 50)), RoundRect(tabRect, 4));
                    //Highlight Fill Background

                    Color[] cFull = new Color[] {
                    Color.FromArgb(20, 20, 20),
                    Color.FromArgb(40, 40, 40),
                    Color.FromArgb(45, 45, 45),
                    Color.FromArgb(46, 46, 46),
                    Color.FromArgb(47, 47, 47),
                    Color.FromArgb(48, 48, 48),
                    Color.FromArgb(49, 49, 49),
                    Color.FromArgb(50, 50, 50)
                };
                    Draw.InnerGlow(G, new Rectangle(0, 0, ItemSize.Height + 3, Height - 1), cFull);
                    // Main Left Box Outline

                    Color[] cHighlight = new Color[] {
                    Color.FromArgb(20, 20, 20),
                    Color.FromArgb(40, 40, 40),
                    Color.FromArgb(45, 45, 45),
                    Color.FromArgb(46, 46, 46),
                    Color.FromArgb(47, 47, 47),
                    Color.FromArgb(48, 48, 48),
                    Color.FromArgb(49, 49, 49),
                    Color.FromArgb(50, 50, 50)
                };
                    Draw.InnerGlowRounded(G, tabRect, 4, cHighlight);
                    // Fill HighLight Inner

                    G.SmoothingMode = SmoothingMode.HighQuality;
                    //Dim p() As Point = {New Point(ItemSize.Height - 3, GetTabRect(i).Location.Y + 20), New Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 14), New Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 27)}
                    //G.FillPolygon(Brushes.White, p)

                    if (ImageList != null)
                    {
                        try
                        {

                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(x2.Location.X + 8, x2.Location.Y + 6));
                                G.DrawString("      " + TabPages[i].Text.ToUpper(), new Font(Font.FontFamily, Font.Size, FontStyle.Regular), Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                G.DrawString(TabPages[i].Text, FF, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            G.DrawString(TabPages[i].Text, FF, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else
                    {
                        G.DrawString(TabPages[i].Text, FF, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }

                    G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Location.X - 1, x2.Location.Y - 1), new Point(x2.Location.X, x2.Location.Y));
                    G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Location.X - 1, x2.Bottom - 1), new Point(x2.Location.X, x2.Bottom));
                }
                else
                {
                    Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height + 1));
                    //G.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), x2) 'Tab Highlight
                    G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Right, x2.Top), new Point(x2.Right, x2.Bottom));
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(x2.Location.X + 8, x2.Location.Y + 6));
                                G.DrawString("      " + TabPages[i].Text, Font, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                                {
                                    LineAlignment = StringAlignment.Near,
                                    Alignment = StringAlignment.Near
                                });
                            }
                            else
                            {
                                G.DrawString(TabPages[i].Text, FF, new SolidBrush(Color.FromArgb(210, 220, 230)), new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            G.DrawString(TabPages[i].Text, FF, new SolidBrush(Color.FromArgb(210, 220, 230)), new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else
                    {
                        G.DrawString(TabPages[i].Text, FF, new SolidBrush(Color.FromArgb(210, 220, 230)), new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                }
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), new Rectangle(86, -1, Width - 86, Height + 1));
                //Page Fill Full

                Color[] c = new Color[] {
                Color.FromArgb(20, 20, 20),
                Color.FromArgb(40, 40, 40),
                Color.FromArgb(45, 45, 45),
                Color.FromArgb(46, 46, 46),
                Color.FromArgb(47, 47, 47),
                Color.FromArgb(48, 48, 48),
                Color.FromArgb(49, 49, 49),
                Color.FromArgb(50, 50, 50)
            };
                Draw.InnerGlowRounded(G, new Rectangle(86, 0, Width - 87, Height - 1), 3, c);
                // Fill Page
            }

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(50, 50, 50))), new Rectangle(0, 0, ItemSize.Height + 4, Height - 1));
            //Full Tab Outer Outline
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), new Rectangle(1, 0, ItemSize.Height + 3, Height - 2));
            //Full Tab Inner Outline

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}


