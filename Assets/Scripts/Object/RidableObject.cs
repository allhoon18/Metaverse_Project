using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidableObject : MonoBehaviour
{
    //탑승물 정보
    [Header("Vehicle Info")]
    //탑승물에 탑승했을 때 빨라지는 속도
    public float power;
    //탈것 스프라이트
    public SpriteRenderer ridingSprite;
    PlayerController player;
    //탈것에 탑승하기 전의 속도
    float normalSpeed;
    //탈것에 탑승 중인지 여부
    bool onRiding;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        //원래 속도를 시작할 때 저장
        normalSpeed = player.speed;
    }

    public void Riding()
    {
        //Z키를 입력했을 때 탑승물에 탑승/탑승 중일 때는 탑승물에서 내림
        if (Input.GetKeyUp(KeyCode.Z))
        {
            onRiding = !onRiding;
            //탑승물 스프라이트를 활성화
            ridingSprite.gameObject.SetActive(onRiding);
            //탑승 애니메이션을 재생
            player.animationController.Ride(onRiding);
            //탑승 여부에 따라 속도를 변경
            if (onRiding)
            {
                player.speed = AddSped(player.speed);
            }
            else
            {
                player.speed = normalSpeed;
            }
        }

        ridingSprite.flipX = !player.isLeft;
    }

    public void UpdatePlayer(float speed)
    {
        normalSpeed = speed;
    }
    
    public float AddSped(float playerSpeed)
    {
        return playerSpeed * (1 + power);
    }

}
