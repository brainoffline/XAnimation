using System;
using Android.Views;

namespace XAnimation
{
    public static class AnimationExtensions
    {
        public static T CreateAnimator<T>(this View view) where T : BaseViewAnimator, new()
        {
            return new T {View = view};
        }

        public static BaseViewAnimator CreateAnimator(this View view, Type type)
        {
            var animator = Activator.CreateInstance(type) as BaseViewAnimator;
            if (animator == null) return null;

            animator.View = view;
            return animator;
        }

        public static void ResetAnimations(this View view, bool alphaFromZero = false)
        {
            view.Alpha        = alphaFromZero ? 0 : 1;
            view.ScaleX       = 1;
            view.ScaleY       = 1;
            view.TranslationX = 0;
            view.TranslationY = 0;
            view.Rotation     = 0;
            view.RotationX    = 0;
            view.RotationY    = 0;
            view.PivotX       = view.MeasuredWidth  / 2f;
            view.PivotY       = view.MeasuredHeight / 2f;
        }
    }
}
