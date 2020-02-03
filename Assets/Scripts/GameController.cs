using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] weatherEvents;
    public GameObject[] obstacles;
    public GameObject[] particles;
    public GameObject cloud;
    public GameObject thunder;

    public int thunderBuffer;
    public int timeSinceLoad;
    public Canvas myCanvas;

    private bool gameDone;
    private bool canSpawnWeather = true;
    private bool canSpawnObstacle = true;
    private bool canSpawnCloud = true;
    private bool canSpawnParticle = true;
    private bool canSpawnThunder = false;

    public GameObject[] weatherWarnings;

    // Start is called before the first frame update
    void Start()
    {
        gameDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLoad = (int)Time.timeSinceLevelLoad;
        
        if (!gameDone)
        {
            if (canSpawnWeather)
            {
                int weatherType = weatherRoulette();
                canSpawnWeather = false;
                StartCoroutine(SpawnWeatherWarning(weatherType));
            }

            if (canSpawnObstacle)
            {
                int particleType = Random.Range(0, 2);
                canSpawnObstacle = false;
                StartCoroutine(SpawnObstacles(particleType));
            }
            if (canSpawnCloud && !canSpawnThunder)
            {
                canSpawnCloud = false;
                StartCoroutine(SpawnCloud());
            }
            if (canSpawnParticle)
            {
                int particleType = Random.Range(0, 4);
                canSpawnParticle = false;
                StartCoroutine(SpawnParticles(particleType));
            }
        }
    }

    IEnumerator SpawnWeatherWarning(int weatherType)
    {
        Instantiate(weatherWarnings[weatherType]);
        yield return new WaitForSecondsRealtime(5);
        StartCoroutine(SpawnWeather(2));
    }

    IEnumerator SpawnWeather(int weatherType)
    {
        if(weatherType < 2)
        {
            Instantiate(weatherEvents[weatherType]);
        }
        else
        {
            canSpawnThunder = true;
            Instantiate(weatherEvents[0]);
            InvokeRepeating("SpawnThunder", 0, 1);
        }

        int time = Random.Range(10, 20);
        yield return new WaitForSecondsRealtime(time);
        canSpawnWeather = true;
        canSpawnThunder = false;
    }

    void SpawnThunder()
    {
        if (canSpawnThunder)
        {
            Vector3 position = new Vector3(Random.Range(-1.8f, 2.15f), 8.01f, 0.0f);
            Instantiate(thunder, position, Quaternion.identity);
        }
        else
        {
            CancelInvoke("SpawnThunder");
        }
    }

    int weatherRoulette()
    {
        int weatherNum = Random.Range(0, 3);
        Debug.Log(weatherNum.ToString());
        return weatherNum;
    }

    IEnumerator SpawnObstacles(int type)
    {
        Vector3 position = new Vector3(Random.Range(-1.8f, 2.15f), 10.01f, 0.0f);
        Instantiate(obstacles[type], position, Quaternion.identity);
        int time = Random.Range(2, 3);
        yield return new WaitForSecondsRealtime(time);
        canSpawnObstacle = true;
    }

    IEnumerator SpawnCloud()
    {
        Vector3 position = new Vector3(Random.Range(-1.8f, 3.14f), 10.01f, 1.0f);
        Instantiate(cloud, position, Quaternion.identity);
        int time = Random.Range(1, 2);
        yield return new WaitForSecondsRealtime(1);
        canSpawnCloud = true;
    }

    IEnumerator SpawnParticles(int type)
    {
        Vector3 position = new Vector3(Random.Range(-1.8f, 2.15f), 10.01f, 0.0f);
        Instantiate(particles[type], position, Quaternion.identity);
        int time = Random.Range(1, 2);
        yield return new WaitForSecondsRealtime(time);
        canSpawnParticle = true;
    }


}
