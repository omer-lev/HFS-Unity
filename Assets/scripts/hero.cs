using UnityEngine;

public class hero : MonoBehaviour
{
    public float vel = 3;

    public Rigidbody2D rb;

    Vector2 input;

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");

        input.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * vel * Time.deltaTime);
    }
}
