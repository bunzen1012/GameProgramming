using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] private Life playerLife;
    //[SerializeField] private Life playerBaseLife;

    private void Awake()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        //playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
    }

    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void CheckWinCondition()
    {
        if (EnemyManager.instance.enemies.Count <= 0 && WaveManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        //playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
        EnemyManager.instance.onChanged.AddListener(CheckWinCondition);
        WaveManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (EnemyManager.instance.enemies.Count <= 0 && WaveManager.instance.waves.Count<=0)
    //    {
    //        SceneManager.LoadScene("WinScreen");
    //    }
    //
    //    if (playerLife.amount <=0)
    //    {
    //       SceneManager.LoadScene("LoseScreen");
    //    }
    //}
}
