using UnityEngine;

public class PlayerCollidersHandler : MonoBehaviour
{
    [SerializeField] private StickmenFormatter stickmenFormatter;
    [SerializeField] private GameObject cameraTwo;
    [SerializeField] private StickmenCounterPresenter stickmenCounterPresenter;

    #region Singleton

    private static PlayerCollidersHandler _instance;
    public static PlayerCollidersHandler Instance => _instance;


    private void OnEnable()
    {
        if (Instance == null)
        {
            _instance = this;
        }
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    #endregion


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.transform;

            PlayerMovement.Instance.SlowRoadSpeed();
            GamestagesFSM.Instance.Attacking();
            PlayerAttacker.Instance.StartAttack(other.GetComponent<StickmenHolder>());
            other.GetComponent<EnemyAttacker>().StartAttack(transform.GetComponent<StickmenHolder>());

            // other.transform.GetChild(1).GetComponent<enemyManager>().AttackThem(transform);
        }
        else if (other.CompareTag("Formatter"))
        {
            stickmenFormatter.FormatStickMan();
        }

        else if (other.CompareTag("FinishLine"))
        {
            cameraTwo.SetActive(true);
            HumanTowerBuilder.Instance.CreateTower();
            GamestagesFSM.Instance.CreatingTower();
            stickmenCounterPresenter.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerMovement.Instance.AccelerateRoadSpeed();
            GamestagesFSM.Instance.Running();
            stickmenFormatter.FormatStickMan();


            // other.transform.GetChild(1).GetComponent<enemyManager>().AttackThem(transform);
        }
    }
}