using Android.Animation;
using Android.Views;

namespace XAnimation
{
    public class BounceInAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",  0,    1,     1,    1),
                ObjectAnimator.OfFloat(view, "scaleX", 0.3f, 1.05f, 0.9f, 1),
                ObjectAnimator.OfFloat(view, "scaleY", 0.3f, 1.05f, 0.9f, 1)
            );
        }
    }

    public class BounceInDownAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,            1,  1,   1),
                ObjectAnimator.OfFloat(view, "translationY", -view.Height, 30, -10, 0)
            );
        }
    }

    public class BounceInLeftAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "translationX", -view.Width, 30, -10, 0),
                ObjectAnimator.OfFloat(view, "alpha",        0,           1,  1,   1)
            );
        }
    }

    public class BounceInRightAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "translationX", view.MeasuredWidth + view.Width, -30, 10, 0),
                ObjectAnimator.OfFloat(view, "alpha",        0,                               1,   1,  1)
            );
        }
    }

    public class BounceInUpAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "translationY", view.MeasuredHeight, -30, 10, 0),
                ObjectAnimator.OfFloat(view, "alpha",        0,                   1,   1,  1)
            );
        }
    }
}
