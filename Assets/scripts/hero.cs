using UnityEngine;
using UnityEngine.SceneManagement;
using F = System.IO.File;

public class hero : MonoBehaviour
{
    public float vel = 3;

    public Rigidbody2D rb;

    Vector2 input;

    string path = Application.dataPath;
    string saveContent;

    void Start()
    {
        F.Create(path, "game.save");
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");

        input.y = Input.GetAxisRaw("Vertical");

        saveContent = rb.Posision.ToString();
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

    private void DataSave()
    {
        F.WriteAllText(path, saveContent);
    }
}
