using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GatePreSetter : MonoBehaviour
{
    [SerializeField] private TextMeshPro gateText;

    private Operations _operation;
    private int _gateNumber;
    private string _finalText;

    private void Awake()
    {
        var operation = Random.Range(0, 2);
        switch (operation)
        {
            case 0:
                _finalText = "x";
                _operation = Operations.Multiply;
                _gateNumber = Random.Range(1, 4);
                break;
            case 1:
                _finalText = "+";
                _operation = Operations.Plus;
                _gateNumber = Random.Range(1, 65);
                break;
            default:
                throw new Exception("impossible value reached");
        }

        if (_gateNumber % 2 == 0) _gateNumber++;

        _finalText += _gateNumber.ToString();
        gateText.text = _finalText;
    }

    public Operations GetOperation()
    {
        return _operation;
    }

    public int GetGateNumber()
    {
        return _gateNumber;
    }
}