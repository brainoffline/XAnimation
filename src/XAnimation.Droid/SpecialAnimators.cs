using Android.Animation;
using Android.Views;

namespace XAnimation
{
    public class DropOutAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            int distance = view.Top + view.Height;
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 0, 1),
                    Glider.Glide<BounceEaseIn>(Duration, ObjectAnimator.OfFloat(view, "translationY", -distance, 0))
            );
        }
    }

    public class LandingAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    Glider.Glide<QuintEaseOut>(Duration, ObjectAnimator.OfFloat(view, "scaleX", 1.5f, 1f)),
                    Glider.Glide<QuintEaseOut>(Duration, ObjectAnimator.OfFloat(view, "scaleY", 1.5f, 1f)),
                    Glider.Glide<QuintEaseOut>(Duration, ObjectAnimator.OfFloat(view, "alpha", 0, 1f))
            );
        }
    }

    public class TakingOffAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    Glider.Glide<QuintEaseOut>(Duration, ObjectAnimator.OfFloat(view, "scaleX", 1f, 1.5f)),
                    Glider.Glide<QuintEaseOut>(Duration, ObjectAnimator.OfFloat(view, "scaleY", 1f, 1.5f)),
                    Glider.Glide<QuintEaseOut>(Duration, ObjectAnimator.OfFloat(view, "alpha", 1, 0))
            );
        }
    }

    public class HingeAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            float x = view.PaddingLeft;
            float y = view.PaddingTop;
            AnimatorAgent.PlayTogether(
                    Glider.Glide<SineEaseInOut>(1300, ObjectAnimator.OfFloat(view, "rotation", 0, 80, 60, 80, 60, 60)),
                    ObjectAnimator.OfFloat(view, "translationY", 0, 0, 0, 0, 0, 700),
                    ObjectAnimator.OfFloat(view, "alpha", 1, 1, 1, 1, 1, 0),
                    ObjectAnimator.OfFloat(view, "pivotX", x, x, x, x, x, x),
                    ObjectAnimator.OfFloat(view, "pivotY", y, y, y, y, y, y)
            );

            Duration = 1300;
        }
    }

    public class RollInAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 0, 1),
                    ObjectAnimator.OfFloat(view, "translationX", -(view.Width - view.PaddingLeft - view.PaddingRight), 0),
                    ObjectAnimator.OfFloat(view, "rotation", -120, 0)
            );
        }
    }

    public class RollOutAnimator : BaseViewAnimator
    {
        protected override void Prepare(View view)
        {
            AnimatorAgent.PlayTogether(
                    ObjectAnimator.OfFloat(view, "alpha", 1, 0),
                    ObjectAnimator.OfFloat(view, "translationX", 0, view.Width),
                    ObjectAnimator.OfFloat(view, "rotation", 0, 120)
            );
        }
    }

}
