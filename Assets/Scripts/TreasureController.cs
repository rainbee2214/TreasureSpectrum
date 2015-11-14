using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TreasureController : MonoBehaviour
{
    List<Treasure> treasures;
    List<Vector2> treasureLocations;
    List<Rock> rocks;
    List<Vector2> rockLocations;

    public Sprite redGem, blueGem, greenGem, yellowGem;

    public GameObject treasurePrefab;
    public GameObject rockPrefab;

    int size = 5;

    void Start()
    {
        treasures = new List<Treasure>();
        treasureLocations = new List<Vector2>();
        rocks = new List<Rock>();
        rockLocations = new List<Vector2>();
        Debug.Log("....");
        for (int i = 0; i < GameController.controller.CurrentLevelTreasureCount; i++)
        {
            GameObject g = Instantiate(treasurePrefab);
            g.transform.SetParent(transform);
            Treasure treasure = g.AddComponent<Treasure>();
            switch(Random.Range(0,4))
            {
                case 0: treasure.SetColor(FlashlightColor.Red, redGem); break;
                case 1: treasure.SetColor(FlashlightColor.Blue, blueGem); break;
                case 2: treasure.SetColor(FlashlightColor.Green, greenGem); break;
                case 3: treasure.SetColor(FlashlightColor.Yellow, yellowGem); break;
            }

            Vector2 newPosition = Vector2.zero;

            bool keepGoing = false;
            do
            {
                newPosition.Set(Random.Range(GameController.controller.minPosition + 10, GameController.controller.maxPosition - 10), Random.Range(GameController.controller.minPosition + 10, GameController.controller.maxPosition - 10));
                keepGoing = IsLocationInList(newPosition);
            } while (keepGoing);
            treasure.transform.position = newPosition;
            treasureLocations.Add(newPosition);
            treasures.Add(treasure);
        }

        for (int i = 0; i < 50; i++)
        {
            GameObject g = Instantiate(rockPrefab);
            g.transform.SetParent(transform);
            Rock rock = g.GetComponent<Rock>();
            Vector2 newPosition = Vector2.zero;
            bool keepGoing = false;
            do
            {
                newPosition.Set(Random.Range(GameController.controller.minPosition, GameController.controller.maxPosition), Random.Range(GameController.controller.minPosition, GameController.controller.maxPosition));
                keepGoing = IsLocationInList(newPosition);
            } while (keepGoing);
            rock.transform.position = newPosition;
            rockLocations.Add(newPosition);
            rocks.Add(rock);

        }
    }

    //void Update()
    //{

    //}

    bool IsLocationInList(Vector2 location)
    {
        if (treasureLocations.Count == 0) return false;
        foreach(Vector2 l in treasureLocations)
        {
            if (l.x == location.x && l.y == location.y) return true;
        }
        foreach(Vector2 l in rockLocations)
        {
            if (l.x == location.x && l.y == location.y) return true;
        }
        return false;
    }
}
