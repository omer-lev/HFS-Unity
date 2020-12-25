using UnityEngine;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    public float vel = 3;
    public Rigidbody2D rb;
    Vector2 input;
    bool facingRight;

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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * vel * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hativaCollider")
        {
            Invoke("LoadNextScene", 0.2f);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
