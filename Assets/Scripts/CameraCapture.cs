using System.IO;
using UnityEngine;

public class CameraCapture : MonoBehaviour
{

    public KeyCode screenShotButton;
    void Update()
    {
        if (Input.GetKeyDown(screenShotButton))
        {
            ScreenCapture.CaptureScreenshot("screenshot.png");
            Debug.Log("A screenshot was taken!");
        }
    }

}