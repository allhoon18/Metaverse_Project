using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInWater : MonoBehaviour
{
    //플레이어가 물에 들어가 있는지 여부
    bool inWater;
    //물로 판단할 레이어
    [SerializeField] LayerMask waterLayer;
    //물에 들어가 있을 때 활성화되는 효과
    public GameObject waterEffect;
    //물에 들어가지 않았을 때의 속도
    float normalSpeed;
    //물에 들어갔을 때의 감소치
    public float waterDrag = 0.3f;

    PlayerController playerController;
    //물에서 이동할 때의 파티클
    ParticleSystem waterParticle;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        normalSpeed = playerController.speed;
        waterParticle = waterEffect.GetComponentInChildren<ParticleSystem>();
    }

    //물에 들어가 있을 때의 효과
    public void OnWaterEffect()
    {
        //물에 들어가 있을 때 물에 들어간 효과를 활성화
        waterEffect.SetActive(inWater);

        if(inWater)
        {
            //물에서 속도를 늦춤
            playerController.speed = waterDrag * normalSpeed;

            //물에서 이동할 때 파티클 효과를 재생
            if(playerController.velocity.magnitude >= 0.5f)
            {
                waterParticle.Stop();
                waterParticle.Play();
            }
            
        }
            
    }

    public void Flip(bool isLeft)
    {
        SpriteRenderer waterSpriteRenderer = waterEffect.GetComponent<SpriteRenderer>();
        waterSpriteRenderer.flipX = !isLeft;

        if (isLeft)
            waterParticle.transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            waterParticle.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    //Trigger를 통해 물에 들어가고 나간 여부를 판단함
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (waterLayer.value == (waterLayer.value | (1 << collision.gameObject.layer)))
        {
            inWater = true;
            normalSpeed = playerController.speed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (waterLayer.value == (waterLayer.value | (1 << collision.gameObject.layer)))
        {
            inWater = false;
            playerController.speed = normalSpeed;
        }
    }
}
