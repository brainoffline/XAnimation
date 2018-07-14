using Android.Animation;

namespace XAnimation
{
    public class Glider
    {
        public static ValueAnimator Glide<T>(float duration, ValueAnimator animator) where T : BaseEasingMethod, new()
        {
            return Glide(new T(), duration, animator);
        }

        public static ValueAnimator Glide(BaseEasingMethod easing, float duration, ValueAnimator animator)
        {
            easing.Duration = duration;
            animator.SetEvaluator(easing);
            return animator;
        }

        public static PropertyValuesHolder Glide<T>(float duration, PropertyValuesHolder propertyValuesHolder) where T : BaseEasingMethod, new()
        {
            return Glide(new T(), duration, propertyValuesHolder);
        }

        public static PropertyValuesHolder Glide(BaseEasingMethod easing, float duration, PropertyValuesHolder propertyValuesHolder)
        {
            easing.Duration = duration;
            propertyValuesHolder.SetEvaluator(easing);

            return propertyValuesHolder;
        }
    }
}
