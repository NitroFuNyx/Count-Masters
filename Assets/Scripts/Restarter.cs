using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restarter : MonoBehaviour
{
     private Button restartButton;
    private void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(Restart); 

    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(Restart); 

    }


    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
