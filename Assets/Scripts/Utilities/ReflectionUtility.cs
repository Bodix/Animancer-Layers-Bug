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

        public static Playable ConvertAnimationPosePlayableToPlayable(this IPlayable animationPosePlayable)
        {
            Type playableType = typeof(AnimationClipPlayable).Assembly.GetType("UnityEngine.Animations.AnimationPosePlayable");
            MethodInfo toPlayableOperator = playableType.GetMethod(
                "op_Implicit",
                new[] { animationPosePlayable.GetType() });

            return (Playable)toPlayableOperator.Invoke(null, new object[] { animationPosePlayable });
        }

        /// <summary>
        /// Be careful! Crashes Unity when setting to true.
        /// Received signal SIGSEGV
        /// Stack trace:
        /// 0x000000014013a954 (Unity) AnimationPosePlayable::PreProcessAnimation
        /// 0x00000001401249c3 (Unity) AnimationPlayable::PreProcessAnimation
        /// 0x00000001401249c3 (Unity) AnimationPlayable::PreProcessAnimation
        /// 0x00000001400ba135 (Unity) Animator::CreatePlayableMemory
        /// 0x00000001400b9ee2 (Unity) Animator::CreateObject
        /// 0x00000001400b6e3a (Unity) Animator::BuildJobs
        /// 0x00000001400cb3df (Unity) Animator::UpdateAvatars
        /// </summary>
        public static void SetMustReadPreviousPose(this IPlayable animationPosePlayable, bool value)
        {
            Type playableType = typeof(AnimationClipPlayable).Assembly.GetType("UnityEngine.Animations.AnimationPosePlayable");
            MethodInfo setMustReadPreviousPoseMethod = playableType.GetMethod(
                "SetMustReadPreviousPose",
                BindingFlags.Public | BindingFlags.Instance);

            setMustReadPreviousPoseMethod.Invoke(animationPosePlayable, new object[] { value });
        }
        
        public static void SetReadDefaultPose(this IPlayable animationPosePlayable, bool value)
        {
            Type playableType = typeof(AnimationClipPlayable).Assembly.GetType("UnityEngine.Animations.AnimationPosePlayable");
            MethodInfo setMustReadPreviousPoseMethod = playableType.GetMethod(
                "SetReadDefaultPose",
                BindingFlags.Public | BindingFlags.Instance);

            setMustReadPreviousPoseMethod.Invoke(animationPosePlayable, new object[] { value });
        }
    }
}