using UnityEngine;
using UnityEngine.SceneManagement;
using F = System.IO.File;

public class hero : MonoBehaviour
{
    public float vel = 3;

    public Rigidbody2D rb;

    Vector2 input;
    string path;
    string read;
    
    string saveContent;

    void Start()
    {
        path = Application.dataPath + "/game.save";
        rb.position = read;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");

        input.y = Input.GetAxisRaw("Vertical");

        saveContent = rb.position.ToString();
        DataSave();
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

    private void DataSave()
    {
        F.WriteAllText(path, saveContent);
    }

    private void DataRead()
    {
        F.AppendAllText(path, read);
    } 
}
