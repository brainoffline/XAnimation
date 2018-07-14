using Xamarin.Forms;

namespace XAnimation
{
    public enum Side
    {
        Left,
        Right
    }

    public class HingeAnimation : AnimationDefinition
    {
        public Side Side { get; set; } = Side.Left;
        public double Distance { get; set; } = 700;
        public double? AnchorX { get; set; }
        public double? AnchorY { get; set; }

        public HingeAnimation()
        {
            Duration = 1000;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();
            if (Side == Side.Left)
            {
                element.AnchorX = AnchorX ?? 0;
                element.AnchorY = AnchorY ?? 0;

                // Rotation
                animation.WithConcurrent(f => element.Rotation = f, 0, 80, Easing.CubicInOut, 0, 0.2);
                animation.WithConcurrent(f => element.Rotation = f, 80, 60, Easing.CubicInOut, 0.2, 0.4);
                animation.WithConcurrent(f => element.Rotation = f, 60, 80, Easing.CubicInOut, 0.4, 0.6);
                animation.WithConcurrent(f => element.Rotation = f, 80, 60, Easing.CubicInOut, 0.6, 0.8);
                animation.WithConcurrent(f => element.Rotation = f, 60, 70, Easing.Linear, 0.8);

                // Fall
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + Distance, Easing.CubicIn, 0.7);

                // Opacity
                animation.WithConcurrent(f => element.Opacity = f, 1, 0, null, 0.9);
            }
            else
            {
                element.AnchorX = AnchorX ?? 1;
                element.AnchorY = AnchorY ?? 0;

                // Rotation
                animation.WithConcurrent(f => element.Rotation = f, 0, -80, Easing.CubicInOut, 0, 0.2);
                animation.WithConcurrent(f => element.Rotation = f, -80, -60, Easing.CubicInOut, 0.2, 0.4);
                animation.WithConcurrent(f => element.Rotation = f, -60, -80, Easing.CubicInOut, 0.4, 0.6);
                animation.WithConcurrent(f => element.Rotation = f, -80, -60, Easing.CubicInOut, 0.6, 0.8);
                animation.WithConcurrent(f => element.Rotation = f, -60, -70, Easing.Linear, 0.8);

                // Fall
                animation.WithConcurrent(f => element.TranslationY = f, element.TranslationY, element.TranslationY + Distance, Easing.CubicIn, 0.7);

                // Opacity
                animation.WithConcurrent(f => element.Opacity = f, 1, 0, null, 0.9);
            }

            return animation;
        }
    }
}
