using Xamarin.Forms;

namespace XAnimation
{
    public class TurnstileLeftOutAnimation : AnimationDefinition
    {
        public TurnstileLeftOutAnimation()
        {
            Duration = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // Center of rotation X = 0
            animation.WithConcurrent(f => element.RotationY = f, 0, -80, Easing.CubicOut);
            animation.WithConcurrent(f => element.Opacity = f, 1, 0, null, 0.8);

            return animation;
        }
    }

    public class TurnstileLeftInAnimation : AnimationDefinition
    {
        public TurnstileLeftInAnimation()
        {
            Duration = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // Center of rotation X = 0
            animation.WithConcurrent(f => element.RotationY = f, 80, 0, Easing.CubicOut);
            animation.WithConcurrent(f => element.Opacity = f, 0, 1, null, 0, 0.01);

            return animation;
        }
    }

    public class TurnstileRightInAnimation : AnimationDefinition
    {
        public TurnstileRightInAnimation()
        {
            Duration = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // Center of rotation X = 1
            animation.WithConcurrent(f => element.RotationY = f, -80, 0, Easing.CubicOut);
            animation.WithConcurrent(f => element.Opacity = f, 0, 1, null, 0, 0.2);

            return animation;
        }
    }

    public class TurnstileRightOutAnimation : AnimationDefinition
    {
        public TurnstileRightOutAnimation()
        {
            Duration = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // Center of rotation X = 1
            animation.WithConcurrent(f => element.RotationY = f, 0, 80, Easing.CubicOut);
            animation.WithConcurrent(f => element.Opacity = f, 1, 0, null, 0.99, 1.0);

            return animation;
        }
    }
}
