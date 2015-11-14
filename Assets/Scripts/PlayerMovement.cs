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

    void Update()
    {
        rb2d.velocity = Vector2.zero;
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
        Vector2 clampedPosition = rb2d.position + position * speed * Time.deltaTime;
        clampedPosition.Set(Mathf.Clamp(clampedPosition.x,
                                        GameController.controller.minPosition + 10,
                                        GameController.controller.maxPosition - 10),
                            Mathf.Clamp(clampedPosition.y,
                                        GameController.controller.minPosition + 10,
                                        GameController.controller.maxPosition - 10)
                            );
        rb2d.MovePosition(clampedPosition);
        
    }
}
