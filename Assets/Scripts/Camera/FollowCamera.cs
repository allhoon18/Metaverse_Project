using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform mainCamera;

    [SerializeField] Rect followArea;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        if ( followArea == null) return;

        Gizmos.color = gizmoColor;

        Vector3 center = new Vector3(followArea.x + followArea.width / 2, followArea.y + followArea.height / 2);
        Vector3 size = new Vector3(followArea.width, followArea.height);

        Gizmos.DrawCube(center, size);
    }

    public void MoveCamera(Vector2 playerPos)
    {
        float maxX = followArea.width / 2f;
        float minX = - followArea.width / 2f;
        float maxY = followArea.height / 2f;
        float minY = -followArea.height / 2f;

        Vector3 targetPos = Vector2.zero;

        targetPos = playerPos;
        targetPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(playerPos.y, minY, maxY);

        targetPos = Vector2.Lerp(targetPos, mainCamera.position, 0f);
        targetPos.z = -10f;

        mainCamera.position = targetPos;
    }

}
