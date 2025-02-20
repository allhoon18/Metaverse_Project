using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform mainCamera;
    //카메라의 추적 범위
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
        //카메라 이동의 최대 범위를 계산
        float maxX = followArea.width / 2f;
        float minX = - followArea.width / 2f;
        float maxY = followArea.height / 2f;
        float minY = -followArea.height / 2f;

        Vector3 targetPos = Vector2.zero;
        //Clamp를 통해 카메라 이동 범위를 제한
        targetPos = playerPos;
        targetPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(playerPos.y, minY, maxY);

        targetPos = Vector2.Lerp(targetPos, mainCamera.position, 0f);
        //카메라의 z 갑을 -10으로 설정(설정하지 않으면 0이 되어 카메라에 오브젝트가 보이지 않음)
        targetPos.z = -10f;

        mainCamera.position = targetPos;
    }

}
