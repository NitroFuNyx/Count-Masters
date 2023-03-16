using System;
using UnityEngine;

public class StickmenCounter : MonoBehaviour
{
    [SerializeField] private int stickmenAmount;

    public event Action OnAmountChange;


    public void GainStickmen(int value,Operations symbol)
    {

        switch (symbol)
        {
            
            case Operations.Multiply:
                stickmenAmount *=value;
                break;
            case Operations.Plus:
                stickmenAmount += value;
                break;

        }

        OnAmountChange?.Invoke();
    }

    public void DeductStickman()
    {
        stickmenAmount--;
    }
    public int GetStickmenAmount()
    {
        return stickmenAmount;
    }
}