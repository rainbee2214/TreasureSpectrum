using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TreasureController : MonoBehaviour
{
    List<Treasure> treasures;
    List<Vector2> treasureLocations;

    public Sprite redGem, blueGem, greenGem, yellowGem;

    public GameObject treasurePrefab;

    int size = 5;

    void Start()
    {
        treasures = new List<Treasure>();
        treasureLocations = new List<Vector2>();
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
                newPosition.Set(Random.Range(0, size), Random.Range(0, size));
                keepGoing = IsLocationInList(newPosition);
            } while (keepGoing);
            treasure.transform.position = newPosition;
            treasureLocations.Add(newPosition);
            treasures.Add(treasure);
        }
    }

    void Update()
    {

    }

    bool IsLocationInList(Vector2 location)
    {
        if (treasureLocations.Count == 0) return false;
        foreach(Vector2 l in treasureLocations)
        {
            if (l.x == location.x && l.y == location.y) return true;
        }
        return false;
    }
}
