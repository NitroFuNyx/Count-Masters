using DG.Tweening;
using UnityEngine;
using WSWhitehouse.TagSelector;

public class StickmanColliderHandler : MonoBehaviour
{
    [TagSelector] public string stickmanTag = "";
    [SerializeField] private StickmanBase stickmanBase;

    [SerializeField] private StickmenHolder stickmenHolder;

    private bool _collided;
    private StickmenCounterPresenter _stickmenCounterPresenter;


    public void SetHolder(StickmenHolder stickmenHolder)
    {
        this.stickmenHolder = stickmenHolder;
    }

    public void SetCounter(StickmenCounterPresenter stickmenCounterPresenter)
    {
        _stickmenCounterPresenter = stickmenCounterPresenter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_collided) return;
        if (other.CompareTag(stickmanTag))
        {
            if (stickmenHolder == null || stickmanBase == null) return;
            _collided = true;
            stickmanBase.Blood.SetActive(true);
            stickmenHolder.RemoveStickman(stickmanBase);
        }

        if (other.CompareTag("Ramp"))
            stickmanBase.StickmanTransform.DOJump(stickmanBase.StickmanTransform.position, 1f, 1, 1f)
                .SetEase(Ease.Flash);
        if (other.CompareTag("Stair"))
        {
            transform.parent.parent = null;
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = GetComponent<Collider>().isTrigger = false;
            stickmanBase.Animator1.SetBool("run", false);

            if (!AnimatedCamera.Instance.GetCameraStatus())
                AnimatedCamera.Instance.StartFinalView();

            if (stickmenHolder.transform.childCount == 1)
            {
                other.GetComponent<Renderer>().material.DOColor(new Color(0.4f, 0.98f, 0.65f), 0.5f)
                    .SetLoops(1000, LoopType.Yoyo)
                    .SetEase(Ease.Flash);
                GamestagesFSM.Instance.Finish();
            }
        }

        if (other.CompareTag("Spikes"))
        {
            stickmanBase.Blood.SetActive(true);

            stickmenHolder.RemoveStickman(stickmanBase);
        }
    }
}