using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour
{

    private GameObject Car;
    private sideManager sm;
    public GameObject Player;
    public string sceneName;
    public int buildIndex;
    public Scene currentScene;

    // Use this for initialization
    void Start()
    {
        // Create a temporary reference to the current scene.
        currentScene = SceneManager.GetActiveScene();
        
        Car = GameObject.FindGameObjectWithTag("Car");
        sm = GameObject.FindGameObjectWithTag("Car").GetComponent<sideManager>();
    }

    void Update()
    {
        if (sm == null)
        {
            sm = GameObject.FindGameObjectWithTag("Car").GetComponent<sideManager>();
        }

        if (currentScene == null)
        {
            currentScene = SceneManager.GetActiveScene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (sceneName == "1st map")
        {
            buildIndex = 1;
        }
        else if (sceneName == "Circle test")
        {
            buildIndex = 2;
        }

        if (sm.side == "top")
        {
            if (other.tag == "Car")
            {
                switch (buildIndex)
                {
                    case 1:
                        Destroy(Car);
                        Debug.Log("Death occured, loading first gameover screen");
                        SceneManager.LoadScene("GameOver");
                        break;
                    case 2:
                        Destroy(Car);
                        Debug.Log("Death occured, loading second gameover screen");
                        SceneManager.LoadScene("GameOver2");
                        break;
                }
            }
        }

        if (sm.side == "bottom")
        {
            if (other.tag == "Car")
            {
                Destroy(Car);
            }
        }

    }
}
