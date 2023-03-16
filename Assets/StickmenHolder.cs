using System.Collections.Generic;
using UnityEngine;

public class StickmenHolder : MonoBehaviour
{
    [SerializeField]private List<Stickman> _stickmen;
    [SerializeField] private StickmenCounterPresenter _stickmenCounterPresenter;

    public void AddToList(Stickman stickman)
    {
        _stickmen.Add(stickman);
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

    public void RemoveStickman(Stickman stickman)
    {
        if (stickman == null || _stickmen.Count < 0) return;
        _stickmen.Remove(stickman);
        Destroy(stickman.gameObject);
        _stickmenCounterPresenter.DeductStickman();
        _stickmenCounterPresenter.UpdateCounter();
    }
    public Stickman GetStickMan(int index)
    {
        return _stickmen[index];
    }
    public int GetAmount()
    {
       return _stickmen.Count;
    }
}
