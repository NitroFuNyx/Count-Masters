using System;
using System.Collections;
using UnityEngine;

public abstract class StickmanBase : MonoBehaviour
{
    [SerializeField] protected StickmanColliderHandler stickmenColliderHandler;
    [SerializeField] protected Transform stickmanTransform;
    [SerializeField] protected StickmenFormatter stickmenFormatter;
    [SerializeField] protected GameObject blood;
    [SerializeField] protected Animator _animator;

    public GameObject Blood => blood;


   

    public StickmanColliderHandler StickmenColliderHandler => stickmenColliderHandler;

    public Transform StickmanTransform => stickmanTransform;

    public StickmenFormatter Formatter => stickmenFormatter;

    public Animator Animator1 => _animator;
    
    protected void EnableRunAnimation()
    {
        Animator1.SetBool("run", true);
    }

    protected void DisaableRunAnimation()
    {
        Animator1.SetBool("run", false);
    }
}