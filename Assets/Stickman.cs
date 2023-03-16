using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] private StickmanColliderHandler stickmenColliderHandler;
    [SerializeField] private Transform stickmanTransform;
    [SerializeField] private StickmenFormatter stickmenFormatter;
    public StickmanColliderHandler StickmenColliderHandler => stickmenColliderHandler;

    public Transform StickmanTransform => stickmanTransform;

    public StickmenFormatter Formatter => stickmenFormatter;
}
