using TMPro;
using UnityEngine;

public class StickmenCounterPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshPro counterText;
    [SerializeField] private StickmenCounter counter;


    private void Start()
    {
        counter.OnAmountChange += UpdateCounter;
        UpdateCounter();
    }

    public void GainStickmen(int value, Operations symbol)
    {
        counter.GainStickmen(value, symbol);
    }

    public void DeductStickman()
    {
        counter.DeductStickman();
    }


    public int GetStickmenAmount()
    {
        return counter.GetStickmenAmount();
    }

    public void UpdateCounter()
    {
        counterText.text = GetStickmenAmount().ToString();
    }
}