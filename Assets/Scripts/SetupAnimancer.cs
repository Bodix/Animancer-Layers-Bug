using Animancer;
using UnityEngine;

public class SetupAnimancer : MonoBehaviour
{
    [SerializeField]
    private AnimancerComponent _animancer;
    [SerializeField]
    private ClipTransition _moveTransition;
    [SerializeField]
    private ClipTransition _attackTransition;
    [SerializeField]
    private AvatarMask _mask;

    private void Start()
    {
        _animancer.Play(_moveTransition);
        _animancer.Layers[1].SetMask(_mask);

        _animancer.Layers[1].Play(_attackTransition);
    }
}