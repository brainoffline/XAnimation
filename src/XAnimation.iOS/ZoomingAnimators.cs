using UIKit;

namespace XAnimation
{
    public class ZoomInAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(TransformScale, 0.45f, 1),
                CreateKeyFrame(Opacity,        0,     1)
            );
        }
    }

    public class ZoomInDownAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(TransformScale, 0.1f,                        0.475f, 1),
                CreateKeyFrame(TranslationY,   (float) -view.Bounds.Height, 60f,    0f),
                CreateKeyFrame(Opacity,        0,                           1,      1)
            );
        }
    }

    public class ZoomInLeftAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(TransformScale, 0.1f,                       0.475f, 1),
                CreateKeyFrame(TranslationX,   (float) -view.Bounds.Width, 48f,    0),
                CreateKeyFrame(Opacity,        0,                          1,      1)
            );
        }
    }

    public class ZoomInRightAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(TransformScale, 0.1f,                      0.475f, 1),
                CreateKeyFrame(TranslationX,   (float) view.Bounds.Width, -48f,   0),
                CreateKeyFrame(Opacity,        0,                         1,      1)
            );
        }
    }

    public class ZoomInUpAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,        0,                      1,      1),
                CreateKeyFrame(TransformScale, 0.1f,                   0.475f, 1),
                CreateKeyFrame(TranslationY,   (float) view.Frame.Top, -60f,   0)
            );
        }
    }


    public class ZoomOutAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,        1, 0,    0),
                CreateKeyFrame(TransformScale, 1, 0.3f, 0)
            );
        }
    }

    public class ZoomOutDownAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,        1, 1,      0),
                CreateKeyFrame(TransformScale, 1, 0.475f, 0.1f),
                CreateKeyFrame(TranslationY,   0, -60,    (float) view.Frame.Top)
            );
        }
    }

    public class ZoomOutLeftAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,        1, 1,      0),
                CreateKeyFrame(TransformScale, 1, 0.475f, 0.1f),
                CreateKeyFrame(TranslationX,   0, 42,     (float) view.Frame.Width)
            );
        }
    }

    public class ZoomOutRightAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,        1, 1,      0),
                CreateKeyFrame(TransformScale, 1, 0.475f, 0.1f),
                CreateKeyFrame(TranslationX,   0, -42,    (float) view.Frame.Width)
            );
        }
    }

    public class ZoomOutUpAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity,        1, 1,      0),
                CreateKeyFrame(TransformScale, 1, 0.475f, 0.1f),
                CreateKeyFrame(TranslationY,   0, 60,     (float) view.Frame.Bottom)
            );
        }
    }
}
