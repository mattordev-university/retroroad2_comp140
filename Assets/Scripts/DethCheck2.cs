using UnityEngine;
using UnityEngine.SceneManagement;

public class DethCheck2 : MonoBehaviour
{

    private GameObject Car;

    //Canvas variables
    private Canvas mainCanvas;

    private sideManager sm;

    public GameObject Player;
    // Use this for initialization
    void Start()
    {
        Car = GameObject.FindGameObjectWithTag("Player");
        sm = GameObject.FindGameObjectWithTag("Player").GetComponent<sideManager>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }

    void Update()
    {
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
        if (sm.side == "top")
        {
            Debug.Log("biggay");
            if (other.tag == "Car")
            {
                Destroy(Car);
                Debug.Log("Death");
                SceneManager.LoadScene("GameOver2");
            }
        }

        if (sm.side == "bottom")
        {
            if (other.tag == "Car")
            {
                Destroy(Car);
                Debug.Log("Death");
                SceneManager.LoadScene("");
            }
        }

    }
}
