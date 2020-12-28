using UnityEngine;

public class NPC : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    int timer = 0;
    Vector2 moveDir;
    int rnd;

    void FixedUpdate()
    {
        if (timer == 120)
        {
            rnd = Random.Range(1,9);
            timer = 0;
        }
        switch (rnd)
        {
            case 1:
                moveDir = new Vector2(1,1);
                anim.SetFloat("walk",1);
                break;

            case 2:
                moveDir = new Vector2(0,1);
                anim.SetFloat("walk", 1);
                break;

            case 3:
                moveDir = new Vector2(-1,1);
                anim.SetFloat("walk", 1);
                break;

            case 4:
                moveDir = new Vector2(0,-1);
                anim.SetFloat("walk", 0);
                break;

            case 5:
                moveDir = new Vector2(-1,-1);
                anim.SetFloat("walk", 0);
                break;

            case 6:
                moveDir = new Vector2(-1,0);
                break;

            case 7:
                moveDir = new Vector2(1,0);
                break;

            case 8:
                moveDir = new Vector2(1,-1);
                anim.SetFloat("walk", 0);
                break;

            case 9:
                moveDir = new Vector2(0,0);
                break;
        }
        rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime);
        timer++;
    }
}