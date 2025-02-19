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
    public static SceneState currentScene = SceneState.Main;

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

}
