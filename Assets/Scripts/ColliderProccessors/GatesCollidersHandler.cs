using UnityEngine;

public class GatesCollidersHandler : MonoBehaviour
{
    [SerializeField] private BoxCollider boxColliderGate1;
    [SerializeField] private BoxCollider boxColliderGate2;

    public void DisableGate()
    {
        boxColliderGate1.enabled = false;
        boxColliderGate2.enabled = false;
    }
}
