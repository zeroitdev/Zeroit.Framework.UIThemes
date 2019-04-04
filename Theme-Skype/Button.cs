// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Skype
{
    public class SkypeButton : ThemeControl154
    {
        public int RoundUp(double d)
        {
            if (d.ToString().Contains(","))
            {
                return Convert.ToInt32(d.ToString().Split(Convert.ToChar((",")), ((char)0))) + 1;
            }
            else
            {
                return Convert.ToInt32(d);
            }
        }
        private Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
        }
        Image Side_Left;
        Image Side_Right;
        Image Side_Left_Hover;
        Image Side_Right_Hover;
        Image Side_Left_Click;
        Image Side_Right_Click;
        Image ClickBG;

        public SkypeButton()
        {
            LockHeight = 32;
        }
        private int _Text_Margin_Left = 0;
        public int Text_Margin_Left
        {
            get { return _Text_Margin_Left; }
            set
            {
                _Text_Margin_Left = value;
                Invalidate();
            }
        }
        private Image _Image = null;
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                Invalidate();
            }
        }
        protected override void ColorHook()
        {
        }
        public enum AllignMode
        {
            Left = 1,
            Right = 2
        }
        private AllignMode _AllignModes = AllignMode.Left;
        public AllignMode ImageAllignmentMode
        {

            get { return _AllignModes; }
            set
            {
                _AllignModes = value;
                Invalidate();
            }
        }
        protected override void PaintHook()
        {
            Side_Left = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAgCAIAAAC6rk4JAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAANVJREFUKFNVx81LwgAAhvG3PzqKltmnmnrw0tVD05xpERTkqUMEdQgKOr2VOvOj/GIjcOg8WFu94H6n51kpPi78qfftDOfzGfJ3k+w5y7ftvjtF7tL+Ld/3XddF5oy98WQUQrpKx3GGIRxW+VfBpCocSDB9QbLCL0HiNDqfgoMyexKdfYtdwZ7FjmDXYluis2PxQ7BdYkuCsQXxk+g0BVtFNgSx5dkssC4wCnyXYN4EhslXwYbJh+f/w2r+5eiqzhBSNW/dZO6C909E9maRvPaMkr12zB/HeDzVgnCjBwAAAABJRU5ErkJggg==");
            Side_Right = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAgCAIAAAC6rk4JAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAANVJREFUKFNdyT1PwgAQxvFjQIyDiQMflZBYFXkRUIlxce0AKO9dMMHJgZA4OrBwKlLEAoUm7QAN6YLXJk+C/JbL/7lQQeNwOHJ8Ej04PCLT2dS6E5nU3pocx/E8T/q+rZMVMKzVbYtpGbBt+6aJkL6WWEC+wWSCH3PI7Ua2zjQDP6ZwVdsLAzJVpl9IS0wgtR8/kJTPGC4rTDr8i8QT0wj8+IaLx504lxjCWZnpCxSJT/DjA5QS4u2dTyU48PA8jKl9ku1OG8SLnH9xSY5S0XMdt/C6/QOl4zQlUbpikwAAAABJRU5ErkJggg==");
            Side_Left_Hover = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAgCAIAAAC6rk4JAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAANdJREFUKFNdxzFPwmAYReHLT3WQAKKoKGwMstlqpTjg4GhcJAS2NyEkDsTFwYqLgAKCoAJplUZIF/AruUN9pnNCV/dL15kMe83F3EWhOk6fy03Vcn/nyFzW/8rzPMdxkMrL989s4sOhKbZtj31q1qXmwJQvUvNJSJryQdjPBWdE2DuTIQVn15B3QsKQAanpU3B2DHkjbJ9Kj9R0CfGT4HQIW7q8EmL/5oUQ1aVNalqEqCZNQkQT6/FpvdjIli6Kd88+ZCvTsCbm9e2D1YBeWx6Vp/F8ffNYVpzZMpYYLrVaAAAAAElFTkSuQmCC");
            Side_Right_Hover = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAgCAIAAAC6rk4JAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAANVJREFUKFNlyrtvgXEUxvFjaxODwWTp1v/LIHGr1n0zsLm0WgYdbEYibL9EmMRKTG5t0dK65H2JkLwL5/cmT4J+lpPvk2MIZ8XNrdFyd280mWm3PxRrHZ5ytSWpqqppGnck36SVTt1sQxlBS52iKME3BLeMBQQ4/kDGL/jPw/cqaA4yZuBNX8UPPL0I+oZHjin8iwl4+G0MD8+CvuAi3ClBnyDjA1zJs3ByjEDGEBwcA5DRB0cC0e507Rw93XupZY2Vibd0oWGLi1h1TXzcmWa0sk7WjydC2yozBDZ0HwAAAABJRU5ErkJggg==");
            Side_Left_Click = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAgCAIAAAC6rk4JAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAXtJREFUKFM90esvQmEcwPGf9/4O1iaq07nk9NLmvyFSnXJKF5dcy/2Su3ljXrhf4o2NjWHT6foYW4pTmAjltuE52rz8vP1+i+ZPfj7f88Xf91+fHzC1n5vfQQ6fn+XWYWEvbvf5S3S7pfo9mPMjrXlbxh3JnecSZMZDuetS6clKKOMFhVtU977BrB/JbTGl+1bCzD+8eZjeRuW2mMp9S2JMYVijqrY06cnB5BYq56Oq1jTZ84cKPkK0pKjuV5jYRBWNEaI5RXX9QWEJq10i3fkC4xtIYQ6rnSLd8QI+DC4kof0ZxtaR0hQiHSLjLsAYIu0i0/YMo2tIZQhSTTea1iyMYDQEKduNpiULwxh6gbJea5qfJBB6geavK10F1At0Y7LS+QhDq4ioExhLknU8wiCGLsCYE6w9AwMriKgNMFyCbcpA/wpS15wxpiut7QH6lguIs/ydhCrulDZcaLgkdC8GjcMHtP4cWwrfu4RMo8fV1ijgJdgDG3HvEvoFGSnkfAH6/cgAAAAASUVORK5CYII=");
            Side_Right_Click = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAgCAIAAAC6rk4JAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAXtJREFUKFNjXLbnJisb+xcmUTYOLgbriq0Ns3Yu3X1z/pGvDOrFB9UK9tTP2rXq4AMG3aZbmhUnbSp3Lt51k8Gw/6Nu813NshMgjsnE7wYdz3RqLkE5hh0vdetuLALJTPgG4SwEckz7vxm1v9SrvbFgJ5DT99Wo7YVezfX5QI5Z31fjthf6Ndfn7QByer8Ytz7Xr7kG5vR8MW55rl99be72mwzm3Z9Nmp8ZVF0Fc7o+mzQ9M6i8OmcbkNP5CcSpuDIbyLHo+GTa+Myw/MqsrUBO+0fThqeGZZdBHMu2j2b1T41KL8/cAuS0fjSre2pUcnkGiNPywaz2iVHxpelAjlXzB/OaJ8ZQTtN78+rHxkVgGevG9xZVj40LL03bDOQ0vLOofGRccHEqiFP/zqLikXH+xSmbbjLY1L21KH9okndhMpBjXfPKovwBkDNpI9CeisfmpXdcys+COECWefGtsulHe9dcZnCvvV4+8xQ04CdsuDll2wNgFCw98x8ArkjdwxRv+JQAAAAASUVORK5CYII=");
            ClickBG = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAD8AAAAgCAIAAAAqvTfGAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAL1JREFUWEfVzikOwlAARdHHYkiQCNr+tp8toUjqSJhn6AAsAY1EsAGW0KDQBEXngSAxJNi+m7OAWztefPBW75x5oWFdeaG5evBC6/DmBWVf8oKyK3lB8QpeUL3iyy1UKlDd/DcnVysPfxc1J68saHbGC9o24wWxSXlBrFNeEKuEF/Rlwgv6IuYFYx7zgjGLecGYRrxgTiJeMMchL8hRyAtyGPCCHAS80O6/eJHfy96TF4R15wWte+MF++Tz+gAX4QMt3+M70AAAAABJRU5ErkJggg==");

            G.Clear(Color.Fuchsia);
            G.SmoothingMode = SmoothingMode.HighSpeed;

            if (State == MouseState.Down)
            {
                for (int i = 0; i <= RoundUp(Width / 63); i++)
                {
                    G.DrawImage(ClickBG, i * 63, 0);
                }
                G.DrawImage(Side_Left_Click, 0, 0, 4, 32);
                G.DrawImage(Side_Right_Click, Width - 4, 0, 4, 32);
                G.DrawString(Text, new Font("Arial", 10, FontStyle.Bold), Brushes.White, 5 + _Text_Margin_Left, 8);
            }
            else if (State == MouseState.None)
            {
                DrawGradient(Color.FromArgb(140, 174, 217), Color.FromArgb(119, 162, 217), ClientRectangle);
                DrawGradient(Color.FromArgb(237, 237, 237), Color.FromArgb(217, 217, 217), new Rectangle(1, 2, Width - 2, Height - 3));
                G.DrawLine(Pens.White, 1, 1, Width, 1);
                G.DrawImage(Side_Left, 0, 0, 4, 32);
                G.DrawImage(Side_Right, Width - 4, 0, 4, 32);
                G.DrawString(Text, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(51, 51, 51)), 5 + _Text_Margin_Left, 8);
            }
            else if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(119, 148, 185), Color.FromArgb(101, 138, 185), ClientRectangle);
                DrawGradient(Color.FromArgb(237, 237, 237), Color.FromArgb(217, 217, 217), new Rectangle(1, 2, Width - 2, Height - 3));
                G.DrawLine(Pens.White, 1, 1, Width, 1);
                G.DrawImage(Side_Left_Hover, 0, 0, 4, 32);
                G.DrawImage(Side_Right_Hover, Width - 4, 0, 4, 32);
                G.DrawString(Text, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(51, 51, 51)), 5 + _Text_Margin_Left, 8);
            }
            try
            {
                if (_AllignModes == AllignMode.Left)
                {
                    G.DrawImage(_Image, 8, 8, 16, 16);
                }
                else
                {
                    G.DrawImage(_Image, Width - 24, 8, 16, 16);
                }

            }
            catch (Exception ex)
            {
            }
        }
    }

}

