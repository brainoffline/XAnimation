using Xamarin.Forms;

namespace XAnimation
{
    public class KeyFrame<T>
    {
        public double MilliSeconds { get; set; }
        public T      Value        { get; set; }
        public Easing Easing       { get; set; }
    }

    public abstract class AnimationDefinition
    {
        protected AnimationDefinition()
        {
            Duration = 1000;
        }

        public uint   Duration       { get; set; }
        public int    PauseBefore    { get; set; }
        public int    PauseAfter     { get; set; }
        public double SpeedRatio     { get; set; }
        public int    RepeatCount    { get; set; }
        public int    RepeatDuration { get; set; }
        public int    Delay          { get; set; }
        public bool   AutoReverse    { get; set; }
        public bool   Forever        { get; set; }

        public bool OpacityFromZero { get; protected set; }

        public abstract Animation CreateAnimation(VisualElement element);

        public AnimationDefinition Clone()
        {
            var clone = (AnimationDefinition) MemberwiseClone();
            return clone;
        }
    }
}
