using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private StickmenFormatter stickmenFormatter;
    [SerializeField] private StickmenHolder stickmenHolder;
    [SerializeField] private StickmenHolder enemy;

    #region Singleton

    private static PlayerAttacker _instance;
    public static PlayerAttacker Instance => _instance;


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


    private void Update()
    {
        if (GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Attacking && enemy != null)
            AttackEnemy();
    }

    public void StartAttack(StickmenHolder enemy)
    {
        this.enemy = enemy;
    }

    private void AttackEnemy()
    {
        var enemyTransform = enemy.transform;
        var enemyDirection = new Vector3(enemyTransform.position.x, transform.position.y, enemyTransform.position.z) -
                             transform.position;

        for (int i = 0; i < stickmenHolder.GetAmount(); i++)
        {
            stickmenHolder.GetStickMan(i).StickmanTransform.rotation =
                Quaternion.Slerp(stickmenHolder.GetStickMan(i).StickmanTransform.rotation,
                    Quaternion.LookRotation(enemyDirection, Vector3.up), Time.deltaTime * 3f);
        }

        if (enemy.GetAmount() > 1)
        {
            for (int i = 0; i < stickmenHolder.GetAmount(); i++)
            {
                var distance = enemy.GetStickMan(0).StickmanTransform.position - transform.GetChild(i).position;

                if (distance.magnitude < 1.5f)
                {
                    stickmenHolder.GetStickMan(i).StickmanTransform.position = Vector3.Lerp(
                        stickmenHolder.GetStickMan(i).StickmanTransform.position,
                        new Vector3(enemy.GetStickMan(0).StickmanTransform.position.x,
                            stickmenHolder.GetStickMan(0).StickmanTransform.position.y,
                            enemy.GetStickMan(0).StickmanTransform.position.z), Time.deltaTime * 1f);
                }
            }
        }
        else
        {
            GamestagesFSM.Instance.Running();


            PlayerMovement.Instance.AccelerateRoadSpeed();


            for (int i = 1; i < stickmenHolder.GetAmount(); i++)
                stickmenHolder.GetStickMan(i).StickmanTransform.rotation = Quaternion.identity;


            enemy.gameObject.SetActive(false);
            stickmenFormatter.FormatStickMan();
        }

        if (enemy.GetAmount() <= 1)
        {
            GamestagesFSM.Instance.Running();

            stickmenFormatter.FormatStickMan();
        }
    }
}