using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GeneratinObstacles : MonoBehaviour {

    public GameObject[] asteroidPrefab;
    public GameObject[] wingsPrefab;
    public GameObject coinsPreab;
    public Transform spawnXPosition;
    public float spawnTopPosition;
    public float spawnMidPosition;
    public float spawnBottomPosition;
    public float timer;

    private float time;
    private int namberPaternAsteroid;
    private int namberPaternCoins;
    private int typeObstacle;
    private bool isStartCorutine = false;
    //private List<int> preObstacleType = new List<int>();
    private int preObstacleType;
    private bool isSpawn = false;


    void Start () {
        time = timer;
    }
	void Update () {
        if (GameControl.instance.gameOver == false && GameControl.instance.isStart == true)
        {
            if (timer <= time)
            { 
                namberPaternAsteroid = Random.Range(1, 4);
                GenerationAsteroid(namberPaternAsteroid);
                //preObstacleType.Add(typeObstacle);
                GenerationCoins(Random.Range(1, 4));
                //if (isStartCorutine == false)
                //StartCoroutine(ObstacleControl());
            }
            else
            {
                time += Time.deltaTime * GameControl.instance.scrollSpeed;
            }
        }
    }
    private void GenerationCoins(int probability)
    {
        //Доджим астероиды монеткой
        if (namberPaternAsteroid != 2)
            if (namberPaternAsteroid == 1)
                namberPaternCoins = 2;
            else
                namberPaternCoins = 1;
        //
        if (probability == 1)
        {
            float yPosition = 0f;
            switch (namberPaternCoins)
            {
                case 1:
                    yPosition = spawnTopPosition;
                    break;
                case 2:
                    yPosition = spawnBottomPosition;
                    break;
            }
            Instantiate(coinsPreab, new Vector2(spawnXPosition.position.x, Random.Range(yPosition, yPosition)), Quaternion.identity);
        }
    }
    void GenerationAsteroid(int numberPattern)
    {
        float yPosition = 0f;
        switch (numberPattern)
        {
            case 1:
                yPosition = spawnTopPosition;
                break;
            case 2:
                yPosition = spawnMidPosition;
                break;
            case 3:
                yPosition = spawnBottomPosition;
                break;
        }
        
        Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], new Vector2(Random.Range(spawnXPosition.position.x - 1f, spawnXPosition.position.x + 1f), Random.Range(yPosition - 1f, yPosition + 1f)), Quaternion.identity);
        time = 0;
    }
    //void GenerationWing(int numberPattern)
    //{
    //    switch (numberPattern)
    //    {
    //        case 1:
    //            Instantiate(wingsPrefab[0], new Vector2(spawnXPosition.position.x, 1.91f), Quaternion.Euler(0, 0, 0));
    //            break;
    //        case 2:
    //            Instantiate(wingsPrefab[1], new Vector2(spawnXPosition.position.x, -2.8f), Quaternion.Euler(0, 0, 180));
    //            break;
    //    }
        
    //    time = 0;
    //}
    //IEnumerator ObstacleControl()
    //{

    //    isStartCorutine = true;

    //    typeObstacle = Random.Range(1, 11);
    //    if (typeObstacle == 10)
    //    {
    //        if (preObstacleType.Count == 10)
    //        {
    //            print("return");
    //            isStartCorutine = false;
    //            yield break;
    //        }
    //        yield return new WaitForSeconds(0.3f);
    //        GenerationWing(Random.Range(1, 3));
    //        preObstacleType.Add(typeObstacle);
    //        yield return new WaitForSeconds(0.6f);
    //    }
    //    else
    //    {
    //        namberPaternAsteroid = Random.Range(1, 4);
    //        GenerationAsteroid(namberPaternAsteroid);
    //        preObstacleType.Add(typeObstacle);
    //        GenerationCoins(Random.Range(1, 4));
    //    }

    //    isStartCorutine = false;
    //}
}
