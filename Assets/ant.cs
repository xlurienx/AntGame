using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string Name;
    public GameObject ItemPrefab;
    [Range (0f, 100f)]public float Chance = 100f;

    [HideInInspector] public double _weight;

}

public class ant : MonoBehaviour
{
[SerializeField]
public GameObject[] ItemPrefab;
public float Timer = 1;

    private double accumulatedWeights;
    private System.Random rand = new System.Random();

    private void Awake()
    {
        CalculateWeights ();
    }
    private void Start()
    {
        for (int i = 0; i < 0; i++)
            SpawnRandomEnemy(new Vector2(Random.Range(-3f, 3f), Random.Range(-4f, 4f)));
    }

    private void SpawnRandomEnemy (Vector2 position)
    {
        Enemy randomEnemy = ItemPrefab [GetRandomEnemyIndex()];

        Instantiate(randomEnemy.ItemPrefab, position, Quaternion.identity, transform);
    }

    private int GetRandomEnemyIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;
        for (int i = 0; i < ItemPrefab.Length; i++)
            if (ItemPrefab[i].weight >= r)
                return i;
        return 0;
        
    }
    private void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach (Enemy ItemPrefab in ItemPrefab)
        {
            accumulatedWeights += ItemPrefab.Chance;
            ItemPrefab._weight = accumulatedWeights;

        }
    }
    void Update()
    {
        Timer -= Time.deltaTime;
    if (Timer <= 0)
    {
            GameObject prefab = ItemPrefab[Random.Range(0, ItemPrefab.Length)];
            Vector3 where = new Vector3(Random.Range(-8f, 8f),
            Random.Range(-4f, 4f), 0);
        Instantiate(prefab, where, Quaternion.identity);
        Timer = 1;
    }
        
    }
}
