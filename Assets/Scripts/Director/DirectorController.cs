using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorController : MonoBehaviour
{
    public GameObject stalker;
    public GameObject wizard;
    public GameObject player;

    float timer = 0.0f;

    public float maxGeneration;
    public float generationTime;
    public float spawnRange;
    public int stalkerChance;
    public int wizardChance;


    int enemyCount = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= generationTime)
        {
            GameObject[] enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemyCount.Length < maxGeneration )
            {
                int random = Random.Range(0, stalkerChance + wizardChance);
                GameObject enemy = null;
                if (random < stalkerChance)
                    enemy = Instantiate(stalker);
                else
                    enemy = Instantiate(wizard);
                enemy.transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), 50, Random.Range(-spawnRange, spawnRange));
            }
            
            timer = 0.0f;
        }
    }
}
