using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class SetupPlayables : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private AnimationClip _clip;
    [SerializeField]
    private AvatarMask _mask;
    [SerializeField]
    private bool _applyFootIk = false;
    [SerializeField, Range(0, 1)]
    private float weight1 = 1;
    [SerializeField, Range(0, 1)]
    private float weight2 = 1;
    
    private AnimationLayerMixerPlayable _mixerPlayable;

    private void Start()
    {
        PlayableGraph playableGraph = PlayableGraph.Create(name + " (Custom)");
        AnimationPlayableOutput playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", _animator);

        _mixerPlayable = AnimationLayerMixerPlayable.Create(playableGraph, 2);
        _mixerPlayable.SetLayerMaskFromAvatarMask(1, _mask);
        playableOutput.SetSourcePlayable(_mixerPlayable);

        AnimatorControllerPlayable controllerPlayable =
            AnimatorControllerPlayable.Create(playableGraph, _animator.runtimeAnimatorController);
        playableGraph.Connect(controllerPlayable, 0, _mixerPlayable, 0);
        _animator.runtimeAnimatorController = null;
        
        AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(playableGraph, _clip);
        playableGraph.Connect(clipPlayable, 0, _mixerPlayable, 1);

        playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
        playableGraph.Play();
    }

    private void Update()
    {
        _mixerPlayable.SetInputWeight(0, weight1);
        _mixerPlayable.SetInputWeight(1, weight2);
    }
}