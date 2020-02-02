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

    public Canvas myCanvas;

    private bool gameDone;
    private bool canSpawnWeather = true;
    private bool canSpawnObstacle = true;
    private bool canSpawnCloud = true;
    private bool canSpawnParticle = true;

    public Text[] weatherWarnings;

    // Start is called before the first frame update
    void Start()
    {
        gameDone = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            if (canSpawnCloud)
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
        Instantiate(weatherWarnings[weatherType], myCanvas.transform);
        yield return new WaitForSecondsRealtime(5);
        StartCoroutine(SpawnWeather(weatherType));
    }

    IEnumerator SpawnWeather(int weatherType)
    {
        Instantiate(weatherEvents[weatherType]);

        int time = Random.Range(10, 20);
        yield return new WaitForSecondsRealtime(time);
        canSpawnWeather = true;
    }

    int weatherRoulette()
    {
        int weatherNum = Random.Range(0, 2);
        return weatherNum;
    }

    IEnumerator SpawnObstacles(int type)
    {
        Vector3 position = new Vector3(Random.Range(-7.59f, 7.14f), 10.01f, 0.0f);
        Instantiate(obstacles[type], position, Quaternion.identity);
        int time = Random.Range(2, 5);
        yield return new WaitForSecondsRealtime(time);
        canSpawnObstacle = true;
    }

    IEnumerator SpawnCloud()
    {
        Vector3 position = new Vector3(Random.Range(-7.59f, 7.14f), 10.01f, 0.0f);
        Instantiate(cloud, position, Quaternion.identity);
        int time = Random.Range(1, 2);
        yield return new WaitForSecondsRealtime(1);
        canSpawnCloud = true;
    }

    IEnumerator SpawnParticles(int type)
    {
        Vector3 position = new Vector3(Random.Range(-7.59f, 7.14f), 10.01f, 0.0f);
        Instantiate(particles[type], position, Quaternion.identity);
        int time = Random.Range(1, 2);
        yield return new WaitForSecondsRealtime(time);
        canSpawnParticle = true;
    }


}
