using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneState
{
    Main,
    FlappyPlane,
}

public class SceneLoader : MonoBehaviour
{
    public Vector2[] returnPoint;

    public static SceneState currentScene = SceneState.Main;

    void Start()
    {
        PlayerReturn();
    }

    public void ChangeScene( string tag )
    {
        switch(tag)
        {
            case "FlappyPlane":
                currentScene = SceneState.FlappyPlane;
                SceneManager.LoadScene("FlappyPlaneScene");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            ChangeScene(collision.tag);
        }
    }

    void PlayerReturn()
    {
        switch (currentScene)
        {
            case SceneState.Main:
                transform.position = returnPoint[((int)SceneState.Main)];
                break;

            case SceneState.FlappyPlane:
                transform.position = returnPoint[((int)SceneState.FlappyPlane)];
                break;
        }

        currentScene = SceneState.Main;
    }

}
