using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NaveTopDownCore : MonoBehaviour
{
    public static NaveTopDownCore Instance;
    public UnityEvent OnStartGame, OnFinishGame;

    public GameObject playerPrefab;
    public GameObject[] enemiesPrefab;


    public bool inGame;
    public int currentScore, highScore;
    public UnityEvent OnUpdateScore;
    public GameObject coinPrefab;

    public float TimeToSpawnEnemy;
    public float CurrentTimeToSpawnEnemy;



    protected void Awake()
    {
        Instance = this;

        highScore = PlayerPrefs.GetInt("highScore");

    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (inGame)
        {
            if (CurrentTimeToSpawnEnemy < TimeToSpawnEnemy)
            {
                CurrentTimeToSpawnEnemy += Time.deltaTime;
            }
            else
            {
                if (Random.Range(0, 100) > 80)
                {
                    SpawnEnemy();
                    SpawnCoin();
                }
                else
                {
                    SpawnEnemy();
                }

                CurrentTimeToSpawnEnemy = 0;
                TimeToSpawnEnemy = Mathf.Clamp(
                    
                    3 - Mathf.Log((currentScore/200f)+1, 2.72f), 1f, 3f
                    );
            }
        }
    }


    [ContextMenu("StartGame")]
    public void StartGame()
    {
        Ship newShip = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Ship>();
        newShip.OnDead.AddListener(FinishGame);
        newShip.Born();

        inGame = true;

        OnStartGame?.Invoke();

    }

    public void SpawnCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-40, 41), 0, Random.Range(-20, 21)), Quaternion.identity).transform.localEulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public void SpawnEnemy()
    {
        Ship newShip = Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)], new Vector3(Random.Range(-40,41),0, Random.Range(-20, 21)), Quaternion.identity).GetComponent<Ship>();
        newShip.transform.localEulerAngles = new Vector3(0,Random.Range(0,360),0);


        newShip.Born();
    }

    public void FinishGame()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;

            PlayerPrefs.SetInt("highScore", highScore);
        }

        OnFinishGame?.Invoke();
    }

    public void CollectPoints(int points)
    {
        currentScore += points;
        OnUpdateScore?.Invoke();
}
}
