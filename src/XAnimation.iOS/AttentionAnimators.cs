using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace XAnimation
{
    public class BounceAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(TranslationY, CAMediaTimingFunction.Linear, 0, 0, -30, 0, -15, 0, 0)
            );
            SetRepeat();
        }
    }


    public class FlashAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, CAMediaTimingFunction.EaseInEaseOut, 1, 0, 1, 0, 1)
            );
            SetRepeat();
        }
    }

    public class PulseAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(TransformScale, CAMediaTimingFunction.EaseInEaseOut, 1f, 1.1f, 1f)
            );
            SetRepeat();
        }
    }

    public class RubberBandAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(TransformScaleX, CAMediaTimingFunction.EaseInEaseOut, 1f, 1.25f, 0.75f, 1.15f, 1f),
                CreateKeyFrame(TransformScaleY, CAMediaTimingFunction.EaseInEaseOut, 1f, 0.75f, 1.25f, 0.85f, 1f)
            );
        }
    }


    public class ShakeAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseInEaseOut, 0, 25, -25, 25, -25, 15, -15, 6, -6, 0)
            );
            SetRepeat();
        }
    }

    public class StandUpAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            view.Layer.AnchorPoint = new CGPoint(0.5, 1);
            PlayTogether(
                CreateKeyFrame(TransformRotateX, DegreesToRadians(55), DegreesToRadians(-30), DegreesToRadians(15), DegreesToRadians(-15), 0)
            );
        }
    }

    public class SwingAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(
                    TransformRotation,
                    0,
                    DegreesToRadians(10),
                    DegreesToRadians(-10),
                    DegreesToRadians(6),
                    DegreesToRadians(-6),
                    DegreesToRadians(3),
                    DegreesToRadians(-3),
                    0)
            );
        }
    }

    public class TadaAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            var left  = DegreesToRadians(-3f);
            var right = DegreesToRadians(3f);

            PlayTogether(
                CreateKeyFrame(TransformScale,    1,  0.9f, 0.9f, 1.1f,  1.1f, 1.1f,  1.1f, 1.1f,  1.1f, 1),
                CreateKeyFrame(TransformRotation, 0f, left, left, right, left, right, left, right, left, 0f)
            );
        }
    }

    public class WaveAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            view.Layer.AnchorPoint = new CGPoint(0.5f, 1f);
            PlayTogether(CreateKeyFrame(TransformRotation, DegreesToRadians(12), DegreesToRadians(-12), DegreesToRadians(3), DegreesToRadians(-3), 0));
        }
    }

    public class WobbleAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            var width = view.Bounds.Width;
            var one   = (float) (width / 100.0f);

            view.Layer.AnchorPoint = new CGPoint(0.5f, 0f);
            PlayTogether(
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseInEaseOut, 0 * one, -25 * one, 20 * one, -15 * one, 10 * one, -5 * one, 0 * one, 0),
                CreateKeyFrame(
                    TransformRotation,
                    0,
                    DegreesToRadians(-5),
                    DegreesToRadians(3),
                    DegreesToRadians(-3),
                    DegreesToRadians(2),
                    DegreesToRadians(-1),
                    0,
                    0));
        }
    }
}
