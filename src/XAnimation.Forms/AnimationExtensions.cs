using System.Threading.Tasks;
using Xamarin.Forms;

namespace XAnimation
{
    public static class AnimationExtensions
    {
        public static Task<bool> Animate(this VisualElement visualElement, AnimationDefinition animationDefinition)
        {
            var tcs = new TaskCompletionSource<bool>();
            var animation = animationDefinition.CreateAnimation(visualElement);
            var animationId = visualElement.Id.ToString();

            // Prevent any opacity challenges when element starts hidden
            if (animationDefinition.OpacityFromZero)
            {
                visualElement.Opacity = 0;
                visualElement.IsVisible = true;
            }

            if (animationDefinition.PauseBefore > 0 ||
                animationDefinition.PauseAfter > 0 ||
                animationDefinition.RepeatCount > 1 ||
                animationDefinition.Delay > 0)
            {
                Task.Run(async () =>
                {
                    int remaining = animationDefinition.RepeatCount;

                    if (animationDefinition.PauseBefore > 0)
                        await Task.Delay(animationDefinition.PauseBefore);

                    animation.Commit(
                        owner:visualElement,
                        name: animationId,
                        rate: 16,
                        length: animationDefinition.Duration,
                        easing: null,
                        finished: async (f, cancelled) =>
                        {
                            if (!cancelled && animationDefinition.PauseAfter > 0)
                                await Task.Delay(animationDefinition.PauseAfter);

                            if (cancelled || remaining <= 0)
                                tcs.SetResult(cancelled);
                        },
                        repeat: () =>
                        {
                            remaining--;
                            return remaining > 0;
                        });
                });
            }
            else
            {
                animation.Commit(
                    owner: visualElement,
                    name: animationId,
                    rate: 16,
                    length: animationDefinition.Duration,
                    easing: null,
                    finished: (f, a) => tcs.SetResult(a));
            }

            return tcs.Task;
        }

        public static void ClearTransforms(this VisualElement visualElement, int opacity = 1)
        {
            visualElement.AbortAnimation(visualElement.Id.ToString());

            visualElement.BatchBegin();
            visualElement.Opacity = opacity;
            visualElement.TranslationX = 0;
            visualElement.TranslationY = 0;
            visualElement.Rotation = 0;
            visualElement.Scale = 1;
            visualElement.RotationX = 0;
            visualElement.RotationY = 0;
            visualElement.AnchorX = 0.5;
            visualElement.AnchorY = 0.5;
            visualElement.BatchCommit();
        }
    }
}
