using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.Delete) || Input.GetKey(KeyCode.Backspace))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
