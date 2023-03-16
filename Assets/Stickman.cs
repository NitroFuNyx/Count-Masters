using System;
using System.Collections;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] private StickmanColliderHandler stickmenColliderHandler;
    [SerializeField] private Transform stickmanTransform;
    [SerializeField] private StickmenFormatter stickmenFormatter;
    [SerializeField] private GameObject blood;
    [SerializeField] private Animator _animator;

    public GameObject Blood => blood;


    private void OnEnable()
    {
        StartCoroutine(LateOnEnable());
    }

    private void OnDisable()
    {
        GamestagesFSM.Instance.RunningChanged -= EnableRunAnimation;
        GamestagesFSM.Instance.FinishedChanged -= DisaableRunAnimation;
    }

    private IEnumerator LateOnEnable()
    {
        yield return new WaitForSeconds(0.1f);
        GamestagesFSM.Instance.RunningChanged += EnableRunAnimation;
        GamestagesFSM.Instance.FinishedChanged += DisaableRunAnimation;
        if(gameObject.CompareTag("PlayerStickman"))
        CheckAvailableAnimation();
    }

    public void CheckAvailableAnimation()
    {
        if(GamestagesFSM.Instance.CurrentState==GamestagesFSM.State.Running)
            EnableRunAnimation();
        else if (GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Finish ||
                 GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Loose ||
                 GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Menu)
            DisaableRunAnimation();
    }
    private void EnableRunAnimation()
    {
            _animator.SetBool("run", true);
    }

    private void DisaableRunAnimation()
    {
            _animator.SetBool("run", false);
    }

    public StickmanColliderHandler StickmenColliderHandler => stickmenColliderHandler;

    public Transform StickmanTransform => stickmanTransform;

    public StickmenFormatter Formatter => stickmenFormatter;
}