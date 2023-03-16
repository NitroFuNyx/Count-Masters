using System.Collections.Generic;
using UnityEngine;

public class StickmenHolder : MonoBehaviour
{
    [SerializeField]private List<StickmanBase> _stickmen;
    [SerializeField] private StickmenCounterPresenter _stickmenCounterPresenter;

    public void AddToList(StickmanBase stickmanBase)
    {
        _stickmen.Add(stickmanBase);
    }
    
    public void RemoveFromList(int index)
    {
        if ( _stickmen.Count < 0) return;

        var stickman = _stickmen[index];
        _stickmen.RemoveAt(index);
        Destroy(stickman.gameObject);
        _stickmenCounterPresenter.DeductStickman();
        _stickmenCounterPresenter.UpdateCounter();

        
    }

    public void RemoveStickman(StickmanBase stickmanBase)
    {
        if (stickmanBase == null || _stickmen.Count < 0) return;
        _stickmen.Remove(stickmanBase);
        Destroy(stickmanBase.gameObject);
        _stickmenCounterPresenter.DeductStickman();
        _stickmenCounterPresenter.UpdateCounter();
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
