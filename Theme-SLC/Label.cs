// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCLABEL"
    public class SLCLabel : Control
    {
        Label lb = new Label();
        public SLCLabel()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font("Verdana", 8f, FontStyle.Regular);
            Size = new Size(39, 13);


        }

        private string _text = "SLCLabel";
        public override string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Invalidate();
            }
        }


        private PointF PT1;

        private SizeF SZ1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G = e.Graphics;

            G.Clear(Color.White);


            PT1 = new PointF(0, 0);

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);

        }

    }
    #endregion

}

