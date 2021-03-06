using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawning();
        }
    }

    private void Spawning()
    {
        Attacker newAttacker = Instantiate(attackerPrefab,
                                           transform.position,
                                           transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
