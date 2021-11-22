using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class wave_mannager : MonoBehaviour
{
    public float SecToWaitEnemy=0.5f;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBtweenWaves = 10.5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    ////////Ui///////
    public Text waveCountDownText;

    private void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBtweenWaves;

        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }


    IEnumerator SpawnWave()
    {

        Debug.Log("wave coming !!!");
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(SecToWaitEnemy) ;
        }
        
    }

    void SpawnEnemy()
    {

        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }

}
