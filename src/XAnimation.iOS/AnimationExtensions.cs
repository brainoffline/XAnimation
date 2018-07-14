using System;
using System.Collections.Generic;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace XAnimation
{
    public static class AnimationExtensions
    {
        public static T CreateAnimator<T>(this UIView view) where T : BaseViewAnimator, new()
        {
            return new T {View = view};
        }

        public static BaseViewAnimator CreateAnimator(this UIView view, Type type)
        {
            var animator = Activator.CreateInstance(type) as BaseViewAnimator;
            if (animator == null) return null;

            animator.View = view;
            return animator;
        }

        public static void ResetAnimations(this UIView view, bool alphaFromZero = false)
        {
            view.Alpha     = alphaFromZero ? 0 : 1;
            view.Transform = CGAffineTransform.MakeIdentity(); // Transform + Scale + Rotation + ..
        }


        public static CAKeyFrameAnimation SetTimingFunc(this CAKeyFrameAnimation frameAnimation, CAMediaTimingFunction func)
        {
            frameAnimation.TimingFunction = func;
            return frameAnimation;
        }

        public static CAKeyFrameAnimation SetTimingFunc(this CAKeyFrameAnimation frameAnimation, NSString name)
        {
            frameAnimation.TimingFunction = CAMediaTimingFunction.FromName(name);
            return frameAnimation;
        }

        public static CAKeyFrameAnimation SetDuration(this CAKeyFrameAnimation frameAnimation, double duration)
        {
            frameAnimation.Duration = duration;
            return frameAnimation;
        }

        public static CAKeyFrameAnimation SetValues(this CAKeyFrameAnimation frameAnimation, params float[] values)
        {
            var list = new List<NSNumber>();
            foreach (var value in values)
                list.Add(NSNumber.FromFloat(value));
            frameAnimation.Values = list.ToArray();
            return frameAnimation;
        }
    }
}
