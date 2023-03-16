using UnityEngine;

public class ParentChanger : MonoBehaviour
{
    [SerializeField] private Transform myTransform;

    private void Awake()
    {
        myTransform.parent = RoadSingleton.Instance.transform;
    }
}
