using System.Threading.Tasks;
using Android.Animation;
using Android.Views;
using Android.Views.Animations;
using Java.Lang;

namespace XAnimation
{
    public abstract class BaseViewAnimator : Object
    {
        private const long DefaultDuration = 1000;

        public BaseViewAnimator() { }

        public BaseViewAnimator(View view)
        {
            view.ResetAnimations(AlphaFromZero);
            Prepare(view);
        }

        public         AnimatorSet AnimatorAgent { get; }      = new AnimatorSet();
        public         long        Duration      { get; set; } = DefaultDuration;
        public virtual bool        AlphaFromZero => false;

        public View View
        {
            set
            {
                value.ResetAnimations(AlphaFromZero);
                Prepare(value);
            }
        }

        public long StartDelay
        {
            set => AnimatorAgent.StartDelay = value;
            get => AnimatorAgent.StartDelay;
        }

        public bool IsRunning => AnimatorAgent.IsRunning;

        public bool IsStarted => AnimatorAgent.IsStarted;

        public IInterpolator Interpolator
        {
            set => AnimatorAgent.SetInterpolator(value);
        }

        protected abstract void Prepare(View view);

        public void Start()
        {
            AnimatorAgent.SetDuration(Duration);
            AnimatorAgent.Start();
        }

        public Task Animate()
        {
            var tcs = new TaskCompletionSource<bool>();

            AnimatorAgent.AnimationEnd    += (s, e) => { tcs.SetResult(true); };
            AnimatorAgent.AnimationRepeat += (s, e) => { tcs.SetResult(false); };
            AnimatorAgent.AnimationCancel += (s, e) => { tcs.SetCanceled(); };
            Start();

            return tcs.Task;
        }

        public void Cancel()
        {
            AnimatorAgent.Cancel();
        }

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
    }
}
