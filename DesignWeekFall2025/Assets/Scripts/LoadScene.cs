
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Start"))
        {
            if (Input.GetKey(KeyCode.DownArrow) & Input.GetKey(KeyCode.RightArrow))
            {
                LoadMainScene();
            }
        }

        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Win") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            if (Input.GetKey(KeyCode.UpArrow) & Input.GetKey(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("Start"); 
            }
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
