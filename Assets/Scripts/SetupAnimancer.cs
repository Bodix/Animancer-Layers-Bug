using Animancer;
using UnityEngine;

public class SetupAnimancer : MonoBehaviour
{
    [SerializeField]
    private HybridAnimancerComponent _animancer;
    [SerializeField]
    private AnimationClip _animation;
    [SerializeField]
    private AvatarMask _mask;

    private void Start()
    {
        _animancer.Layers[1].SetMask(_mask);
        _animancer.Layers[1].Play(_animation);
    }
}
