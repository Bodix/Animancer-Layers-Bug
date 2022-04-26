using Animancer;
using UnityEngine;

public class SetupAnimancer : MonoBehaviour
{
    [SerializeField]
    private HybridAnimancerComponent _animancer;
    [SerializeField]
    private ClipTransition _transition;
    [SerializeField]
    private AvatarMask _mask;

    private void Start()
    {
        _animancer.Layers[1].SetMask(_mask);
        // This improves the situation a bit, but it still looks ugly.
        // _animancer.Layers[1].ApplyAnimatorIK = true;
        // _animancer.Layers[1].ApplyFootIK = true;
        
        _animancer.Layers[1].Play(_transition);
    }
}
