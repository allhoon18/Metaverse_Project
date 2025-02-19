using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    int numBgCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for(int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            BoxCollider2D collider2D = collision.GetComponent<BoxCollider2D>();
            float widthOfObject = collider2D.size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();

        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }

    }
}
