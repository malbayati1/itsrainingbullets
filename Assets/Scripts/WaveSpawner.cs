using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { spawning, waiting, counting };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemies;
        public int count;
        public float rate;
    }

    public Camera cam;
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.counting;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;

    }

    // Update is called once per frame
    void Update()
    {
        if(state == SpawnState.waiting)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
                waveCountdown = timeBetweenWaves;
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.counting;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves complete. Looping");
        }
        else
        {
            nextWave++;
         //   _enemy.speed *= 1.5f;
         //   _enemy.health += 2;
        
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.spawning;
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemies[Random.Range(0,_wave.enemies.Length)]);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.waiting;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //float height = cam.orthographicSize + 2;
        //float width = cam.orthographicSize * cam.aspect + 2;
        float height = cam.orthographicSize; //Spawns within camera
        float width = cam.orthographicSize * cam.aspect;
        Instantiate(_enemy, new Vector3(Random.Range(-width,width), Random.Range(-height, height), 0), Quaternion.identity);
        Debug.Log("Spawning Enemy: " + _enemy.name);
    }

}
