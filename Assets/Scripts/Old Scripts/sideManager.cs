using UnityEngine;

public class sideManager : MonoBehaviour
{

    public string side;
    //true = top
    //false = bottom
    public bool tb;

    private void Start()
    {
        side = "top";
    }

    private void Update()
    {
        if (side == "top")
            tb = true;
        else if (side == "bottom")
            tb = false;
    }
}
