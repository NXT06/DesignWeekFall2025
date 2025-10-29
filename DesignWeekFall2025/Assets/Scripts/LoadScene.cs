using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private bool isBothPumpDown = false;
    private bool isBothPumpUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow) & Input.GetKey(KeyCode.RightArrow))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Start"))
            {
                isBothPumpDown = true;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) & Input.GetKey(KeyCode.LeftArrow))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Win") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
            {
                isBothPumpUp = true;
            }
        }

        if (isBothPumpDown || isBothPumpUp)
        {
            LoadMainScene();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            LoadWin();
        }
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }
}
