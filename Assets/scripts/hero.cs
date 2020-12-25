using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    public float vel = 3;
    public Rigidbody2D rb;
    Vector2 input;
    GameObject Player;


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
        if (collision.gameObject.tag == "hativaCollider")
        {
            Invoke("LoadNextScene", 0.2f);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(Player);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 pos;
        pos.x = data.pos[0];
        pos.y = data.pos[1];
        pos.z = data.pos[2];

        transform.position = pos;
    }
}
