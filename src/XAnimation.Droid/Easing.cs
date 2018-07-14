using System;
using Android.Animation;
using Object = Java.Lang.Object;

namespace XAnimation
{
    public abstract class BaseEasingMethod : Object, ITypeEvaluator
    {
        public static float DefaultDuration = 1000f;

        public BaseEasingMethod() { }

        public BaseEasingMethod(float duration)
        {
            Duration = duration;
        }

        public float Duration { get; set; } = DefaultDuration;

        public Object Evaluate(float fraction, Object startValue, Object endValue)
        {
            var t      = Duration * fraction;
            var b      = (float) startValue;
            var c      = (float) endValue - (float) startValue;
            var d      = Duration;
            var result = Calculate(t, b, c, d);

            RaiseEasing(
                new EasingValues
                {
                    time     = t,
                    value    = result,
                    start    = b,
                    end      = c,
                    duration = d
                });

            return result;
        }

        public event EventHandler<EasingValues> EasingListeners;

        protected void RaiseEasing(EasingValues values)
        {
            EasingListeners?.Invoke(this, values);
        }

        public abstract float Calculate(float t, float b, float c, float d);

        public struct EasingValues
        {
            public float time;
            public float value;
            public float start;
            public float end;
            public float duration;
        }
    }


    public class BackEaseIn : BaseEasingMethod
    {
        private readonly float s = 1.70158f;

        public override float Calculate(float t, float b, float c, float d)
        {
            return c * (t /= d) * t * ((s + 1f) * t - s) + b;
        }
    }

    public class BackEaseInOut : BaseEasingMethod
    {
        private float s = 1.70158f;

        public override float Calculate(float t, float b, float c, float d)
        {
            if ((t /= d  / 2f) < 1f)
                return c / 2f * (t * t * (((s *= 1.525f) + 1f) * t - s)) + b;
            return c / 2f * ((t -= 2f) * t * (((s *= 1.525f) + 1f) * t + s) + 2f) + b;
        }
    }

    public class BackEaseOut : BaseEasingMethod
    {
        private readonly float s = 1.70158f;

        public override float Calculate(float t, float b, float c, float d)
        {
            return c * ((t = t / d - 1f) * t * ((s + 1f) * t + s) + 1f) + b;
        }
    }


    public abstract class BaseBounceEase : BaseEasingMethod
    {
        protected static float Calc(float t, float b, float c, float d)
        {
            if ((t /= d) < 1f / 2.75f)
                return c * (7.5625f * t * t) + b;
            if (t < 2f / 2.75f)
                return c * (7.5625f * (t -= 1.5f / 2.75f) * t + .75f) + b;
            if (t < 2.5f / 2.75f)
                return c * (7.5625f * (t -= 2.25f / 2.75f) * t + .9375f) + b;
            return c * (7.5625f * (t -= 2.625f / 2.75f) * t + .984375f) + b;
        }
    }

    public class BounceEaseIn : BaseBounceEase
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c - Calc(d - t, 0, c, d) + b;
        }
    }

    public class BounceEaseInOut : BaseBounceEase
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if (t < d / 2f)
            {
                var value = c - Calc(d - t * 2f, 0, c, d) + b;
                return value * .5f + b;
            }

            return Calc(t * 2f - d, 0, c, d) * .5f + c * .5f + b;
        }
    }

    public class BounceEaseOut : BaseBounceEase
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return Calc(t, b, c, d);
        }
    }


    public class CircEaseIn : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return -c * ((float) Math.Sqrt(1f - (t /= d) * t) - 1f) + b;
        }
    }

    public class CircEaseInOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if ((t /= d   / 2f) < 1f)
                return -c / 2f * ((float) Math.Sqrt(1f - t * t) - 1f) + b;

            return c / 2f * ((float) Math.Sqrt(1 - (t -= 2f) * t) + 1f) + b;
        }
    }

    public class CircEaseOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c * (float) Math.Sqrt(1f - (t = t / d - 1f) * t) + b;
        }
    }


    public class CubicEaseIn : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c * (t /= d) * t * t + b;
        }
    }

    public class CubicEaseInOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if ((t /= d / 2f) < 1f)
                return c / 2f * t * t * t + b;

            return c / 2f * ((t -= 2f) * t * t + 2f) + b;
        }
    }

    public class CubicEaseOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c * ((t = t / d - 1f) * t * t + 1f) + b;
        }
    }


    public class ElasticEaseIn : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if (t == 0f)
                return b;
            if ((t /= d) == 1f)
                return b + c;
            var p = d * .3f;
            var a = c;
            var s = p                                          / 4f;
            return -(a * (float) Math.Pow(2f, 10f * (t -= 1f)) * (float) Math.Sin((t * d - s) * (2f * (float) Math.PI) / p)) + b;
        }
    }

    public class ElasticEaseInOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if (t == 0)
                return b;
            if ((t /= d / 2f) == 2f)
                return b + c;
            var p = d * (.3f * 1.5f);
            var a = c;
            var s = p / 4f;
            if (t < 1)
                return -.5f * (a * (float) Math.Pow(2f, 10f * (t -= 1f)) * (float) Math.Sin((t * d - s) * (2f * (float) Math.PI) / p)) + b;
            return a * (float) Math.Pow(2f, -10f * (t -= 1f)) * (float) Math.Sin((t * d - s) * (2f * (float) Math.PI) / p) * .5f + c + b;
        }
    }

    public class ElasticEaseOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if (t == 0)
                return b;
            if ((t /= d) == 1f)
                return b + c;
            var p = d * .3f;
            var a = c;
            var s = p / 4f;
            return a * (float) Math.Pow(2f, -10f * t) * (float) Math.Sin((t * d - s) * (2f * (float) Math.PI) / p) + c + b;
        }
    }


    public class ExpoEaseIn : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return t == 0f ? b : c * (float) Math.Pow(2f, 10f * (t / d - 1f)) + b;
        }
    }

    public class ExpoEaseInOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if (t            == 0f) return b;
            if (t            == d) return b                                            + c;
            if ((t /= d / 2) < 1) return c / 2f * (float) Math.Pow(2f, 10f * (t - 1f)) + b;
            return c                            / 2 * (-(float) Math.Pow(2f, -10f * --t) + 2f) + b;
        }
    }

    public class ExpoEaseOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return t == d ? b + c : c * (-(float) Math.Pow(2f, -10f * t / d) + 1f) + b;
        }
    }


    public class LinearEasing : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }
    }


    public class QuadEaseIn : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c * (t /= d) * t + b;
        }
    }

    public class QuadEaseInOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if ((t /= d / 2f) < 1f) return c / 2f * t * t + b;
            return -c                                 / 2f * (--t * (t - 2f) - 1f) + b;
        }
    }

    public class QuadEaseOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return -c * (t /= d) * (t - 2f) + b;
        }
    }


    public class QuintEaseIn : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c * (t /= d) * t * t * t * t + b;
        }
    }

    public class QuintEaseInOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            if ((t /= d / 2f) < 1f)
                return c / 2f * t * t * t * t * t + b;
            return c / 2f * ((t -= 2f) * t * t * t * t + 2f) + b;
        }
    }

    public class QuintEaseOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c * ((t = t / d - 1f) * t * t * t * t + 1f) + b;
        }
    }


    public class SineEaseIn : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return -c * (float) Math.Cos(t / d * (Math.PI / 2f)) + c + b;
        }
    }

    public class SineEaseInOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return -c / 2f * ((float) Math.Cos(Math.PI * t / d) - 1f) + b;
        }
    }

    public class SineEaseOut : BaseEasingMethod
    {
        public override float Calculate(float t, float b, float c, float d)
        {
            return c * (float) Math.Sin(t / d * (Math.PI / 2f)) + b;
        }
    }
}
