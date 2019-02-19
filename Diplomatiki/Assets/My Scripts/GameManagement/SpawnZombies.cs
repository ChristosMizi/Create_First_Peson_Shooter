using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour {

    public Transform spawnpoint;
    public GameObject zombie;
    public float delayTime = 4f;

    IEnumerator Start()
    {
        var obj = Instantiate(zombie, spawnpoint.position, spawnpoint.rotation) as GameObject;
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(Start());
    }
}
