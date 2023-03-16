using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private StickmenHolder stickmenHolder;
    [SerializeField] private StickmenHolder enemy;
    [SerializeField] private StickmenFormatter stickmenFormatter;

    private bool _attack;

    void Update()
    {
        if (_attack && stickmenHolder.GetAmount() > 1)
        {
            AttackEnemy();
        }
        
    }

    private void AttackEnemy()
    {
        var enemyDirection = enemy.transform.position - transform.position;

        for (int i = 0; i < stickmenHolder.GetAmount(); i++)
        {
            stickmenHolder.GetStickMan(i).StickmanTransform.rotation = Quaternion.Slerp(
                stickmenHolder.GetStickMan(i).StickmanTransform.rotation,
                Quaternion.LookRotation(enemyDirection, Vector3.up), Time.deltaTime * 3f);

            if (enemy.GetAmount() > 1)
            {
                var distance = enemy.GetStickMan(0).StickmanTransform.position -
                               stickmenHolder.GetStickMan(0).StickmanTransform.position;

                if (distance.magnitude < 1.5f)
                {
                    stickmenHolder.GetStickMan(i).StickmanTransform.position = Vector3.Lerp(
                        stickmenHolder.GetStickMan(i).StickmanTransform.position,
                        enemy.GetStickMan(0).StickmanTransform.position, Time.deltaTime * 2f);
                }
            }
        }
        if (enemy.GetAmount() <= 0)
        {
            GamestagesFSM.Instance.Loose();
            _attack = false;
            SetRunAnimation( false);

            stickmenFormatter.FormatStickMan();
        }
    }

    public void StartAttack(StickmenHolder enemy)
    {
        this.enemy = enemy;
        _attack = true;
        SetRunAnimation( true);
    }

    private void SetRunAnimation(bool toggle)
    {
        for (int i = 0; i < stickmenHolder.GetAmount(); i++)
        {
            stickmenHolder.GetStickMan(i).Animator1.SetBool("run",toggle);
        }
    }
}