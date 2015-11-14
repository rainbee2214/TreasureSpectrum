using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Treasure : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Treasure collected!");
            gameObject.SetActive(false);
        }
    }
}
