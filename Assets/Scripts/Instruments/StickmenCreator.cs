using UnityEngine;

public class StickmenCreator : MonoBehaviour
{
    [SerializeField] private StickmanBase stickmanBasePrefab;
    [SerializeField] private StickmenFormatter stickmenFormatter;
    [SerializeField] private StickmenCounterPresenter stickmenCounterPresenter;
    [SerializeField] private StickmenHolder stickmenHolder;

    [Space] [Header("Enemy spawner parameters")] [SerializeField]
    private bool isEnemy;

    [SerializeField] private int minEnemyAmount;
    [SerializeField] private int maxEnemyAmount;

    private void Awake()
    {
        if (!isEnemy)
            CreateStickman(stickmenCounterPresenter.GetStickmenAmount() - 1);
        else
        {
            var newAmount = Random.Range(minEnemyAmount, maxEnemyAmount % 2 == 0 ? maxEnemyAmount : maxEnemyAmount + 1);
            stickmenCounterPresenter.GainStickmen(newAmount, Operations.Plus);
            CreateStickman(newAmount);
        }
    }

    public void CreateStickman(int amount)
    {
        if (amount <= 0) return;
        for (int i = 0; i < amount; i++)
        {
            var stickman = Instantiate(stickmanBasePrefab, transform.position, gameObject.transform.rotation,
                transform);
            stickman.StickmenColliderHandler.SetHolder(stickmenHolder);
            stickman.StickmenColliderHandler.SetCounter(stickmenCounterPresenter);
            stickmenHolder.AddToList(stickman);
            stickmenCounterPresenter.UpdateCounter();
        }

        stickmenFormatter.FormatStickMan();
    }
}