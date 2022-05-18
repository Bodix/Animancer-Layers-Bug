// Decompiled with JetBrains decompiler
// Type: UnityEngine.Animations.AnimationPosePlayable
// Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD0A7939-8190-48A0-A161-F66558C98867
// Assembly location: D:\Files\Software\Programs\Unity\Hub\Editor\2020.3.19f1\Data\Managed\UnityEngine\UnityEngine.AnimationModule.dll

// using System;
// using System.Runtime.CompilerServices;
// using UnityEngine.Bindings;
// using UnityEngine.Playables;
// using UnityEngine.Scripting;
//
// namespace UnityEngine.Animations
// {
//   [NativeHeader("Modules/Animation/ScriptBindings/AnimationPosePlayable.bindings.h")]
//   [NativeHeader("Modules/Animation/Director/AnimationPosePlayable.h")]
//   [NativeHeader("Runtime/Director/Core/HPlayable.h")]
//   [StaticAccessor("AnimationPosePlayableBindings", StaticAccessorType.DoubleColon)]
//   [RequiredByNativeCode]
//   internal struct AnimationPosePlayable : IPlayable, IEquatable<AnimationPosePlayable>
//   {
//     private PlayableHandle m_Handle;
//     private static readonly AnimationPosePlayable m_NullPlayable = new AnimationPosePlayable(PlayableHandle.Null);
//
//     public static AnimationPosePlayable Null => AnimationPosePlayable.m_NullPlayable;
//
//     public static AnimationPosePlayable Create(PlayableGraph graph) => new AnimationPosePlayable(AnimationPosePlayable.CreateHandle(graph));
//
//     private static PlayableHandle CreateHandle(PlayableGraph graph)
//     {
//       PlayableHandle handle = PlayableHandle.Null;
//       return !AnimationPosePlayable.CreateHandleInternal(graph, ref handle) ? PlayableHandle.Null : handle;
//     }
//
//     internal AnimationPosePlayable(PlayableHandle handle) => this.m_Handle = !handle.IsValid() || handle.IsPlayableOfType<AnimationPosePlayable>() ? handle : throw new InvalidCastException("Can't set handle: the playable is not an AnimationPosePlayable.");
//
//     public PlayableHandle GetHandle() => this.m_Handle;
//
//     public static implicit operator Playable(AnimationPosePlayable playable) => new Playable(playable.GetHandle());
//
//     public static explicit operator AnimationPosePlayable(Playable playable) => new AnimationPosePlayable(playable.GetHandle());
//
//     public bool Equals(AnimationPosePlayable other) => this.Equals((object) other.GetHandle());
//
//     public bool GetMustReadPreviousPose() => AnimationPosePlayable.GetMustReadPreviousPoseInternal(ref this.m_Handle);
//
//     public void SetMustReadPreviousPose(bool value) => AnimationPosePlayable.SetMustReadPreviousPoseInternal(ref this.m_Handle, value);
//
//     public bool GetReadDefaultPose() => AnimationPosePlayable.GetReadDefaultPoseInternal(ref this.m_Handle);
//
//     public void SetReadDefaultPose(bool value) => AnimationPosePlayable.SetReadDefaultPoseInternal(ref this.m_Handle, value);
//
//     public bool GetApplyFootIK() => AnimationPosePlayable.GetApplyFootIKInternal(ref this.m_Handle);
//
//     public void SetApplyFootIK(bool value) => AnimationPosePlayable.SetApplyFootIKInternal(ref this.m_Handle, value);
//
//     [NativeThrows]
//     private static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle) => AnimationPosePlayable.CreateHandleInternal_Injected(ref graph, ref handle);
//
//     [NativeThrows]
//     [MethodImpl(MethodImplOptions.InternalCall)]
//     private static extern bool GetMustReadPreviousPoseInternal(ref PlayableHandle handle);
//
//     [NativeThrows]
//     [MethodImpl(MethodImplOptions.InternalCall)]
//     private static extern void SetMustReadPreviousPoseInternal(
//       ref PlayableHandle handle,
//       bool value);
//
//     [NativeThrows]
//     [MethodImpl(MethodImplOptions.InternalCall)]
//     private static extern bool GetReadDefaultPoseInternal(ref PlayableHandle handle);
//
//     [NativeThrows]
//     [MethodImpl(MethodImplOptions.InternalCall)]
//     private static extern void SetReadDefaultPoseInternal(ref PlayableHandle handle, bool value);
//
//     [NativeThrows]
//     [MethodImpl(MethodImplOptions.InternalCall)]
//     private static extern bool GetApplyFootIKInternal(ref PlayableHandle handle);
//
//     [NativeThrows]
//     [MethodImpl(MethodImplOptions.InternalCall)]
//     private static extern void SetApplyFootIKInternal(ref PlayableHandle handle, bool value);
//
//     [MethodImpl(MethodImplOptions.InternalCall)]
//     private static extern bool CreateHandleInternal_Injected(
//       ref PlayableGraph graph,
//       ref PlayableHandle handle);
//   }
// }