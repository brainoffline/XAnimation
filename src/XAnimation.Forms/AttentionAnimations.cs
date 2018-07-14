using System;
using Xamarin.Forms;

namespace XAnimation
{
    public class FlashAnimation : AnimationDefinition
    {
        public int Count { get; set; } = 2;
        public double LowOpacity { get; set; } = 0;

        public FlashAnimation()
        {
            Duration = 200;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            if (Count == 0)
                Count = 2;

            var span = 0.5 / Count;

            var offset = 0.0;

            for (int i = 0; i < Count; i++)
            {
                animation.WithConcurrent(f => element.Opacity = f, 1, LowOpacity, Easings.CubicInOut, offset, offset + span);
                offset += span;
                animation.WithConcurrent(f => element.Opacity = f, LowOpacity, 1, Easings.CubicInOut, offset, offset + span);
                offset += span;
            }

            return animation;
        }
    }

    public class FloatAnimation : AnimationDefinition
    {
        public double Distance { get; set; } = 100;

        public FloatAnimation()
        {
            Forever = true;
            AutoReverse = true;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + Distance, Easings.CircularInOut);

            return animation;
        }
    }

    public class BounceAnimation : AnimationDefinition
    {
        public double DistanceX { get; set; }
        public double DistanceY { get; set; }

        public BounceAnimation()
        {
            DistanceY = -30;
            DistanceX = 0;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            if (Math.Abs(DistanceY) > 0.001)
            {
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + DistanceY, Easings.CubicInOut, 0.2, 0.4);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY, Easings.CubicInOut, 0.4, 0.5);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + (DistanceY / 2), Easings.CubicInOut, 0.5, 0.6);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY, Easings.CubicInOut, 0.6, 0.8);
            }
            if (Math.Abs(DistanceX) > 0.001)
            {
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX, element.TranslationX + DistanceX, Easings.CubicInOut, 0.2, 0.4);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX, element.TranslationX, Easings.CubicInOut, 0.4, 0.5);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX, element.TranslationX + (DistanceX / 2), Easings.CubicInOut, 0.5, 0.6);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX, element.TranslationX, Easings.CubicInOut, 0.6, 0.8);
            }
            return animation;
        }
    }

    public class ShakeAnimation : AnimationDefinition
    {
        public double DistanceX { get; set; } = 10;
        public double DistanceY { get; set; }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            if (Math.Abs(DistanceX) > 0.001)
            {
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX, element.TranslationX + DistanceX, null, 0.0, 0.1);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + DistanceX, element.TranslationX - DistanceX, null, 0.1, 0.2);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX - DistanceX, element.TranslationX + DistanceX, null, 0.2, 0.3);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + DistanceX, element.TranslationX - DistanceX, null, 0.3, 0.4);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX - DistanceX, element.TranslationX + DistanceX, null, 0.4, 0.5);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + DistanceX, element.TranslationX - DistanceX, null, 0.5, 0.6);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX - DistanceX, element.TranslationX + DistanceX, null, 0.6, 0.7);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + DistanceX, element.TranslationX - DistanceX, null, 0.7, 0.8);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX - DistanceX, element.TranslationX + DistanceX, null, 0.8, 0.9);
                animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + DistanceX, element.TranslationX, null, 0.9, 1.0);
            }
            if (Math.Abs(DistanceY) > 0.001)
            {
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + DistanceY, null, 0.0, 0.1);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + DistanceY, element.TranslationY - DistanceY, null, 0.1, 0.2);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY - DistanceY, element.TranslationY + DistanceY, null, 0.2, 0.3);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + DistanceY, element.TranslationY - DistanceY, null, 0.3, 0.4);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY - DistanceY, element.TranslationY + DistanceY, null, 0.4, 0.5);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + DistanceY, element.TranslationY - DistanceY, null, 0.5, 0.6);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY - DistanceY, element.TranslationY + DistanceY, null, 0.6, 0.7);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + DistanceY, element.TranslationY - DistanceY, null, 0.7, 0.8);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY - DistanceY, element.TranslationY + DistanceY, null, 0.8, 0.9);
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + DistanceY, element.TranslationY, null, 0.9, 1.0);
            }

            return animation;
        }
    }

    public class TadaAnimation : AnimationDefinition
    {
        public double MinScale { get; set; } = 0.9;
        public double MaxScale { get; set; } = 1.1;

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent(f => element.Scale = f, 1, MinScale, Easing.CubicInOut, 0.0, 0.1);
            animation.WithConcurrent(f => element.Scale = f, MinScale, MaxScale, Easing.CubicIn, 0.2, 0.3);
            animation.WithConcurrent(f => element.Scale = f, MaxScale, 1, null, 0.9, 1.0);

            animation.WithConcurrent(f => element.Rotation = f, 0, -3, null, 0.0, 0.1);
            animation.WithConcurrent(f => element.Rotation = f, -3, 3, null, 0.2, 0.3);
            animation.WithConcurrent(f => element.Rotation = f, 3, -3, null, 0.3, 0.4);
            animation.WithConcurrent(f => element.Rotation = f, -3, 3, null, 0.4, 0.5);
            animation.WithConcurrent(f => element.Rotation = f, 3, -3, null, 0.5, 0.6);
            animation.WithConcurrent(f => element.Rotation = f, -3, 3, null, 0.6, 0.7);
            animation.WithConcurrent(f => element.Rotation = f, 3, -3, null, 0.7, 0.8);
            animation.WithConcurrent(f => element.Rotation = f, -3, 3, null, 0.8, 0.9);
            animation.WithConcurrent(f => element.Rotation = f, 3, 0, null, 0.9, 1.0);

            return animation;
        }
    }

    public class QuickReveal : PulseAnimation
    {
        public QuickReveal()
        {
            OpacityFromZero = true;
            Duration = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = base.CreateAnimation(element);

            animation.WithConcurrent(f => element.Opacity = f, 0, 1, Easings.CubicInOut, 0, 0.2);
            animation.WithConcurrent(f => element.Opacity = f, 1, 0, Easings.CubicInOut, 0.8, 1);

            return animation;
        }
    }

    public class SwingAnimation : AnimationDefinition
    {
        public double Distance { get; set; } = 15;

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            element.AnchorX = 0.5;
            element.AnchorY = 0;

            animation.WithConcurrent(f => element.Rotation = f, 0, Distance, null, 0.0, 0.2);
            animation.WithConcurrent(f => element.Rotation = f, Distance, -(Distance * 0.66), null, 0.2, 0.4);
            animation.WithConcurrent(f => element.Rotation = f, -(Distance * 0.66), Distance * 0.33, null, 0.4, 0.6);
            animation.WithConcurrent(f => element.Rotation = f, Distance * 0.33, -(Distance * 0.33), null, 0.6, 0.8);
            animation.WithConcurrent(f => element.Rotation = f, -(Distance * 0.33), 0, null, 0.8, 1.0);

            return animation;
        }
    }

    public class WobbleAnimation : AnimationDefinition
    {
        public double Distance { get; set; } = 25;

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            element.AnchorX = 0.5;
            element.AnchorY = 0;

            animation.WithConcurrent(f => element.Rotation = f, 0, -5, null, 0.0, 0.15);
            animation.WithConcurrent(f => element.Rotation = f, -5, 3, null, 0.15, 0.3);
            animation.WithConcurrent(f => element.Rotation = f, 3, -3, null, 0.3, 0.45);
            animation.WithConcurrent(f => element.Rotation = f, -3, 2, null, 0.45, 0.6);
            animation.WithConcurrent(f => element.Rotation = f, 2, -1, null, 0.6, 0.75);
            animation.WithConcurrent(f => element.Rotation = f, -1, 0, null, 0.75, 1.0);

            animation.WithConcurrent(f => element.TranslationX = f, 0, element.TranslationX  - Distance, null, 0.15, 0.3);
            animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX - Distance, element.TranslationX + (Distance * 0.8), null, 0.3, 0.45);
            animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + (Distance * 0.8), element.TranslationX - (Distance * 0.6), null, 0.45, 0.6);
            animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX - (Distance * 0.6), element.TranslationX + (Distance * 0.4), null, 0.6, 0.75);
            animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX + (Distance * 0.4), element.TranslationX - (Distance * 0.2), null, 0.75, 1.0);
            animation.WithConcurrent(f => element.TranslationX = f, element.TranslationX - (Distance * 0.2), element.TranslationX, null, 0.75, 1.0);

            return animation;
        }
    }

    public class PulseAnimation : AnimationDefinition
    {
        public double MaxScale { get; set; } = 1.1;

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent(f => element.Scale = f, 1, MaxScale, Easing.CubicInOut, 0.0, 0.5);
            animation.WithConcurrent(f => element.Scale = f, MaxScale, 1, Easing.CubicInOut, 0.5, 1.0);

            return animation;
        }
    }

    public class JumpAnimation : AnimationDefinition
    {
        public double Distance { get; set; } = -20;

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            element.AnchorX = 0.5;
            element.AnchorY = 1;

            animation.WithConcurrent(f => element.Scale = f, 1.0, 0.6, null, 0.0, 0.2);
            animation.WithConcurrent(f => element.Scale = f, 0.6, 1.2, null, 0.2, 0.4);
            animation.WithConcurrent(f => element.Scale = f, 1.2, 1.0, null, 0.4, 0.6);
            animation.WithConcurrent(f => element.Scale = f, 1.0, 0.6, null, 0.6, 0.8);
            animation.WithConcurrent(f => element.Scale = f, 0.6, 1.0, null, 0.8, 1.0);

            animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + Distance, Easing.CubicInOut, 0.2, 0.4);
            animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + Distance, element.TranslationY + (Distance*0.5), null, 0.6, 0.8);
            animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY + (Distance*0.5), element.TranslationY, null, 0.6, 0.8);

            return animation;
        }
    }

}
