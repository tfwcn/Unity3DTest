using UnityEngine;
using System.Collections;

public class SCamera : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Camera.main.aspect = 16 / 9f;
        float x = 0, y = 0, width = 0, height = 0;
        if (Screen.width / Screen.height > 16 / 9f)
        {
            width = Screen.height * (16 / 9f);
            height = Screen.height;
        }
        else
        {
            width = Screen.width;
            height = Screen.height * (9 / 16f);
        }
        x = (Screen.width - width) / 2;
        y = (Screen.height - height) / 2;
        Camera.main.pixelRect = new Rect(x, y, width, height);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
