using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("LoadNextScene", 0.2f);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
