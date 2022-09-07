using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave 
    {
        public Transform    enemy;
        public int          count;
        public float        spawn_rate;
    }

    public  Wave[]  waves;
    private int     nextwave = 0;

    public Transform[] spawnpoints;

    public  float   time_between_waves = 6f;
    public  float   wave_countdown;
    private float   search_countdown = 1f;

    private SpawnState  spawnstate = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        if (waves.Length == 0)
            Debug.LogError ("Waves are not initialized!");

        if (spawnpoints.Length == 0)
            Debug.LogError("Spawn points are not initialized!");

        wave_countdown = time_between_waves;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnstate == SpawnState.WAITING) {

            if (!AreEnemiesAlive ()) { 
            
            } else {
                return;
            }
        }

        if (wave_countdown <= 0) { 
        
            if (spawnstate != SpawnState.SPAWNING) {

                StartCoroutine(SpawnWave(waves[nextwave]));
            }
        } else {

            wave_countdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave (Wave pWave)
    {
        spawnstate = SpawnState.SPAWNING;

        for (int i = 0; i < pWave.count; ++i)
        {
            SpawnEnemy (pWave.enemy);
            yield return new WaitForSeconds(1f / pWave.spawn_rate);
        }

        spawnstate = SpawnState.WAITING;

        yield break;
    }

    bool AreEnemiesAlive ()
    {
        search_countdown -= Time.deltaTime;

        if (search_countdown == 0) {

            search_countdown = 1f;
            return (GameObject.FindGameObjectsWithTag("Enemy") != null);
        }

        return true;
    }

    void WaveReset ()
    {
        spawnstate = SpawnState.COUNTING;
        wave_countdown = time_between_waves;

        ++nextwave;

        if (nextwave == waves.Length) {

            nextwave = 0;
            // game completed.
        }
    }

    void SpawnEnemy (Transform pEnemy)
    {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];

        Instantiate(pEnemy, spawnpoint.position, spawnpoint.rotation);
    }
}
