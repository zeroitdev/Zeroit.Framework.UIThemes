// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="StarRating.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region  Imports

using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    using System.ComponentModel;
	
#endregion
	
	

namespace Zeroit.Framework.UIThemes.PlayUI
{
    #region  Star Rating

    public class PlayUIStarRating : UserControl
    {

        #region  Variables

        private Size _ImageSize;
        private Image _ImageRated;
        private Image _ImageUnrated;
        private int _Stars = 0;
        private int _MaximumStars = 5;
        private int TempStar = -1;

        #endregion
        #region  Properties

        protected Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
        }

        public int Stars
        {
            get
            {
                return this._Stars;
            }
            set
            {
                if (value > _MaximumStars)
                {
                    MessageBox.Show("Value can\'t be higher than the maximum number of stars!");
                }
                this._Stars = value;
                this.Invalidate();
            }
        }

        public int MaximumStars
        {
            get
            {
                return this._MaximumStars;
            }
            set
            {
                this._MaximumStars = value;
            }
        }

        public Image ImageRated
        {
            get
            {
                return _ImageRated;
            }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }
                _ImageRated = value;
                Invalidate();
            }
        }

        public Image ImageUnrated
        {
            get
            {
                return _ImageUnrated;
            }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }
                _ImageUnrated = value;
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            double StarLoc = (e.X + _ImageRated.Width - 5) / _ImageRated.Width;
            int HoverStar = Convert.ToInt32(Math.Floor(StarLoc));

            if (!HoverStar.Equals(TempStar))
            {
                TempStar = HoverStar;
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            TempStar = -1;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            double StarLoc = (e.X + _ImageRated.Width - 5) / _ImageRated.Width;
            int StarToAdd = Convert.ToInt32(Math.Floor(StarLoc));

            if (!StarToAdd.Equals(_Stars))
            {
                _Stars = StarToAdd;
                if (_Stars > _MaximumStars)
                {
                    _Stars = _MaximumStars;
                }
                this.Invalidate();
            }
        }

        #endregion

        public PlayUIStarRating()
        {
            Size = new Size(82, 17);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            if (_ImageRated == null || _ImageUnrated == null)
            {
                return;
            }

            for (int i = 0; i <= _MaximumStars - 1; i++)
            {
                if (i < (TempStar == -1 ? _Stars : TempStar))
                {
                    G.DrawImage(_ImageRated, _ImageRated.Width * i, 0, ImageSize.Width, ImageSize.Height);
                }
                else
                {
                    G.DrawImage(_ImageUnrated, _ImageRated.Width * i, 0, ImageSize.Width, ImageSize.Height);
                }
            }
        }
    }

    #endregion
}