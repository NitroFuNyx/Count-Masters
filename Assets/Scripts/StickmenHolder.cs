using System.Collections.Generic;
using UnityEngine;

public class StickmenHolder : MonoBehaviour
{
    
    [SerializeField] private List<StickmanBase> _stickmen;
    [SerializeField] private StickmenCounterPresenter _stickmenCounterPresenter;
    
    public void AddToList(StickmanBase stickmanBase)
    {
        _stickmen.Add(stickmanBase);
    }

    public void RemoveFromList(int index)
    {
        

        var stickman = _stickmen[index];
        _stickmen.RemoveAt(index);
        Destroy(stickman.gameObject);
        _stickmenCounterPresenter.DeductStickman();
        _stickmenCounterPresenter.UpdateCounter();
        if (_stickmen.Count <= 0&&gameObject.CompareTag("Player"))
        {
            GamestagesFSM.Instance.Loose();
        }
    }

    public void RemoveStickman(StickmanBase stickmanBase)
    {
        if (stickmanBase == null) return;
            

        _stickmen.Remove(stickmanBase);
        Destroy(stickmanBase.gameObject);
        _stickmenCounterPresenter.DeductStickman();
        _stickmenCounterPresenter.UpdateCounter();
        if (_stickmen.Count <= 0&&gameObject.CompareTag("Player"))
        {
            GamestagesFSM.Instance.Loose();

        }
    }

    public StickmanBase GetStickMan(int index)
    {
        return _stickmen[index];
    }

    public int GetAmount()
    {
        return _stickmen.Count;
    }
}