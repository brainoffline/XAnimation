using System;
using Xamarin.Forms;

namespace XAnimation
{
    public enum ZDirection
    {
        Away,
        Closer,
        Steady
    }

    public enum CircleDirection
    {
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft
    }

    public class CircleInAnimation : AnimationDefinition
    {
        public CircleInAnimation()
        {
            Duration        = 400;
            OpacityFromZero = true;
        }

        public  CircleDirection FromDirection  { get; set; } = CircleDirection.BottomLeft;
        public  ZDirection      FromZDirection { get; set; } = ZDirection.Away;
        public  double          Distance       { get; set; } = 200;
        private double          DistanceX      { get; set; }
        private double          DistanceY      { get; set; }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            if (FromZDirection != ZDirection.Steady)
                animation.WithConcurrent(f => element.Scale = f, FromZDirection == ZDirection.Away ? 0.3 : 2.0, 1, Easings.BackOut);

            animation.WithConcurrent(f => element.Rotation = f, -90, 0, Easing.CubicIn);
            animation.WithConcurrent(f => element.Opacity  = f, 0,   1, null, 0, 0.25);

            switch (FromDirection)
            {
            case CircleDirection.TopLeft:
                DistanceX = Distance * -0.5;
                DistanceY = -Distance;
                break;
            case CircleDirection.TopRight:
                DistanceX = Distance * 0.5;
                DistanceY = -Distance;
                break;
            case CircleDirection.BottomLeft:
                DistanceX = Distance * -0.5;
                DistanceY = Distance;
                break;
            case CircleDirection.BottomRight:
                DistanceX = Distance * 0.5;
                DistanceY = Distance;
                break;
            }

            animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + DistanceX, element.TranslationX, Easings.QuinticOut, 0, 0.7);
            animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + DistanceY, element.TranslationY, Easings.BackOut);

            return animation;
        }
    }

    public class BounceInAnimation : AnimationDefinition
    {
        public BounceInAnimation()
        {
            Duration        = 400;
            OpacityFromZero = true;
        }

        public ZDirection FromDirection { get; set; } = ZDirection.Away;
        public double     DistanceX     { get; set; }
        public double     DistanceY     { get; set; }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            if (FromDirection != ZDirection.Steady)
                animation.WithConcurrent(f => element.Scale = f, FromDirection == ZDirection.Away ? 0.3 : 2.0, 1, Easings.BackOut);

            animation.WithConcurrent(f => element.Opacity = f, 0, 1, null, 0, 0.25);

            if (Math.Abs(DistanceX) > 0)
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + DistanceX, element.TranslationX, Easings.BackOut);
            if (Math.Abs(DistanceY) > 0)
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + DistanceY, element.TranslationY, Easings.BackOut);

            return animation;
        }
    }

    public class BounceInUpAnimation : BounceInAnimation
    {
        public BounceInUpAnimation()
        {
            Distance = 500;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }

    public class BounceInDownAnimation : BounceInAnimation
    {
        public BounceInDownAnimation()
        {
            Distance = -500;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }

    public class BounceInLeftAnimation : BounceInAnimation
    {
        public BounceInLeftAnimation()
        {
            Distance = 500;
        }

        public double Distance
        {
            get => DistanceX;
            set => DistanceX = value;
        }
    }

    public class BounceInRightAnimation : BounceInAnimation
    {
        public BounceInRightAnimation()
        {
            Distance = -500;
        }

        public double Distance
        {
            get => DistanceX;
            set => DistanceX = value;
        }
    }

    public class BounceOutAnimation : AnimationDefinition
    {
        public BounceOutAnimation()
        {
            Duration = 400;
        }

        public ZDirection ToDirection { get; set; } = ZDirection.Away;
        public double     Amplitude   { get; set; } = 0.4;
        public double     DistanceX   { get; set; }
        public double     DistanceY   { get; set; }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            element.Opacity = 1;
            animation.WithConcurrent(f => element.Opacity = f, 1, 0, null, 0.5);

            if (ToDirection != ZDirection.Steady)
                animation.WithConcurrent(f => element.Scale = f, 1, ToDirection == ZDirection.Away ? 0.3 : 2.0, Easings.BackIn);
            if (Math.Abs(DistanceX) > 0)
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX, element.TranslationX + DistanceX, Easings.BackIn);
            if (Math.Abs(DistanceY) > 0)
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + DistanceY, Easings.BackIn);

            return animation;
        }
    }

    public class BounceOutUpAnimation : BounceOutAnimation
    {
        public BounceOutUpAnimation()
        {
            Distance = -500;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }

    public class BounceOutDownAnimation : BounceOutAnimation
    {
        public BounceOutDownAnimation()
        {
            Distance = 500;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }

    public class BounceOutLeftAnimation : BounceOutAnimation
    {
        public BounceOutLeftAnimation()
        {
            Distance = -500;
        }

        public double Distance
        {
            get => DistanceX;
            set => DistanceX = value;
        }
    }

    public class BounceOutRightAnimation : BounceOutAnimation
    {
        public BounceOutRightAnimation()
        {
            Distance = 500;
        }

        public double Distance
        {
            get => DistanceX;
            set => DistanceX = value;
        }
    }
}
