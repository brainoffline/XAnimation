using CoreAnimation;
using UIKit;

namespace XAnimation
{
    public class BounceInAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 0, 1, 1, 1),
                CreateKeyFrame(TransformScale, 0.3f, 1.05f, 0.9f, 1)
            );
        }
    }

    public class BounceInDownAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 0, 1, 1, 1),
                CreateKeyFrame(TranslationY, (float)-view.Bounds.Height, 30f, -10f, 0f)
            );
        }
    }

    public class BounceInLeftAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 0, 1, 1, 1),
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseInEaseOut, (float)-view.Bounds.Width, 30f, -10f, 0f)
            );
        }
    }

    public class BounceInRightAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 0, 1, 1, 1),
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseInEaseOut, (float)view.Bounds.Width, -30f, 10f, 0f)
            );
        }
    }

    public class BounceInUpAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 0, 1, 1, 1),
                CreateKeyFrame(TranslationY, CAMediaTimingFunction.EaseInEaseOut, (float)view.Bounds.Height, -30f, 10f, 0f)
            );
        }
    }





	public class BounceOutAnimator : BaseViewAnimator
	{
		protected override void Prepare(UIView view)
		{
            PlayTogether(
                CreateKeyFrame(Opacity, 1, 1, 1, 0),
                CreateKeyFrame(TransformScale, 1, 0.9f, 1.05f, 0.3f)
            );
		}
	}

	public class BounceOutDownAnimator : BaseViewAnimator
	{
		protected override void Prepare(UIView view)
		{
            PlayTogether(
                CreateKeyFrame(Opacity, 1, 1, 1, 0),
                CreateKeyFrame(TranslationY, CAMediaTimingFunction.EaseInEaseOut, 0, -10f, 30f, (float)-view.Bounds.Height)
            );
		}
	}

	public class BounceOutLeftAnimator : BaseViewAnimator
	{
		protected override void Prepare(UIView view)
		{
			PlayTogether(
                CreateKeyFrame(Opacity, 1,1,1,0),
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseInEaseOut, 0, -10f, 30f, (float)-view.Bounds.Width)
            );
		}
	}

	public class BounceOutRightAnimator : BaseViewAnimator
	{
		protected override void Prepare(UIView view)
		{
            PlayTogether(
                CreateKeyFrame(Opacity, 1, 1, 1, 0),
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseInEaseOut, 0f, 10f, -30f, (float)view.Bounds.Width)
            );
		}
	}

	public class BounceOutUpAnimator : BaseViewAnimator
	{
		protected override void Prepare(UIView view)
		{
            PlayTogether(
                CreateKeyFrame(Opacity, 1, 1, 1, 0),
                CreateKeyFrame(TranslationY, CAMediaTimingFunction.EaseInEaseOut, 0, 10f, -30f, (float)view.Bounds.Height)
            );
		}
	}

}
