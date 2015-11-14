using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed = 1f;

    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Idle()
    {
        anim.SetBool("Idle", true);
    }
    public void Move(Vector2 position)
    {
        position = position.normalized;
        anim.SetFloat("X", position.x);
        anim.SetFloat("Y", position.y);
        anim.SetBool("Idle", false);
        rb2d.MovePosition(rb2d.position + position*speed*Time.deltaTime);
    }
}
