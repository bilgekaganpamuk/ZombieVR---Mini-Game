using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    public GameObject[] Spawnpoints;
    public GameObject[] ZombiePrefabs;
    private int index;
    private int indexcube;

    public float timeRate;

    public static ZombieSpawnManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(CreateZombies());
          
    }


    private IEnumerator CreateZombies()
    {
        while (true)
        {
            index = Random.Range(0, 7);
            indexcube = Random.Range(0, 2);
            GameObject cube = Instantiate(ZombiePrefabs[indexcube], Spawnpoints[index].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            cube.transform.SetParent(transform);
            yield return new WaitForSeconds(timeRate);
            if (timeRate > 0.28)
            {
                timeRate = timeRate - 0.005f;
            }
            }
    }
 
}
