using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInWater : MonoBehaviour
{
    //�÷��̾ ���� �� �ִ��� ����
    bool inWater;
    //���� �Ǵ��� ���̾�
    [SerializeField] LayerMask waterLayer;
    //���� �� ���� �� Ȱ��ȭ�Ǵ� ȿ��
    public GameObject waterEffect;
    //���� ���� �ʾ��� ���� �ӵ�
    float normalSpeed;
    //���� ���� ���� ����ġ
    public float waterDrag = 0.3f;

    PlayerController playerController;
    //������ �̵��� ���� ��ƼŬ
    ParticleSystem waterParticle;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        normalSpeed = playerController.speed;
        waterParticle = waterEffect.GetComponentInChildren<ParticleSystem>();
    }

    //���� �� ���� ���� ȿ��
    public void OnWaterEffect()
    {
        //���� �� ���� �� ���� �� ȿ���� Ȱ��ȭ
        waterEffect.SetActive(inWater);

        if(inWater)
        {
            //������ �ӵ��� ����
            playerController.speed = waterDrag * normalSpeed;

            //������ �̵��� �� ��ƼŬ ȿ���� ���
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

    //Trigger�� ���� ���� ���� ���� ���θ� �Ǵ���
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
