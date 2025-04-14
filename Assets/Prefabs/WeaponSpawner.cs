using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private WeaponData[] itemsToSpawn;
    [SerializeField] private BoxCollider2D spawnArea;

    private Vector2 GetRandomPositionInArea()
    {
        Vector2 center = spawnArea.bounds.center;
        Vector2 size = spawnArea.bounds.size;
        
        float x = Random.Range(-size.x / 2, size.x / 2);
        float y = Random.Range(-size.y / 2, size.y / 2);
        
        return center + new Vector2(x, y);
    }

    public GameObject SpawnItem(WeaponData data, Vector2 position)
    {
        if (data == null || collectablePrefab == null)  return null;
        
        GameObject item = Instantiate(collectablePrefab, position, Quaternion.identity);
        CollectableWeapon collectable = item.GetComponent<CollectableWeapon>();
        SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();

        if (collectable != null)
        {
            collectable.SetWeaponData(data);
        }

        if (spriteRenderer != null && data.sprite != null)
        {
            spriteRenderer.sprite = data.sprite;
        }
        
        return item;
    }

    public void SpawnRandomItemInArea()
    {
        if (itemsToSpawn == null || itemsToSpawn.Length == 0 || spawnArea == null)
        {
            Debug.LogWarning("No items to spawn or area is undefined");
        }
        WeaponData randomItem =  itemsToSpawn[Random.Range(0, itemsToSpawn.Length)];
        Vector2 randomPosition = GetRandomPositionInArea();
        SpawnItem(randomItem, randomPosition);
    }
}
