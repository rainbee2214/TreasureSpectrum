using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Treasure : MonoBehaviour
{
    SpriteRenderer sr;
    public FlashlightColor currentColor = FlashlightColor.Red;
    public bool visible;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (visible)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }

    public void Show()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!visible) return;
            Debug.Log("Treasure collected!");
            gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Flashlight")
        {
            Debug.Log("Flashlight is touching!");
            if (other.GetComponentInParent<Flashlight>().currentColor == currentColor)
            {
                visible = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Flashlight")
        {
                visible = false;
            //if (other.GetComponentInParent<Flashlight>().currentColor == currentColor)
            //{
            //}
        }
    }
}
