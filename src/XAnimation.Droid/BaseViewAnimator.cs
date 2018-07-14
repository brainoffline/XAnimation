using System.Threading.Tasks;
using Android.Animation;
using Android.Views;
using Android.Views.Animations;

namespace XAnimation
{
    public abstract class BaseViewAnimator : Java.Lang.Object
    {
        private const long DefaultDuration = 1000;

        public AnimatorSet AnimatorAgent { get; } = new AnimatorSet();
        public long Duration { get; set; } = DefaultDuration;
        public virtual bool AlphaFromZero => false;

        protected abstract void Prepare(View view);

        public BaseViewAnimator() { }
        public BaseViewAnimator(View view)
        {
            view.ResetAnimations(AlphaFromZero);
            Prepare(view);
        }

        public View View
        {
            set
            {
                value.ResetAnimations(AlphaFromZero);
                Prepare(value);
            }
        }

        public void Start()
        {
            AnimatorAgent.SetDuration(Duration);
            AnimatorAgent.Start();
        }

        public Task Animate()
        {
            var tcs = new TaskCompletionSource<bool>();

            AnimatorAgent.AnimationEnd += (s,e) =>
            {
                tcs.SetResult(true);
            };
            AnimatorAgent.AnimationRepeat += (s, e) =>
            {
                tcs.SetResult(false);
            };
            AnimatorAgent.AnimationCancel += (s, e) => 
            {
                tcs.SetCanceled();
            };
            Start();

            return tcs.Task;
        }

        public long StartDelay
        {
            set => AnimatorAgent.StartDelay = value;
            get => AnimatorAgent.StartDelay;
        }

        public void Cancel()
        {
            AnimatorAgent.Cancel();
        }

        public bool IsRunning => AnimatorAgent.IsRunning;

        public bool IsStarted => AnimatorAgent.IsStarted;

        public BaseViewAnimator AddAnimatorListener(Animator.IAnimatorListener l)
        {
            AnimatorAgent.Listeners.Add(l);
            return this;
        }

        public void RemoveAnimatorListener(Animator.IAnimatorListener l)
        {
            AnimatorAgent.Listeners.Remove(l);
        }

        public void RemoveAllListener()
        {
            AnimatorAgent.Listeners.Clear();
        }

        public IInterpolator Interpolator
        {
            set => AnimatorAgent.SetInterpolator(value);
        }

    }
}
