// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button2.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Skype
{
    public class SkypeButton2 : ThemeControl154
    {
        
        protected void DrawTextNew(Brush b1, string text)
        {
            if (text.Length == 0)
                return;

            Size DrawTextSize = Measure(text);
            Point DrawTextPoint = new Point(Width / 2 - DrawTextSize.Width / 2, Height / 2 - DrawTextSize.Height / 2);


            G.DrawString(text, new Font("Arial", 10, FontStyle.Bold), b1, DrawTextPoint.X, DrawTextPoint.Y);

        }
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
        public SkypeButton2()
        {
            LockHeight = 25;
            Font = new Font("Arial", 10, FontStyle.Bold);
        }
        protected override void ColorHook()
        {
        }
        public enum ImgState
        {
            Text = 1,
            Image = 2
        }
        private ImgState _ImgState = ImgState.Text;
        public ImgState ImageState
        {
            get { return _ImgState; }
            set
            {
                _ImgState = value;
                Invalidate();
            }
        }
        protected override void PaintHook()
        {
            Image Normal_Left = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAsAAAAZCAIAAABo0EPhAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAASpJREFUOE99kz1vglAYhW///87kRBgIEcKALCwSB1gkfARDQpAmaEVtaWkLJTSBHoqJoFyf9T68ufecl6e2bckddV1//FOWJYExpKqq7XZr23aWZfCaphkZp9OpP/sdcDWOxyOOi6L4GXMx0jS1LOt7is7AN4Zh5Hn+NUVneJ632+0+KRC8Z7lcYgANEkVRHMePjNVqhUf2+UxCFosFAninQ2RZhvEAIknS20M643w+v9IhiqIgDEg0iGmavu/jOTTIfr+fz+eojQbBEqiqutlsUN4kXS9YGZ7nkyR5maIzMAbJiqII6Z7LfqAXXdcFQcC85zHXHYOEklmWXa/XQ2e0p5Bc10WGs9kMKQRBgNpvdx13OhwOjuNomsZxHMMwt0b/Z8BDl7h1GIZ/ySbf47asV7IAAAAASUVORK5CYII=");
            Image Normal_Right = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAsAAAAZCAIAAABo0EPhAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAS9JREFUOE99kj1vglAUhk8XBqb+eicm40CIEAZhcYEw4KKIBmJCgCZA+WptbSslNsGeWxoDgeuz3JDzcD/Oex4sy2JZ9vEPhmFgSNM0l8vleDxut9sgCOq6vvaBnw6tVxRF14HvPufzGaU8z28SfI2x2WyyLGsl+BzjdDqZpom7E+ODQhzH+/2eGKjT0DStqqp7RhiGvu/DOx18tmEY8EYH26MoCuByB1mW4fUukiTBC52yLImBCw1syWKxALwwDcdxVqsVYEg05vN5kiSACY3iuq6qqjg68DxGFEU8z+NAkVzwY4goithN3IAYT33wP0EQdF3HOP/noyus1+vpdIqR3spkDwzwcDjgqziOw/7sdrtumRiTyWQ2my2XS9u20zRtz+5Nsud5eFMMb1hrvV/5S9RzkFpijAAAAABJRU5ErkJggg==");
            Image Normal_BG = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAADYAAAAZCAIAAAD13UppAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAIpJREFUWEfl0T0KwkAUReETZv9NClc1GxCLCIJEY340goVM9DnltHnCFb8FHC7cKsbIaiEEa6SUVpfKwKf88rBkHqWyYVme8njI4y6PWR43eVzl/cLESR6jPAZ59PK4yKOTx1keJ3m08jjK4yCPvby/mdhk3/jDstQeNplHqWxYlq2HXeZRKhuWfQNxD9FuOCD9GwAAAABJRU5ErkJggg==");

            Image Hover_Left = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAsAAAAZCAIAAABo0EPhAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAS9JREFUOE99kzuLg1AQRu/+/97GSrAQBLEwNjYRES0kqCnFNBp8Iivrxse6uJ9rdpP4OuWd4525M+PbMAxkQdd177/cbjcC45mmaS6Xi23baZoi3Pf9i4FTxLIsQ+D7j4eRJMnpdJq+e+ZuxHFsWVbbtl8LRqOua8MwqqpCgUtG43w+h2G4GsYhQeLj8YgnIMUqxPd9PG8rjHOiaVqe53vG4XBAjXuGKIo74TGLIAgodofRmCa0BZEkCc343IaYpuk4zp5xvV55ni/LEi9ahaCvsiyj8ZsG5oKechyH8X6sMU4O16CzyFUUBdLNuO8HTlVVxU0oa9rQfx47BglDZhgGq4RJrRhIB8l1XfSQpmld1z3PQ3HzXUdNURShQ4qisCxLUdTcmP4MeKg6CAJc8wOLkfGPTRlxyQAAAABJRU5ErkJggg==");
            Image Hover_Right = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAsAAAAZCAIAAABo0EPhAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAATFJREFUOE99kjuLg0AURmcbu8D+dlsrwUIQxMKkSaOEYAoJPioRbaL4CkHZrEl2XdzPTSJm1Tnl3DN37mPeTNNcLBbvfzAMQ8a0bVvXdZ7nlmWFYXi9XnEyhPw8aZqmKAp4sF8MBIYg336/z7Ksl8j3iNvthuLSNL1L5GuK8/lsGMblcpk1cCuKItd1OwM5J0FTmqahrFkD19B8EAQ043g8bjYbmoF6l8slzcBDiqIQ1EJBlmWaUZZlZ3zOg5GoqkozbNve7XYEBU9SVZUkSXEczxoY+Wq1wvjJxxRYrCiKmGm3F2T7x+l0Qn5MEwk6Ay0NwcO4res6rj3+Rx/GFvBxeJ7HSvvwI4fv+9vtluM4zMdxnGG4M1iWFQRhvV6j+yRJ7m+//GTP8w6HA6obx+7eL3XU5i5sD4RGAAAAAElFTkSuQmCC");
            Image Hover_BG = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAADYAAAAZCAIAAAD13UppAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAIxJREFUWEft0TsKgDAQBNCR3L+x8FS5gHgBS8UoRA1+Yr9uQGEivnoYJpvCWgsdY8wRDCHo4gmpm+ZNbY3U8YSg3HxehRyuFzDDQg8zvRwmenqgX+j/iU/8UQ5XnOiBfuGEkV4OEx090C90GOihp4eO3rcmttEbR5ebUapVkTqeEJSbUas1kTqeEJSbdz1AWt41xKtlAAAAAElFTkSuQmCC");

            Image Click_Left = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAsAAAAZCAIAAABo0EPhAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAZFJREFUOE+FkymvwlAQRu/7sYgGj0I0ILAIMBVNUYQg2ASQsJMQ9n1fnigCiUTC6RsCpYj3uWbOLHfm68/9fldfOp/Pg8Fgv99fr1cF4ZZt25qmBQIBv9+fTCZrtdoHUSwWg8GgYRjlcrlerzebzXa7/SZKpZKu69lslhiBTqfT6/Xo9SQIh0IhUskj1u/3R6PRdDqdz+cOwVzhcDifz5NK3ng8JrBarTabzXa7dQifz5dIJAiTOplMlsslMR5yOByOx6OiQCQSoTfZlCV1t9sRO51Ov39SjBaNRrvdLtkSJs8tFYvFqtXqcDhcLBZ0lWy3FAUgKLBer+ntCfOp4vE4BMNLAep7a7BBCOaH8Ewgn8o0TSHkCd+QsizrHyKdTr+6UONbih1nMpnZbCZ7lFW6pW63WyqV4lq8llEEcsu5CzVwBiuXU8G55RCUAcJOrBVIBCp6+uNyueRyuVarxUBch44vvT0GVCgUcBDeYT0v7sOnQJitUqkwOBynAPV6nZmARI1GA9RLyJ8Bh7M4OMZ7AMVcm8qafdstAAAAAElFTkSuQmCC");
            Image Click_Right = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAsAAAAZCAIAAABo0EPhAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAZtJREFUOE+FkjmOwkAQRXuOwAFIuQFHIkDkRAQIAlICSAgQRMgiYAsAiR0JYbOYfWcCCDgC4czz1MgyZqT5mf1f/66uqo9wOOzxeHw+n9/v93q96l2dTqdQKIRCIdBgMHi73b5epYbDYb/f73a7zWYzk8lEIpF6ve5k1GQy0XV9NBqBwpXL5Wg02mg0bEitVqvFYjGbzQzDgCOPsFgsZkPqcDjs9/vtdgs6n8/JI6xarcbj8fv9TpK6XC7n8/l0OsFtNhvTNAkDyufzgUDAIj5/dL1e4Y7HI2FcShI1JRIJYqwMpwQiaTweJ5NJClecdookKluv19PptN1up1IpNwFNTbvdjhgIYtyEFE4MT4NIp9PuOqQmCN4FQZf/IORRQmSz2X+IXC6nOPEu+5ZisegmeIj0d7lclkol5qDkl1MUwWuZoqZpz+dT8e2UDJLGsyVkWHPhlwhDRENZPGwCLIJAW0yE6weDQaVSeTweskS/BB4NYI/YoFqtZtsWgUGD8Sit1WqxWk7bIjB6vR6GSO5+2WTWiTGyKe+ecN8ZWpFliPhZJgAAAABJRU5ErkJggg==");
            Image Click_BG = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAADYAAAAZCAIAAAD13UppAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAN9JREFUWEfdl70SgjAQhDcFL8wDamG0ERt1HBV/HiRFZJIUVJcNE+T0q26G3eUOwsxh2rYFgfe+aZpB6JwzxhAOVpJPXqkHWw5r7SYwFJyDVWWTceDoum4fGArOwaqyyTgTnALHQKwJEyVhknGjuQZoeYFQTsaT4zGCc7CqbDLeIi8R2VsrGXEIuZVlr6YXvWwT8t3Zs5g9WfMNWa3F7AyTBeksTvZ/wZhaHH/52upfaLFXD9R32OOunoI1omAvqCpF3DI0g4t6/qvFuEbP8dDlZOzUgzVN/AOk5QVCOfkDog29Jih87R0AAAAASUVORK5CYII=");

            //G.Clear(Color.Fuchsia);

            G.Clear(BackColor);

            if (State == MouseState.Down)
            {
                for (int i = 0; i <= RoundUp(Width / 54); i++)
                {
                    G.DrawImage(Click_BG, i * 54, 0);
                }
                G.DrawImage(Click_Left, 0, 0, 11, 25);
                G.DrawImage(Click_Right, Width - 11, 0, 11, 25);
            }
            else if (State == MouseState.None)
            {
                for (int i = 0; i <= RoundUp(Width / 54); i++)
                {
                    G.DrawImage(Normal_BG, i * 54, 0);
                }
                G.DrawImage(Normal_Left, 0, 0, 11, 25);
                G.DrawImage(Normal_Right, Width - 11, 0, 11, 25);
            }
            else if (State == MouseState.Over)
            {
                for (int i = 0; i <= RoundUp(Width / 54); i++)
                {
                    G.DrawImage(Hover_BG, i * 54, 0);
                }
                G.DrawImage(Hover_Left, 0, 0, 11, 25);
                G.DrawImage(Hover_Right, Width - 11, 0, 11, 25);
            }

            if (_ImgState == (ImgState.Image))
            {
                try
                {
                    G.DrawImage(Image, 13, 4, 16, 16);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                DrawTextNew(new SolidBrush(Color.FromArgb(51, 51, 51)), Text);
            }
        }
    }

}

