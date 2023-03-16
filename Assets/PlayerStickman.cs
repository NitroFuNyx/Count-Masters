using System.Collections;
using UnityEngine;

public class PlayerStickman : StickmanBase
{
    private void OnEnable()
    {
        StartCoroutine(LateOnEnable());
    }

    private void OnDestroy()
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
    
}
