using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInWater : MonoBehaviour
{
    bool inWater;
    [SerializeField] LayerMask waterLayer;
    public GameObject waterEffect;

    float normalSpeed;
    public float waterDrag = 0.3f;
    PlayerController playerController;

    ParticleSystem waterParticle;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        normalSpeed = playerController.speed;
        waterParticle = waterEffect.GetComponentInChildren<ParticleSystem>();
    }


    public void OnWaterEffect()
    {
        waterEffect.SetActive(inWater);
        if(inWater)
        {
            playerController.speed = waterDrag * normalSpeed;

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
