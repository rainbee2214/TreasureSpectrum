using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed = 1f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 position)
    {
        position = position.normalized;
        rb2d.MovePosition(rb2d.position + position*speed*Time.deltaTime);
    }
}
