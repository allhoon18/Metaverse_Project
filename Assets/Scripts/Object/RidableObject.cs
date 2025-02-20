using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidableObject : MonoBehaviour
{
    //ž�¹� ����
    [Header("Vehicle Info")]
    //ž�¹��� ž������ �� �������� �ӵ�
    public float power;
    //Ż�� ��������Ʈ
    public SpriteRenderer ridingSprite;
    PlayerController player;
    //Ż�Ϳ� ž���ϱ� ���� �ӵ�
    float normalSpeed;
    //Ż�Ϳ� ž�� ������ ����
    bool onRiding;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        //���� �ӵ��� ������ �� ����
        normalSpeed = player.speed;
    }

    public void Riding()
    {
        //ZŰ�� �Է����� �� ž�¹��� ž��/ž�� ���� ���� ž�¹����� ����
        if (Input.GetKeyUp(KeyCode.Z))
        {
            onRiding = !onRiding;
            //ž�¹� ��������Ʈ�� Ȱ��ȭ
            ridingSprite.gameObject.SetActive(onRiding);
            //ž�� �ִϸ��̼��� ���
            player.animationController.Ride(onRiding);
            //ž�� ���ο� ���� �ӵ��� ����
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
