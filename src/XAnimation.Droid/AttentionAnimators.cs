using Android.Animation;
using Android.Views;

namespace XAnimation
{
    public class BounceAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "translationY", 0, 0, -30, 0, -15, 0, 0)
            );
        }
    }

    public class FlashAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha", 1, 0, 1, 0, 1)
            );
        }
    }

    public class PulseAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "scaleY", 1, 1.1f, 1),
                ObjectAnimator.OfFloat(view, "scaleX", 1, 1.1f, 1)
            );
        }
    }

    public class RubberBandAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "scaleX", 1, 1.25f, 0.75f, 1.15f, 1),
                ObjectAnimator.OfFloat(view, "scaleY", 1, 0.75f, 1.25f, 0.85f, 1)
            );
        }
    }

    public class ShakeAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "translationX", 0, 25, -25, 25, -25, 15, -15, 6, -6, 0));
        }
    }

    public class StandUpAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            var x = (view.Width - view.PaddingLeft - view.PaddingRight) / 2f
                + view.PaddingLeft;
            float y = view.Height - view.PaddingBottom;
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "pivotX",    x,  x,   x,  x,   x),
                ObjectAnimator.OfFloat(view, "pivotY",    y,  y,   y,  y,   y),
                ObjectAnimator.OfFloat(view, "rotationX", 55, -30, 15, -15, 0)
            );
        }
    }

    public class SwingAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "rotation", 0, 10, -10, 6, -6, 3, -3, 0));
        }
    }

    public class TadaAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "scaleX",   1, 0.9f, 0.9f, 1.1f, 1.1f, 1.1f, 1.1f, 1.1f, 1.1f, 1),
                ObjectAnimator.OfFloat(view, "scaleY",   1, 0.9f, 0.9f, 1.1f, 1.1f, 1.1f, 1.1f, 1.1f, 1.1f, 1),
                ObjectAnimator.OfFloat(view, "rotation", 0, -3,   -3,   3,    -3,   3,    -3,   3,    -3,   0)
            );
        }
    }

    public class WaveAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            var x = (view.Width - view.PaddingLeft - view.PaddingRight) / 2f
                + view.PaddingLeft;
            float y = view.Height - view.PaddingBottom;
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "rotation", 12, -12, 3, -3, 0),
                ObjectAnimator.OfFloat(view, "pivotX",   x,  x,   x, x,  x),
                ObjectAnimator.OfFloat(view, "pivotY",   y,  y,   y, y,  y)
            );
        }
    }

    public class WobbleAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            float width = view.Width;
            var   one   = (float) (width / 100.0);
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "translationX", 0 * one, -25 * one, 20 * one, -15 * one, 10 * one, -5 * one, 0 * one, 0),
                ObjectAnimator.OfFloat(view, "rotation",     0,       -5,        3,        -3,        2,        -1,       0)
            );
        }
    }
}
