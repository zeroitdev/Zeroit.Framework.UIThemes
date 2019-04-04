// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Skype
{
    [DefaultEvent("CheckedChanged")]
    public class SkypeCheckbox : ThemeControl154
    {
        private Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
        }
        public SkypeCheckbox()
        {
            LockHeight = 14;
            LockWidth = 14;
        }


        protected override void ColorHook()
        {
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void PaintHook()
        {
            Image ImgChecked = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAIAAACQKrqGAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAASlJREFUKFNj+E8I8DatVVNTkwpKYwCqZFhwm2HqGayIqfegop6xop4RSBlQXen+239wgOzsbAUFBZ6CqWClU8/8/v37MTawZMkSGRmZ6OhooBqo0p8/fz7EAJcvX9bW1lZUVLx//z5C6bdv33bv3i0lJeXh4XH37l2gHBDExsYKCwt3d3cDZRFKP336dOfOncmTJ/Px8WVkZADZc+fOBbIdHR2BbKAsQum7d+9ugUF6ejoXF1d1dTXQK4KCgnv37gUKAmURSl+9enUDDK5du2ZlZcUGBlVVVRBBoCxC6ZMnT67CwJEjR6SlpfX19YHegogBZRFKgZ4ASsDBypUrN2zYAOeihMDt27cv4gZAWZipC24nrz0JdCUuAJQFxigoCvCnAVDCAKsDAgBvkZJ5r5lP9QAAAABJRU5ErkJggg==");
            Image ImgNoChecked = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAIAAACQKrqGAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAI9JREFUKFONkjEKhDAQRd2z7hk8in0usGewFmyWxUUcQWRTpUiRIhCyEL+iTPXBR7r3CAwzj1JKdZM9NVI1PX1G0Bw/Gqlb+XNg0Rxp0+ecfxxYNGeaUlo5sJrGGBcOrKYhhJkDq6n3fuLAauqcGzmwmlprBw6sphjpw4HVVETeHNgrNfJ8dV8O7Lmt+zewAahirSfxCAkLAAAAAElFTkSuQmCC");

            G.Clear(Color.FromArgb(51, 51, 51));
            if (_Checked)
            {
                G.DrawImage(ImgChecked, 0, 0, 14, 14);
            }
            else
            {
                G.DrawImage(ImgNoChecked, 0, 0, 14, 14);
            }

        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnMouseDown(e);
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

    }

}

