using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
 
    public GameObject[] gases;
    public GameObject[] weatherEvents;

    public Text pointsText;
    public Text rainAnnounce;
    public Text hailAnnounce;

    private bool gameDone;
    private bool canSpawnWeather = true;

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
        int weatherType = weatherRoulette();


        if (!gameDone)
        {
            updatePoints();
            if (canSpawnWeather)
            {
                canSpawnWeather = false;
                StartCoroutine(SpawnWeather(weatherType));
            }
        }
    }

    void updatePoints()
    {
        pointsText.text = "Points: " + particlePoints.ToString();
    }

    IEnumerator SpawnWeather(int weatherType)
    {
        print(weatherType);
        int time = Random.Range(20,30);
        Instantiate(weatherEvents[weatherType]);
        yield return new WaitForSecondsRealtime(time);
        canSpawnWeather = true;
    }

    int weatherRoulette()
    {
        int weatherNum = Random.Range(0, 2);
        return weatherNum;
    }

    /*void weatherAnnounce(int type)
    {
        if (type == 0)
        {
            hailAnnounce.text = "It's about to hail!";
        }
        else if (type == 1)
        {
            rainAnnounce.text = "It's about to rain!";
        }
    }*/
}
