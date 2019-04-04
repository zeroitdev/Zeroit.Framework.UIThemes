// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SkyLimit
{

    public class SkyDarkRadio : Control
    {

        public enum MouseState
        {
            None,
            Down
        }

        #region "Properties"

        private MouseState ms;
        public MouseState State
        {
            get { return ms; }
            set
            {
                ms = value;
                Invalidate();
            }
        }

        private bool chk;
        public bool Checked
        {
            get { return chk; }
            set
            {
                chk = value;
                Invalidate();
                //'Error code: Whenever I add this it overflows like an infinite loop...
                try
                {
                    if (value)
                    {
                        foreach (SkyDarkRadio ctl_loopVariable in Parent.Controls)
                        {
                            SkyDarkRadio ctl = ctl_loopVariable;
                            if (ctl is SkyDarkRadio)
                            {
                                if ((!object.ReferenceEquals(ctl, this)) & ((SkyDarkRadio)ctl).Enabled)
                                {
                                    ((SkyDarkRadio)ctl).Checked = false;
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        #endregion

        public SkyDarkRadio()
        {
            Size = new Size(Width, 13);
        }

        Color C1 = Color.FromArgb(35, 35, 35);
        Color C2 = Color.Transparent;
        Color C3 = Color.Transparent;
        Color C4 = Color.Transparent;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(Parent.BackColor);

            switch (Enabled)
            {
                case true:
                    switch (State)
                    {
                        case MouseState.None:
                            C2 = Color.FromArgb(70, 70, 70);
                            C3 = Color.FromArgb(54, 54, 51);
                            C4 = Color.FromArgb(152, 182, 192);
                            break;
                        case MouseState.Down:
                            C2 = Color.FromArgb(54, 54, 51);
                            C3 = Color.FromArgb(70, 70, 70);
                            C4 = Color.FromArgb(112, 142, 152);
                            break;
                    }
                    break;
                case false:
                    C2 = Color.FromArgb(70, 70, 70);
                    C3 = Color.FromArgb(54, 54, 51);
                    C4 = Color.FromArgb(89, 88, 88);
                    break;
            }
            
            Rectangle radRec = new Rectangle(0, 0, Height - 1, Height - 1);
            LinearGradientBrush B1 = new LinearGradientBrush(new Point(radRec.X + radRec.Width / 2, radRec.Y), new Point(radRec.X + radRec.Width / 2, radRec.Y + radRec.Height), C2, C3);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillEllipse(B1, radRec);
            G.DrawEllipse(new Pen(ConversionFunctions.ToBrush(C1)), radRec);
            if (Checked)
                G.FillEllipse(ConversionFunctions.ToBrush(C4), new Rectangle(radRec.X + radRec.Width / 4, radRec.Y + radRec.Height / 4, radRec.Width / 2, radRec.Height / 2));
            G.DrawString(Text, Font, ConversionFunctions.ToBrush(C4), new Rectangle(radRec.X + radRec.Width + 5, 0, Width - radRec.X - radRec.Width - 5, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });


            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (Enabled)
            {
                State = MouseState.None;
                if (!Checked)
                {
                    Checked = true;
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!Enabled)
                State = MouseState.Down;
        }
    }

}