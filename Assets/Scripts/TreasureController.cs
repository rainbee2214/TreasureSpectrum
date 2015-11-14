using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TreasureController : MonoBehaviour
{
    List<Treasure> treasures;

    public GameObject treasurePrefab;

    void Start()
    {
        treasures = new List<Treasure>();
        for (int i = 0; i < GameController.controller.CurrentLevelTreasureCount; i++)
        {

            Treasure treasure = new GameObject("Treasure").AddComponent<Treasure>();
            treasures.Add(treasure);
        }
    }

    void Update()
    {

    }
}
