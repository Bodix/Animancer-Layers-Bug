using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Native
{
    public static class ReflectionUtility
    {
        public static IPlayable CreateAnimationPosePlayable(PlayableGraph graph)
        {
            Type playableType = typeof(AnimationClipPlayable).Assembly.GetType("UnityEngine.Animations.AnimationPosePlayable");
            MethodInfo createMethod = playableType.GetMethod(
                "Create",
                BindingFlags.Public | BindingFlags.Static, 
                null,
                new[] { typeof(PlayableGraph) },
                Array.Empty<ParameterModifier>());
            
            return (IPlayable)createMethod.Invoke(null, new object[] { graph });
        }
    }
}