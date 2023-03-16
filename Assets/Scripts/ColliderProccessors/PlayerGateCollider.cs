using UnityEngine;

public class PlayerGateCollider : MonoBehaviour
{
    [SerializeField] private StickmenCounterPresenter stickmenCounterPresenter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            var parent = other.transform.parent;
            parent.GetComponent<GatesCollidersHandler>().DisableGate();

            var gateManager = other.GetComponent<GatePreSetter>();

            var lastAmount = stickmenCounterPresenter.GetStickmenAmount();

            stickmenCounterPresenter.GainStickmen(gateManager.GetGateNumber(), gateManager.GetOperation());
            GetComponent<StickmenCreator>().CreateStickman(stickmenCounterPresenter.GetStickmenAmount() - lastAmount);
        }
    }
}