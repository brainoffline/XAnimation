using Android.Animation;
using Android.Views;

namespace XAnimation
{

    public class FlipInXAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "rotationX", 90, -15, 15, 0),
                ObjectAnimator.OfFloat(view, "alpha", 0.25f, 0.5f, 0.75f, 1)
                );
        }
    }

    public class FlipInYAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "rotationY", 90, -15, 15, 0),
                ObjectAnimator.OfFloat(view, "alpha", 0.25f, 0.5f, 0.75f, 1)
                );
        }
    }

    public class FlipOutXAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "rotationX", 0, 90),
                ObjectAnimator.OfFloat(view, "alpha", 1, 0)
                );
        }
    }

    public class FlipOutYAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "rotationY", 0, 90),
                ObjectAnimator.OfFloat(view, "alpha", 1, 0)
                );
        }
    }

}
