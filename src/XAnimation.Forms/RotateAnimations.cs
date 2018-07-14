using Xamarin.Forms;

namespace XAnimation
{
    public enum RotateAnimationDirection
    {
        RotateUp,
        RotateDown
    }

    public class RotateAnimation : AnimationDefinition
    {
        public double? StartRotation { get; set; }
        public double? EndRotation { get; set; }
        public Easing Easing { get; set; } = Easing.SinIn;

        public RotateAnimation()
        {
            Duration = 1000;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var startRotation = StartRotation ?? element.Rotation;
            var endRotation = EndRotation ?? startRotation + 360.0;

            var animation = new Animation();

            element.AnchorX = 0.5;
            element.AnchorY = 0.5;

            animation.WithConcurrent(f => element.Rotation = f, startRotation, endRotation, Easing);

            return animation;
        }
    }

    public class RotateInAnimation : AnimationDefinition
    {
        public RotateAnimationDirection RotateDirection;

        public RotateInAnimation()
        {
            Duration = 400;
            OpacityFromZero = true;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            if (RotateDirection == RotateAnimationDirection.RotateUp)
            {
                element.AnchorX = 0;
                element.AnchorY = 1.5;

                animation.WithConcurrent(f => element.Rotation = f, 45, 0, Easing.SinIn);
            }
            else
            {
                element.AnchorX = 0;
                element.AnchorY = -0.5;

                animation.WithConcurrent(f => element.Rotation = f, -45, 0, Easing.SinIn);
            }
            animation.WithConcurrent(f => element.Opacity = f, 0, 1, Easing.SinIn, 0, 0.25);

            return animation;
        }
    }

    public class RotateOutAnimation : AnimationDefinition
    {
        public RotateAnimationDirection RotateDirection;

        public RotateOutAnimation()
        {
            Duration = 400;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            if (RotateDirection == RotateAnimationDirection.RotateUp)
            {
                element.AnchorX = 0;
                element.AnchorY = 1.5;

                animation.WithConcurrent(f => element.Rotation = f, 0, 45, Easing.SinOut);
            }
            else
            {
                element.AnchorX = 0;
                element.AnchorY = -0.5;

                animation.WithConcurrent(f => element.Rotation = f, 0, -45, Easing.SinOut);
            }
            animation.WithConcurrent(f => element.Opacity = f, 1, 0, Easing.SinOut, 0.5);

            return animation;
        }
    }
}
