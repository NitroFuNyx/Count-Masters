using DG.Tweening;
using UnityEngine;

public class VictorySreenUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup victoryCanvas;

    private void Start()
    {
        GamestagesFSM.Instance.FinishedChanged += ShowUi;
    }

    private void OnDisable()
    {
        GamestagesFSM.Instance.FinishedChanged -= ShowUi;
    }

    public void ShowUi()
    {
        victoryCanvas.DOFade(1, 0.5f);
        victoryCanvas.interactable = true;
        victoryCanvas.blocksRaycasts = true;
    }
}