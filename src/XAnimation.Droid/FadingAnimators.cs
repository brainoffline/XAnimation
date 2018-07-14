using Android.Animation;
using Android.Views;

namespace XAnimation
{
    public class FadeInAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha", 0, 1)
            );
        }
    }

    public class FadeInDownAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,                        1),
                ObjectAnimator.OfFloat(view, "translationY", (float) -view.Height / 4, 0)
            );
        }
    }

    public class FadeInLeftAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,                       1),
                ObjectAnimator.OfFloat(view, "translationX", (float) -view.Width / 4, 0)
            );
        }
    }

    public class FadeInRightAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,                      1),
                ObjectAnimator.OfFloat(view, "translationX", (float) view.Width / 4, 0)
            );
        }
    }

    public class FadeInUpAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,                       1),
                ObjectAnimator.OfFloat(view, "translationY", (float) view.Height / 4, 0)
            );
        }
    }


    public class FadeOutAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha", 1, 0)
            );
        }
    }

    public class FadeOutDownAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        1, 0),
                ObjectAnimator.OfFloat(view, "translationY", 0, (float) view.Height / 4)
            );
        }
    }

    public class FadeOutLeftAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        1, 0),
                ObjectAnimator.OfFloat(view, "translationX", 0, (float) -view.Width / 4)
            );
        }
    }

    public class FadeOutRightAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        1, 0),
                ObjectAnimator.OfFloat(view, "translationX", 0, (float) view.Width / 4)
            );
        }
    }

    public class FadeOutUpAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        1, 0),
                ObjectAnimator.OfFloat(view, "translationY", 0, (float) -view.Height / 4)
            );
        }
    }
}
