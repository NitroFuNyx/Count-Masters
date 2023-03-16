using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    void Start()
    {
        Time.timeScale = 0.25f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;

            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
