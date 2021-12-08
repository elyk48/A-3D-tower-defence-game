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
    private int maxwave = 3;
   /// <summary>
   /// UI  text wave count down
   /// </summary>
    public Text waveCountDownText;

    private void Update()
    {

        if (countdown <= 0f)
        {
            if( maxwave !=waveIndex)
            StartCoroutine(SpawnWave());

            countdown = timeBtweenWaves;

        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns> an IEnumrator </returns>
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
