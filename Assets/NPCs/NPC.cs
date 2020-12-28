using UnityEngine;

public class NPC : MonoBehaviour
{
    public Rigidbody2D rb;
    int timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer == 5)
        {
            rb.MovePosition(rb.position + new Vector2(Random.Range(-3, 3) * Time.deltaTime, Random.Range(-3, 3) * Time.deltaTime));
            timer = 0;
        }
        timer++;
    }
}