using UIKit;

namespace XAnimation
{

    public class FlipInXAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 0.25f, 0.5f, 0.75f, 1f),
                CreateKeyFrame(TransformRotateX, DegreesToRadians(90), DegreesToRadians(-15), DegreesToRadians(15), 0f)
            );
        }
    }

    public class FlipInYAnimator : BaseViewAnimator
    {
        public override bool AlphaFromZero => true;

        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 0.25f, 0.5f, 0.75f, 1f),
                CreateKeyFrame(TransformRotateY, DegreesToRadians(90), DegreesToRadians(-15), DegreesToRadians(15), 0f)
            );
        }
    }

    public class FlipOutXAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 1, 0),
                CreateKeyFrame(TransformRotateX, 0, DegreesToRadians(90))
            );
        }
    }

    public class FlipOutYAnimator : BaseViewAnimator
    {
        protected override void Prepare(UIView view)
        {
            PlayTogether(
                CreateKeyFrame(Opacity, 1, 0),
                CreateKeyFrame(TransformRotateY, 0, DegreesToRadians(90))
            );
        }
    }

}
