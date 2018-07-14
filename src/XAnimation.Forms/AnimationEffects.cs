using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XAnimation
{
    public class AnimationEffects
    {
        public static Task Staggered(
            List<VisualElement> elements,
            AnimationDefinition animation,
            int                 initialDelay, int staggeredDelay, bool clear)
        {
            var list = new List<Task>();

            var delay = initialDelay;
            foreach (var element in elements)
            {
                var child = animation.Clone();
                child.PauseBefore = delay;

                if (clear)
                    element.ClearTransforms(0);
                list.Add(element.Animate(child));
                delay += staggeredDelay;
            }

            return Task.WhenAll(list);
        }

        public static Task Staggered(
            List<VisualElement>       elements,
            List<AnimationDefinition> animations,
            int                       initialDelay, int staggeredDelay, bool clear)
        {
            var list = new List<Task>();
            var rnd  = new Random();

            var delay = initialDelay;
            foreach (var element in elements)
            {
                var index = rnd.Next(animations.Count);

                var child = animations[index].Clone();
                child.PauseBefore = delay;

                if (clear)
                    element.ClearTransforms(0);
                list.Add(element.Animate(child));
                delay += staggeredDelay;
            }

            return Task.WhenAll(list);
        }

        public static Task StaggeredChildren(
            VisualElement       rootElement,
            AnimationDefinition animation,
            int                 initialDelay, int staggeredDelay, bool clear)
        {
            var list = new List<Task>();

            var delay    = initialDelay;
            var elements = rootElement.LogicalChildren;

            foreach (var element in elements.OfType<VisualElement>())
            {
                var child = animation.Clone();
                child.PauseBefore = delay;

                if (clear)
                    element.ClearTransforms(0);
                list.Add(element.Animate(child));
                delay += staggeredDelay;
            }

            return Task.WhenAll(list);
        }
    }
}
