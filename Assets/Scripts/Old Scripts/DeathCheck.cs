using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour
{
    public GameObject Car;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
