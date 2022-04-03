using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    int enemyPoolSize = 10;
    List<GameObject> enemyLst = new List<GameObject>();

    private void Awake()
    {
        for(int i = 0; i < enemyPoolSize; i ++)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.SetActive(false);
            enemyLst.Add(newEnemy);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
