using Android.Animation;
using Android.Views;

namespace XAnimation
{
    public class ZoomInAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                ObjectAnimator.OfFloat(view, "scaleX", 0.45f, 1),
                ObjectAnimator.OfFloat(view, "scaleY", 0.45f, 1),
                ObjectAnimator.OfFloat(view, "alpha", 0, 1)
                );
        }
    }

    public class ZoomInDownAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "scaleX", 0.1f, 0.475f, 1),
                    ObjectAnimator.OfFloat(view, "scaleY", 0.1f, 0.475f, 1),
                    ObjectAnimator.OfFloat(view, "translationY", -view.Bottom, 60, 0),
                    ObjectAnimator.OfFloat(view, "alpha", 0, 1, 1)
            );
        }
    }

    public class ZoomInLeftAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "scaleX", 0.1f, 0.475f, 1),
                    ObjectAnimator.OfFloat(view, "scaleY", 0.1f, 0.475f, 1),
                    ObjectAnimator.OfFloat(view, "translationX", -view.Right, 48, 0),
                    ObjectAnimator.OfFloat(view, "alpha", 0, 1, 1)
            );
        }
    }

    public class ZoomInRightAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "scaleX", 0.1f, 0.475f, 1),
                    ObjectAnimator.OfFloat(view, "scaleY", 0.1f, 0.475f, 1),
                    ObjectAnimator.OfFloat(view, "translationX", view.Width + view.PaddingRight, -48, 0),
                    ObjectAnimator.OfFloat(view, "alpha", 0, 1, 1)
            );
        }
    }

    public class ZoomInUpAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            ViewGroup parent = (ViewGroup)view.Parent;
            int distance = parent.Height - view.Top;
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 0, 1, 1),
                    ObjectAnimator.OfFloat(view, "scaleX", 0.1f, 0.475f, 1),
                    ObjectAnimator.OfFloat(view, "scaleY", 0.1f, 0.475f, 1),
                    ObjectAnimator.OfFloat(view, "translationY", distance, -60, 0)
            );
        }
    }



    public class ZoomOutAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 1, 0, 0),
                    ObjectAnimator.OfFloat(view, "scaleX", 1, 0.3f, 0),
                    ObjectAnimator.OfFloat(view, "scaleY", 1, 0.3f, 0)
            );
        }
    }

    public class ZoomOutDownAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            ViewGroup parent = (ViewGroup)view.Parent;
            int distance = parent.Height - view.Top;
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 1, 1, 0),
                    ObjectAnimator.OfFloat(view, "scaleX", 1, 0.475f, 0.1f),
                    ObjectAnimator.OfFloat(view, "scaleY", 1, 0.475f, 0.1f),
                    ObjectAnimator.OfFloat(view, "translationY", 0, -60, distance)
            );
        }
    }

    public class ZoomOutLeftAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 1, 1, 0),
                    ObjectAnimator.OfFloat(view, "scaleX", 1, 0.475f, 0.1f),
                    ObjectAnimator.OfFloat(view, "scaleY", 1, 0.475f, 0.1f),
                    ObjectAnimator.OfFloat(view, "translationX", 0, 42, -view.Right)
            );
        }
    }

    public class ZoomOutRightAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            ViewGroup parent = (ViewGroup)view.Parent;
            int distance = parent.Width - parent.Left;
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 1, 1, 0),
                    ObjectAnimator.OfFloat(view, "scaleX", 1, 0.475f, 0.1f),
                    ObjectAnimator.OfFloat(view, "scaleY", 1, 0.475f, 0.1f),
                    ObjectAnimator.OfFloat(view, "translationX", 0, -42, distance)
            );
        }
    }

    public class ZoomOutUpAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 1, 1, 0),
                    ObjectAnimator.OfFloat(view, "scaleX", 1, 0.475f, 0.1f),
                    ObjectAnimator.OfFloat(view, "scaleY", 1, 0.475f, 0.1f),
                    ObjectAnimator.OfFloat(view, "translationY", 0, 60, -view.Bottom)
            );
        }
    }

}
