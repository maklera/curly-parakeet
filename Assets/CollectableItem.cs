using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Collected");
        }
    }
}
