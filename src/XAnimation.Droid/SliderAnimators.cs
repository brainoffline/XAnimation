using Android.Animation;
using Android.Views;

namespace XAnimation
{
    public class SlideInDownAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            var distance = view.Top + view.Height;
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,         1),
                ObjectAnimator.OfFloat(view, "translationY", -distance, 0)
            );
        }
    }

    public class SlideInLeftAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            var parent   = (ViewGroup) view.Parent;
            var distance = parent.Width - view.Left;
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,         1),
                ObjectAnimator.OfFloat(view, "translationX", -distance, 0)
            );
        }
    }

    public class SlideInRightAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            var parent   = (ViewGroup) view.Parent;
            var distance = parent.Width - view.Left;
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,        1),
                ObjectAnimator.OfFloat(view, "translationX", distance, 0)
            );
        }
    }

    public class SlideInUpAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            var parent   = (ViewGroup) view.Parent;
            var distance = parent.Height - view.Top;
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        0,        1),
                ObjectAnimator.OfFloat(view, "translationY", distance, 0)
            );
        }
    }


    public class SlideOutDownAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            var parent   = (ViewGroup) view.Parent;
            var distance = parent.Height - view.Top;
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        1, 0),
                ObjectAnimator.OfFloat(view, "translationY", 0, distance)
            );
        }
    }

    public class SlideOutLeftAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        1, 0),
                ObjectAnimator.OfFloat(view, "translationX", 0, -view.Right)
            );
        }
    }

    public class SlideOutRightAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            var parent   = (ViewGroup) view.Parent;
            var distance = parent.Width - view.Left;
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        1, 0),
                ObjectAnimator.OfFloat(view, "translationX", 0, distance)
            );
        }
    }

    public class SlideOutUpAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "alpha",        1, 0),
                ObjectAnimator.OfFloat(view, "translationY", 0, -view.Bottom)
            );
        }
    }
}
