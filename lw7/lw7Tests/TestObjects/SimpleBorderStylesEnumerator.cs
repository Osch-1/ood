using System;
using System.Collections.Generic;
using lw7.Styles;
using lw7;

namespace lw7Tests.TestObjects
{
    public class SimpleBorderStylesEnumerator : IStylesEnumerator<IBorderStyle>
    {
        public List<IBorderStyle> BorderStyles { get; set; }

        public SimpleBorderStylesEnumerator()
        {
            BorderStyle firstBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle secondBorderStyle = new()
            {
                BorderHeight = 0,
                Color = new RGBAColor( 133, 22, 512, 0.7 )
            };

            BorderStyle thirdBorderStyle = new()
            {
                BorderHeight = 17,
                Color = new RGBAColor( 0, 29, 217, 0.7 )
            };

            thirdBorderStyle.Disable();

            BorderStyles = new()
            {
                firstBorderStyle,
                secondBorderStyle,
                thirdBorderStyle
            };
        }

        public void Enumerate( Action<IBorderStyle> action )
        {
            foreach ( var style in BorderStyles )
            {
                action( style );
            }
        }

        public static SimpleBorderStylesEnumerator WithEachEnabled()
        {
            BorderStyle firstBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle secondBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 133, 22, 512, 0.7 )
            };

            BorderStyle thirdBorderStyle = new()
            {
                BorderHeight = 17,
                Color = new RGBAColor( 0, 29, 217, 0.7 )
            };

            SimpleBorderStylesEnumerator enumerator = new();
            enumerator.BorderStyles = new()
            {
                firstBorderStyle,
                secondBorderStyle,
                thirdBorderStyle
            };

            return enumerator;
        }

        public static SimpleBorderStylesEnumerator WithEachDisabled()
        {
            BorderStyle firstBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle secondBorderStyle = new()
            {
                BorderHeight = 0,
                Color = new RGBAColor( 133, 22, 512, 0.7 )
            };

            BorderStyle thirdBorderStyle = new()
            {
                BorderHeight = 17,
                Color = new RGBAColor( 0, 29, 217, 0.7 )
            };

            firstBorderStyle.Disable();
            secondBorderStyle.Disable();
            thirdBorderStyle.Disable();

            SimpleBorderStylesEnumerator enumerator = new();
            enumerator.BorderStyles = new()
            {
                firstBorderStyle,
                secondBorderStyle,
                thirdBorderStyle
            };

            return enumerator;
        }

        public static SimpleBorderStylesEnumerator WithOneOfThreeDisabled()
        {
            BorderStyle firstBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle secondBorderStyle = new()
            {
                BorderHeight = 0,
                Color = new RGBAColor( 133, 22, 512, 0.7 )
            };

            BorderStyle thirdBorderStyle = new()
            {
                BorderHeight = 17,
                Color = new RGBAColor( 0, 29, 217, 0.7 )
            };

            firstBorderStyle.Disable();

            SimpleBorderStylesEnumerator enumerator = new();
            enumerator.BorderStyles = new()
            {
                firstBorderStyle,
                secondBorderStyle,
                thirdBorderStyle
            };

            return enumerator;
        }

        public static SimpleBorderStylesEnumerator WithSameBorderHeight()
        {
            BorderStyle firstBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle secondBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 133, 22, 512, 0.7 )
            };

            BorderStyle thirdBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 0, 29, 217, 0.7 )
            };

            SimpleBorderStylesEnumerator enumerator = new();
            enumerator.BorderStyles = new()
            {
                firstBorderStyle,
                secondBorderStyle,
                thirdBorderStyle
            };

            return enumerator;
        }

        public static SimpleBorderStylesEnumerator WithDifferentBorderHeight()
        {
            BorderStyle firstBorderStyle = new()
            {
                BorderHeight = 1,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle secondBorderStyle = new()
            {
                BorderHeight = 22,
                Color = new RGBAColor( 133, 22, 512, 0.7 )
            };

            BorderStyle thirdBorderStyle = new()
            {
                BorderHeight = 10,
                Color = new RGBAColor( 0, 29, 217, 0.7 )
            };

            SimpleBorderStylesEnumerator enumerator = new();
            enumerator.BorderStyles = new()
            {
                firstBorderStyle,
                secondBorderStyle,
                thirdBorderStyle
            };

            return enumerator;
        }

        public static SimpleBorderStylesEnumerator WithSameColor()
        {
            BorderStyle firstBorderStyle = new()
            {
                BorderHeight = 17,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle secondBorderStyle = new()
            {
                BorderHeight = 12,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle thirdBorderStyle = new()
            {
                BorderHeight = 13,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            SimpleBorderStylesEnumerator enumerator = new();
            enumerator.BorderStyles = new()
            {
                firstBorderStyle,
                secondBorderStyle,
                thirdBorderStyle
            };

            return enumerator;
        }

        public static SimpleBorderStylesEnumerator WithDifferentColors()
        {
            BorderStyle firstBorderStyle = new()
            {
                BorderHeight = 17,
                Color = new RGBAColor( 255, 255, 255, 0.5 )
            };

            BorderStyle secondBorderStyle = new()
            {
                BorderHeight = 12,
                Color = new RGBAColor( 127, 313, 12, 0.5 )
            };

            BorderStyle thirdBorderStyle = new()
            {
                BorderHeight = 13,
                Color = new RGBAColor( 229, 69, 2, 0.9 )
            };

            SimpleBorderStylesEnumerator enumerator = new();
            enumerator.BorderStyles = new()
            {
                firstBorderStyle,
                secondBorderStyle,
                thirdBorderStyle
            };

            return enumerator;
        }
    }
}
