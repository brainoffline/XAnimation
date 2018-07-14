using CoreAnimation;
using UIKit;

namespace XAnimation
{
    public class FadeToAnimator : BaseViewAnimator
    {
        public float DestValue { get; set; } = 1;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, (float) view.Alpha, DestValue)
            );
        }

        public FadeToAnimator SetDestValue(float value)
        {
            DestValue = value;
            return this;
        }
    }


    public class FadeInAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        public float DestValue { get; set; } = 1;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 0, DestValue)
            );
        }

        public FadeInAnimator SetDestValue(float value)
        {
            DestValue = value;
            return this;
        }
    }


    public class FadeInDownAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,      0,                             1),
                CreateKeyFrame(TranslationY, CAMediaTimingFunction.EaseOut, (float) -view.Bounds.Height / 4f, 0f)
            );
        }
    }

    public class FadeInLeftAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,      0,                             1),
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseOut, (float) -view.Bounds.Width / 4f, 0f)
            );
        }
    }

    public class FadeInRightAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,      0,                             1),
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseOut, (float) view.Bounds.Width / 4f, 0f)
            );
        }
    }

    public class FadeInUpAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,      0,                             1),
                CreateKeyFrame(TranslationY, CAMediaTimingFunction.EaseOut, (float) view.Bounds.Height / 4f, 0f)
            );
        }
    }


    public class FadeOutAnimator : BaseViewAnimator
    {
        public float DestValue { get; set; }

        protected override void Prepare(UIView view)
        {
            PlayTogether(CreateKeyFrame(Opacity, 1, DestValue));
        }

        public FadeOutAnimator SetDestValue(float value)
        {
            DestValue = value;
            return this;
        }
    }

    public class FadeOutDownAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,      1,                             0),
                CreateKeyFrame(TranslationY, CAMediaTimingFunction.EaseOut, 0, (float) view.Bounds.Height / 4f)
            );
        }
    }

    public class FadeOutLeftAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,      1,                             0),
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseOut, 0, (float) -view.Bounds.Width / 4f)
            );
        }
    }

    public class FadeOutRightAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,      1,                             0),
                CreateKeyFrame(TranslationX, CAMediaTimingFunction.EaseOut, 0, (float) view.Bounds.Width / 4f));
        }
    }

    public class FadeOutUpAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,      1,                             0),
                CreateKeyFrame(TranslationY, CAMediaTimingFunction.EaseOut, 0, (float) -view.Bounds.Height / 4f)
            );
        }
    }
}
