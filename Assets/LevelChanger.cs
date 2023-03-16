using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    private Button _victoryButton;

    private void Start()
    {
        _victoryButton = GetComponent<Button>();
        _victoryButton.onClick.AddListener(SwitchScene);
    }

    private void SwitchScene()
    {
        if ((SceneManager.GetActiveScene().buildIndex +1 <= SceneManager.sceneCount+1))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);
    }
}