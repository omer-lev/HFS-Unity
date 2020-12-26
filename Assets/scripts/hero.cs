using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class hero : MonoBehaviour
{
    public float vel = 3;
    public Rigidbody2D rb;
    Vector2 input;
    bool facingRight;
    public Animator animator;

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");

        input.y = Input.GetAxisRaw("Vertical");

        if (input.x > 0 && facingRight)
        {
            Flip();
        }
        else if (input.x < 0 && !facingRight)
        {
            Flip();
        }

        animator.SetFloat("WalkX", Math.Abs(input.x));
        animator.SetFloat("WalkY", input.y);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * vel * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "hativaCollider":
                Invoke("LoadNextScene", 0.2f);
                break;

            default:
                Invoke("LoadFirstScene", 0.2f);
                break;
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
