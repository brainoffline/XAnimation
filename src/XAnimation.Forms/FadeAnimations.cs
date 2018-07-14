using System;
using Xamarin.Forms;

namespace XAnimation
{
    public class HideAnimation : AnimationDefinition
    {
        public HideAnimation()
        {
            OpacityFromZero = true;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            element.Opacity = 0;
            return new Animation();
        }
    }

    public class FadeInAnimation : AnimationDefinition
    {
        public FadeInAnimation()
        {
            Duration        = 400;
            OpacityFromZero = true;
        }

        public double DistanceX { get; set; }
        public double DistanceY { get; set; }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent(f => element.Opacity = f, 0, 1, Easings.CubicOut);

            if (Math.Abs(DistanceX) > 0)
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + DistanceX, element.TranslationX, Easings.CubicOut);

            if (Math.Abs(DistanceY) > 0)
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + DistanceY, element.TranslationY, Easings.CubicOut);

            return animation;
        }
    }

    public class FadeOutAnimation : AnimationDefinition
    {
        public FadeOutAnimation()
        {
            Duration = 400;
        }

        public double DistanceX { get; set; }
        public double DistanceY { get; set; }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent(f => element.Opacity = f, 1, 0);

            if (Math.Abs(DistanceX) > 0)
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX, element.TranslationX + DistanceX);

            if (Math.Abs(DistanceY) > 0)
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + DistanceY);

            return animation;
        }
    }

    public class FadeInUpAnimation : FadeInAnimation
    {
        public FadeInUpAnimation()
        {
            Distance = 100;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }

    public class FadeInDownAnimation : FadeInAnimation
    {
        public FadeInDownAnimation()
        {
            Distance = -100;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }

    public class FadeInLeftAnimation : FadeInAnimation
    {
        public FadeInLeftAnimation()
        {
            Distance = 100;
        }

        public double Distance
        {
            get => DistanceX;
            set => DistanceX = value;
        }
    }

    public class FadeInRightAnimation : FadeInAnimation
    {
        public FadeInRightAnimation()
        {
            Distance = -100;
        }

        public double Distance
        {
            get => DistanceX;
            set => DistanceX = value;
        }
    }

    public class FadeOutUpAnimation : FadeOutAnimation
    {
        public FadeOutUpAnimation()
        {
            Distance = -20;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }

    public class FadeOutDownAnimation : FadeOutAnimation
    {
        public FadeOutDownAnimation()
        {
            Distance = 20;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }

    public class FadeOutLeftAnimation : FadeOutAnimation
    {
        public FadeOutLeftAnimation()
        {
            Distance = -20;
        }

        public double Distance
        {
            get => DistanceX;
            set => DistanceX = value;
        }
    }

    public class FadeOutRightAnimation : FadeOutAnimation
    {
        public FadeOutRightAnimation()
        {
            Distance = 20;
        }

        public double Distance
        {
            get => DistanceY;
            set => DistanceY = value;
        }
    }
}
