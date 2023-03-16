using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collect()
    {
        gameObject.SetActive(false);
        PlayerResourcesHolder.Instance.AddCoins(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
         Collect();
    }
}
