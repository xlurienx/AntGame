using UnityEngine;



public class ant : MonoBehaviour
{
[SerializeField]
public GameObject[] ItemPrefab;
public float Timer = 1;
    
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
