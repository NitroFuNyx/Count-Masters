using DG.Tweening;
using UnityEngine;

public class LooseScreenUi : MonoBehaviour
{
    [SerializeField] private CanvasGroup looseCanvas;

    private void Start()
    {
        GamestagesFSM.Instance.LooseChanged += ShowUi;
    }

    private void OnDisable()
    {
        GamestagesFSM.Instance.LooseChanged -= ShowUi;
    }

    private void ShowUi()
    {
        looseCanvas.DOFade(1, 0.5f);
        looseCanvas.interactable = true;
        looseCanvas.blocksRaycasts = true;
    }
}