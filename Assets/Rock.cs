using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Rock : MonoBehaviour
{
    SpriteRenderer sr;
    public FlashlightColor currentColor = FlashlightColor.Red;
    public bool visible;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
