using DG.Tweening;
using UnityEngine;
using WSWhitehouse.TagSelector;

public class StickmanColliderHandler : MonoBehaviour
{
    [TagSelector] public string stickmanTag = "";
    [SerializeField] private Stickman stickman;

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
            if (stickmenHolder == null || stickman == null) return;
            _collided = true;
            stickmenHolder.RemoveStickman(stickman);
        }

        if (other.CompareTag("Ramp"))
            stickman.StickmanTransform.DOJump(stickman.StickmanTransform.position, 1f, 1, 1f).SetEase(Ease.Flash);
    }
}