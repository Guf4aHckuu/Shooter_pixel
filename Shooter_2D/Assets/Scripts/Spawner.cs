using System.Collections;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string name;
    public EnemyController enemyType;
    public int count;
    public float rate;
}
public class Spawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING}
    public SpawnState state = SpawnState.COUNTING;
    public Wave[] Waves;
    public float TimeBetweenWaves = 3f;
    public float waveCountDown;
    [SerializeField] private float _timeBevorNextWaveMax;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _playerPos;
    private float _timeBevorNextWave;
    private int _nextWave = 0;
    private int _numberOfWave = 1;

    private void Start()
    {
        if(_spawnPoints.Length == 0)
        {
            Debug.LogError("No spawner");
        }
        _timeBevorNextWave = _timeBevorNextWaveMax;
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            _timeBevorNextWave -= Time.deltaTime;
            if (!GameObject.FindGameObjectWithTag("Enemy") || _timeBevorNextWave <= 0f)
            {
                WaveCompleted();
                _numberOfWave++;
                Waves[_nextWave].count += 2; //+2 Genger jeden weiteren Angriff
                _timeBevorNextWave = _timeBevorNextWaveMax;
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(Waves[_nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log("Spawning wave" + wave.name);
        state = SpawnState.SPAWNING;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyType);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        state = SpawnState.WAITING;
    }

    private void SpawnEnemy(EnemyController enemyController)
    {
        Transform spawner = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        var enemy = Instantiate(enemyController, spawner.position, spawner.rotation);
        enemy.ConstructSpawner(_playerPos);
        Debug.Log("Spawing enemy: " + enemy.name);
    }

    private void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        waveCountDown = TimeBetweenWaves;

        if (_nextWave + 1 > Waves.Length - 1)
        {
            _nextWave = 0;
            Debug.Log("all waves complited!");
        }
        else
        {
            _nextWave++;
        }
    }
}
