using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
 
    public GameObject[] gases;
    public GameObject[] weatherEvents;
    public GameObject[] obstacles;
    public GameObject cow;

    public Canvas myCanvas;
    public Text pointsText;
    public Text rainAnnounce;
    public Text hailAnnounce;

    private bool gameDone;
    private bool canSpawnWeather = true;
    private bool canSpawnObstacle = true;

    public Text[] weatherWarnings;

    private int particlePoints;
    // Start is called before the first frame update
    void Start()
    {
        gameDone = false;
        particlePoints = 0;
        pointsText.text = "Points: " + particlePoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameDone)
        {
            updatePoints();
            if (canSpawnWeather)
            {
                int weatherType = weatherRoulette();
                canSpawnWeather = false;
                StartCoroutine(SpawnWeatherWarning(weatherType));
            }

            if (canSpawnObstacle)
            {
                canSpawnObstacle = false;
                StartCoroutine(SpawnCow());
            }
        }
    }

    void updatePoints()
    {
        pointsText.text = "Points: " + particlePoints.ToString();
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

    IEnumerator SpawnCow()
    {
        Vector3 position = new Vector3(Random.Range(-7.59f, 7.14f), 30.2f, 0.0f);
        Instantiate(cow, position, Quaternion.identity);
        int time = Random.Range(2, 5);
        yield return new WaitForSecondsRealtime(time);
        canSpawnObstacle = true;
    }

}
