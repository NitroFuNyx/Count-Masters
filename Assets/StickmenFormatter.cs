using UnityEngine;
using DG.Tweening;

public class StickmenFormatter : MonoBehaviour
{   
    [SerializeField] private StickmenHolder stickmenHolder;
    [SerializeField] private StickmenCounterPresenter stickmenCounterPresenter;
    [Space]
    [Range(0f, 1f)] [SerializeField] private float distanceFactor;
    [Range(0f, 1f)] [SerializeField] private float radius;
    
    
    public void FormatStickMan()
    {
        for (int i = 0; i < stickmenHolder.GetAmount(); i++)
        {
            var x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            var z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
            
            var newPos = new Vector3(x,-0.023f,z);
            stickmenHolder.GetStickMan(i).StickmanTransform.localRotation= Quaternion.identity;

            stickmenHolder.GetStickMan(i).transform.DOLocalMove(newPos, 0.5f).SetEase(Ease.OutBack);
         stickmenCounterPresenter.UpdateCounter();
        }
    }
}
