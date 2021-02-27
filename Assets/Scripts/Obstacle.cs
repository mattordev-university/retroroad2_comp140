using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {

    public GameObject Car;

    ////Canvas variables
    //public Canvas mainCanvas;

    public sideManager sm;

    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
        Car = GameObject.FindGameObjectWithTag("Car");
        sm = GameObject.FindGameObjectWithTag("Player").GetComponent<sideManager>();
        //Player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
	}

    private void Update()
    {
        if (Player == null)
        {
            //Player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        }

        if (Player != null)
        {
            if (sm == null)
            {
                sm = GameObject.FindGameObjectWithTag("Player").GetComponent<sideManager>();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Player != null)
        {
            if (sm.side == "top")
            {
                if (other.tag == "Car")
                {
                    Destroy(Car);
                    Debug.Log("Death");
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}
