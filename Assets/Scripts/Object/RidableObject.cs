using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidableObject : MonoBehaviour
{
    [Header("Vehicle Info")]
    public float power;
    public Vector2 ridingPos;
    public SpriteRenderer ridingSprite;
    PlayerController player;
    float normalSpeed;

    [SerializeField] bool onRiding;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        normalSpeed = player.speed;
    }

    public void Riding()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            onRiding = !onRiding;

            ridingSprite.gameObject.SetActive(onRiding);
            player.animationController.Ride(onRiding);

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
