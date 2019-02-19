using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggered : MonoBehaviour {
    int zombiesInVillage = 3;
    int zombiesSpawnedInVillage = 0;
    float zombieSpawnTimer = 0;
   public Transform[] zombieSpawnPoints;
   
    

    
    public GameObject zombie;

    void Update()  //  OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {

            if (zombiesSpawnedInVillage < zombiesInVillage)
            {
                if (zombieSpawnTimer > 3)
                {
                    SpawnZombie();
                    zombieSpawnTimer = 0;
                }
                else
                {
                    zombieSpawnTimer += Time.deltaTime;
                }



            }
        }
           
       
        

    }
    
    void SpawnZombie()
    {
        Vector3 randomSpawnPoint = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)].position;
        // Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(-3f, 3f), Random.Range(-10f, 10f));
        
        Instantiate(zombie, randomSpawnPoint, Quaternion.Euler(0, 0, 0));
        zombiesSpawnedInVillage++;
    }
}
