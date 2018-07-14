using Xamarin.Forms;

namespace XAnimation
{
    public class ScaleInAnimation : AnimationDefinition
    {
        public double StartScale = 0.7;

        public ScaleInAnimation()
        {
            Duration        = 400;
            OpacityFromZero = true;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent(f => element.Opacity = f, 0,          1, null, 0, 0.5);
            animation.WithConcurrent(f => element.Scale   = f, StartScale, 1, Easing.CubicOut);

            return animation;
        }
    }

    public class ScaleOutAnimation : AnimationDefinition
    {
        public double EndScale = 0.7;

        public ScaleOutAnimation()
        {
            Duration = 400;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent(f => element.Opacity = f, 1,             0,        null, 0.5);
            animation.WithConcurrent(f => element.Scale   = f, element.Scale, EndScale, Easing.CubicIn);

            return animation;
        }
    }

    public class ScaleFromElementAnimation : AnimationDefinition
    {
        public ScaleFromElementAnimation()
        {
            OpacityFromZero = true;
            Duration        = 400;
        }

        public VisualElement FromElement { get; set; }

        public override Animation CreateAnimation(VisualElement element)
        {
            var toBounds   = element.Bounds;
            var fromBounds = FromElement.Bounds;

            element.Layout(fromBounds);
            element.AnchorX = 0;
            element.AnchorY = 0;

            var animation = new Animation();

            animation.WithConcurrent(f => element.Opacity = f, 0, 1, null, 0, 0.25);
            animation.WithConcurrent(
                f =>
                {
                    var newBounds = new Rectangle(
                        fromBounds.X      + (toBounds.X      - fromBounds.X)      * f,
                        fromBounds.Y      + (toBounds.Y      - fromBounds.Y)      * f,
                        fromBounds.Width  + (toBounds.Width  - fromBounds.Width)  * f,
                        fromBounds.Height + (toBounds.Height - fromBounds.Height) * f);
                    element.Layout(newBounds);
                });

            return animation;
        }
    }
}
