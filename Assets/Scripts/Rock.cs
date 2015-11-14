using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Rock : MonoBehaviour
{
    public List<Sprite> rocks;
    SpriteRenderer sr;
    //public FlashlightColor currentColor = FlashlightColor.Red;
    //public bool visible;
    // Use this for initialization
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        sr.sprite = rocks[Random.Range(0, rocks.Count)];
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (visible)
    //    {
    //        sr.enabled = true;
    //    }
    //    else
    //    {
    //        sr.enabled = false;
    //    }
    //}
}
