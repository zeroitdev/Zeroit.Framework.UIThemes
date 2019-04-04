// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CallButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Skype
{
    public class SkypeCallButton : ThemeControl154
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
        public SkypeCallButton()
        {
            LockHeight = 25;
            Font = new Font("Arial", 10, FontStyle.Bold);
        }
        protected override void ColorHook()
        {
        }
        protected override void PaintHook()
        {
            Image Normal_Left = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAABYAAAAZCAIAAAC6gEm5AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAmJJREFUOE+VlE9IYlEYxa/9oQINAhGiVkGbCqpdVtIuopZFERFRULSICiOyIty0qKRVEJROViMkYzDPIorsUShm/58yDDKzSXDhKpBaCG3sPD55mZb2Hj/k3vu+c75zr3oV8XicpT2hlxAX4kDgKRB9jaYXfFiBRfLz+Pw4cD5QaCls5Br7+L4p39Tiw2JmWLLe+s+q2dHonDq9Tw/ZamB17c/a+t91gAGmWJy9nk3h3QL6YmtxL987czWzJCyZ/KYV/8qysIwxwABTLGJsuDaMe8clEhbQK7eUlNx4a1y4XZi/mf8UvDLeGRFz6GKIEC2wf/W2uvWoddQ9CotJ7+SEdyIDKNBf6lHc7eoGokX/WX+lvbLT1TnsHobr4MVgVlA24h6BpP24nSFCnjmvydnUc9YDy67Trm+CYkhaDlqY6d6k2dU0O5s7jjuwF1lAAiHT7mvLbGUNXAMmWk4rC92BDkKmsqhKf5bW7tfWOGqqHdVZqfpVJQEJhIxtsJLtkoq9CmSRS7mtHELRIt+cr95R43chF9WWCkKmNCvhUvSjCEa5m7lZydnMkYAEQlZvq6cg+GoxkAVUgE2fTEOG5gWWAll6xYYCEgiZ77+PlIn5t4MgdaJrLBZr22uDBXaIJXgn81UuFONOwadYgP8I7+fpULExuCRefB2HmomnQDWwQJC5wzmaU7wMR4tX6P+hgG6tSCRicBrIhZpQHykRBpTxk5jSxUcutCP6jkiDnoAcxfNP32Dy3QkXB++g05VByg2OcwkGg3aXfez3WN1unRQqk2OKBU1hFA6HBUHweDzn2Z437xmYkxCYqCUAAAAASUVORK5CYII=");
            Image Normal_Right = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAZCAIAAACKDFiYAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAThJREFUOE9jZJjJIMAmoC+sH6AQAEQKvAoMmKDlXEvx8eLovdFWG6w45nDE74+//+n+f1TAUHmyEo6KjhfZbrQVWyg2/+Z8ZGUMeUfz0FDk3ki++XzI6hiSDiRhIqDtPPN44OoYwnaHYUVuW91EFohA3Mfgtd0LF1JdoRq7JxakyH6TPS5kvdGaZTYL0DAG47XGeJDYIrHus90MGis18CDpJdKWaywZZJfK4kGSiyV55/AyCC4QxI+A8cbAOpsVPwIpAmG8iGc2D2FFhksMCSsq3VFKWNHxW8cJKPJY7vH9+3d8ioBO3nthLyju8HitanMV0Bh8iio2Vjx//hySPrGYBLQFWQUWRUCXrt67Gm4GwiSgVoNFBjnrc1bsXnH9+nWIO1Aywv79+w8fPnz+/PnHjx9jSkOUAgBV+nww3EO/fQAAAABJRU5ErkJggg==");
            Image Normal_BG = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAADYAAAAZCAIAAAD13UppAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAH9JREFUWEdjZJjJMNhBy7mWQY4YKk9WDnLEkHc0b5AjhqQDSYMcMYTtDhvkiMFru9cgRwz2m+wHOWIwXms8yBGDxkqNQY4YZJfKDnLEILhAcJAjBtbZrIMcMYCaEYMcDXb3gRpigzwIR51IpSgajWhqBORoKI6G4mBJA/sHPQAAhnkCIsAEp70AAAAASUVORK5CYII=");

            Image Hover_Left = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAABYAAAAZCAIAAAC6gEm5AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAqNJREFUOE+VlMlLW1EUxq/zhBFUSFwI/gVudOVC3KoIRtCNMWZjjHFlgrpIHBBUUIPiBJmamEcUbCuWUOOAsY1prWNMHaO2yVawIO0q3djvceU2RknM5Uc493LOd753Xt5NeHh4IM9W8E9wObgMfL9893/vnyc8OYFE+Ar8DjRvNWeZs6qd1aqvqjHfmPnSHB0SXm/xWwq4grr1uvHv49ZL68LNwuKPxaWfSwDB/M285dIyezYbwX8J1OfP5Xd965o5neGuOPu1nbvmENiubAABtvzhFTd9Nq3z6RiPEqjPs+b1HfRNnkyaLkyGc4P+XP8ixgsjEpA2eDRI4SXw/MI5oWJbMeobnTqdmjiZiAnSRo5HtHtawEtIN6XlH8q1+1qcDnuHozN0NERBsmZPo95RE1hIN6XLP8t793sBFY4Cyig9+z3Ib/e0E92xrvhtMaLu3W7VjiomHTsdjM7dTqVHScrelVU4KlrdrcptpcKtCAeHLyJ3yylt220t7hYieCOodFbKPsmkLmmTq+lFJJsSRuNmI0Piksi2ZIToSZWzqmGjQbwmjova1Vrxqrh+vZ6XyLXmFs0XiTjRaxDahAyRTVRoLyTZpuxUY2qOJQffRYYpIyZ4fWmmNEqmOVNgEZDShVIYSTGmJBuTEcQFqgDRuDQoSzIkQTWu+gR9AkpQSA6Dh7Tycf9qI3D92DUUCtW8r4FEoiERR9BmRDGFZAwFv3wOvhHPhQdDpRNho0KADEqEFm3GT4FahgSMDGwM0D3sMZhc+CFi9H8ye3pr3d3d9a/1UxXahPZhFhAwj5G+2MVHVegT0XdEa9CT/hew5ef/fN7hdydUVnZX6HTjIOIGx1wCgYDji0P9UV1iL2GmoilGSNAthG5vb/1+v9frPYi1/gEakOtUbEwcoQAAAABJRU5ErkJggg==");
            Image Hover_Right = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAZCAIAAACKDFiYAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAASlJREFUOE9jZJjJIMAmoC+sH6AQAEQKvAoMmGDujbkQZLXBimMOR/z++Puf7v9HBQxTr05FRrYbbcUWis2/OR9ZGUPvxV5MxDefD1kdQ+u5VqyIZx4PXB1DzakaXEhkgQjEfQzFx4txIdUVqrF7YkGKso9k40Ess1mAhjEkHUzCg8QWiXWf7WaI3BuJH1musWQI3BmIH/HO4WXw2OqBHwHjjYF/Pj8Esc5mxYpAiuASIA42xDObB7sEsmrDJYaEFZXuKCWs6Pit4wQUeSz3+P79Oz5FQCfvvbAXFHe4PAUUr9pcBTQGn6KKjRXPnz+HpE8sJgFtQVaBRRHQpav3roabgTAJqNVgkUHO+pwVu1dcv34d4g6UjHDmzJnDhw+fP3/+8ePHmNIQpQAAmaPsN2aELAAAAABJRU5ErkJggg==");
            Image Hover_BG = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAADYAAAAZCAIAAAD13UppAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAIFJREFUWEft1iEKgEAUhOExbPZa1o3WrUar1WjcICKewmAwCIIgIhgEjyPeYcMP7uM7wDBTXqJW9OufHk7+9nBqrgZO9VnDqdorOJVbCadiLeDkFgenfM7hZCcLp2zM4JQOKZxMZ+D0fTpw9HzfrwivMEYMNFEcOkSRscWftHjg7wWoQvM8R5DyyQAAAABJRU5ErkJggg==");

            Image Click_Left = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAABYAAAAZCAIAAAC6gEm5AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAA2VJREFUOE+NlF0sW2EYgN/q2SGcSDYTysiWzFQkZqQhfuIC1ZslbGEL0SiJLK0RpaddWWa6NmwI5meqNTtd43czuvqrvyqziyUuxdV+XLjaLTdL7D07QquGL8/FOd857/O97/ud8/EODg7Aa/zc+Wn/andsObZ/b+/92fPh+Xi/czyDCvfx49cPebs8qioq9Vnq3da7hT2Fsn5ZmbnsDMA9nrExscrY9Mb0hz0P5Ra5clSpmdDUTdXVT9XX2/7LscJit0Qpo3JacmSDssejj1WTqob5huaV5s71zs4vLM3O5oaFBnqGrrZXu3OoYD4zN6pviNvEUkZaPlqunlEbVg36Vb3OpWt0NXLo1nT6Nb1h3UAv0eXT5Uewiu+/vt9U3kxpSskfyC8ZKamdr32y/ES9rKadNL1K0y4P1C61dl1b46wpni0umilCWEVZe5nwqVDcK75vvS+fllc6KisWKxTLCsWKQuFUyJ1ybypXKx+tPMqbycudzgVM4WrV1YSXCdnm7AfjD0pnS6VzUg8WpFJPipeKpUtS2YqswFEgtouhbaQtXBue2JGYMZhRMFVw7/M9dJ9N7lwukjefl+/IT59Mh4zGjIjnEXFdcWnv0yQTkqzJrCzbOWTaMjly7Dkpn1IguDY4zBB2q/tWsjU5aSxJNC4SfTiPjyLRP5InkpMmkoCsIYObgq91X7ttvR0zFCMcFp5kRCj0JHo4miNmJCZuLA4IFUEZqMuvL18fvC54JxAwXlgEAk9CmdAQJgTBi0hrJATWBRJ6gmwng0xBlIkKMAUEmM/B3+zPQQ1QVwavwB39HXgB0AZkL8nv40MfXByinyD7SVANqDgFv5tPGsmLx+ObGM838mHj2wboAFqB18Xz6/fjveFd0OJj9PEz+fH6eLC/vy/pkMArgE4g+ghMBC3u/M/oa/LFQtin+I8suhapFgo6AHoAFZeMl9zxVuDKWALbBa5xqMBEtIwWa4EugF7WgmCep66P87j+cTynwLG7u6uxaKAdoJu1EEYC+4IiTBXXRDCS6z/Wf5j/0d4dHXys5b2G6qI4C7YD9xgtGMPB9Z/t34mNdz870TJmH5O8lbAV9bAieOPJqV/NiRMc+7K1tTVsG64Yqog3x1O9/5I6mxMK7hZFOzs7m5ubLpdr+bzxF18PkwwsoAUxAAAAAElFTkSuQmCC");
            Image Click_Right = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAZCAIAAACKDFiYAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAjlJREFUOE+Fk89P2mAYgN/V6YEAJszEpsmC0qAZh4o36o+DgoTE2MSLCTUxMVAPxNBtBsPYErMNtywOAgr+GIKuqCuijAHdzXDg4GUJR44aOfAncNwK3VgJM/vy3N4nz/cmX/tA69IqHiqGHw3PPJmZNc1qH2uh8yzHluldei4wN74xrmf1rpDr9u72Z/sB3zffemad5dmVzysL0YWJNxOG5wYuz8k1YPMsm2PZLOvOuF0p11JiybplxZ/hSSHZ8oARGKbAMDnGmXU6L50O3rF4vGgJWAaeDnCF3z2gv9O0QNMFms7R9q92e9puP7PPH86b3pvE3s3djdgDSqAa5JtkKeqConiK4qjpyPTQqyFHyNGQrIJVjiVjMafM5qR5KjY18mFE49aIMRjLjskhL0nynCRPSTJOGkNG7AUWTAXBeGGUQ5wTBE8QJwQRJwzbBmwDm3w9CXpeLwc/w/FTXMfpdIe6wZ3Bfn9/31ofYElMDsqhDY5RNIaiO6jmnaZnrQd6j3rlqBPqBnG1el+tCqsUm4ouTxd0x7rlIJ8Q5KBJFEGCCOJHVC9VAAf/Yh8gAhAE8MPo5uj/JU/Cc09GKgUA3sL1j+sOSRyL7AFsA2yBLWyr1+v3SLsAYVB+VF6Vrhpv17Z4K9O8y8f5xIxMksbSRVGAEHiT3lqtJn13zVK7oYwovSd/jabUCoh7RMB2ZEsL6VbjTykKyj2lMW5c/bLK5/lKpSLt0fYjFIvFUqlULper1WrnWFJ/AfiRdaa+FFYwAAAAAElFTkSuQmCC");
            Image Click_BG = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAADYAAAAZCAIAAAD13UppAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAINJREFUWEft1CEOg1AQRdFbgcbjEHg0C0DjkSQYFJ5tVBDSVNRUIEgIINlad4BC3CZ/chbw8mYyj7RLkU/zauQY1kGOfuvlaPdWjvqo5aj2So5yK+UolkKOfM7lyL6ZHMknkSN+x3JEUyQHo16IeMeKQouhRcsNWHJc/L5/iPgEuVM/P1yHAgCiKbOGAAAAAElFTkSuQmCC");
            G.Clear(Color.Fuchsia);

            if (State == MouseState.Down)
            {
                for (int i = 0; i <= RoundUp(Width / 54); i++)
                {
                    G.DrawImage(Click_BG, i * 54, 0);
                }
                G.DrawImage(Click_Left, 0, 0, 22, 25);
                G.DrawImage(Click_Right, Width - 11, 0, 11, 25);
            }
            else if (State == MouseState.None)
            {
                for (int i = 0; i <= RoundUp(Width / 54); i++)
                {
                    G.DrawImage(Normal_BG, i * 54, 0);
                }
                G.DrawImage(Normal_Left, 0, 0, 22, 25);
                G.DrawImage(Normal_Right, Width - 12, 0, 12, 25);
            }
            else if (State == MouseState.Over)
            {
                for (int i = 0; i <= RoundUp(Width / 54); i++)
                {
                    G.DrawImage(Hover_BG, i * 54, 0);
                }
                G.DrawImage(Hover_Left, 0, 0, 22, 25);
                G.DrawImage(Hover_Right, Width - 11, 0, 11, 25);
            }
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.DrawString(Text, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.White), 25, 4);
            try
            {
                G.DrawImage(Image, 7, 7, 12, 12);

            }
            catch (Exception ex)
            {
            }
        }
    }

}

