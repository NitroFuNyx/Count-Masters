using UnityEngine;

public class RoadSingleton : MonoBehaviour
{
    private static RoadSingleton _instance;

    public static RoadSingleton Instance => _instance;

    private void OnEnable()
    {
        if (Instance == null)
            _instance = this;
        
    }

    private void OnDisable()
    {
        _instance = null;
    }
}
