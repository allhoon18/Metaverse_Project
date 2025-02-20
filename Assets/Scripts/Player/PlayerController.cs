using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�÷��̾� �̵� �ӵ�
    [SerializeField] public float speed;

    Rigidbody2D rigidbody;

    //ī�޶� �̵��ϵ��� �ϴ� ��ũ��Ʈ
    FollowCamera followCamera;
    //�÷��̾� �̵� �ӵ�
    [HideInInspector] public Vector2 velocity;

    //�÷��̾ ���� ���� ���� ȿ���� �����ϴ� ��ũ��Ʈ
    PlayerInWater playerWaterEffect;
    //�÷��̾ ������ ���ϴ���
    [HideInInspector] public bool isLeft;
    [HideInInspector] public AnimationController animationController;
    //ž�¹� ž���� �����ϴ� ��ũ��Ʈ
    RidableObject ridableObject;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
        followCamera = GetComponent<FollowCamera>();
        playerWaterEffect = GetComponent<PlayerInWater>();
        ridableObject = GetComponentInChildren<RidableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = MoveInput();
        JumpPlayer();
        followCamera.MoveCamera(transform.position);
        playerWaterEffect.OnWaterEffect();
        ridableObject.Riding();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    Vector2 MoveInput()
    {
        //�̵� �Է��� Input.GetAxis���� �޾ƿ�
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 velocity;
        //�Է��� ���� ���� �ӵ��� Vector2.zero�� �ٲ�
        if (inputX == 0 && inputY == 0)
            return velocity = Vector2.zero;
        //�Է��� ���� ��ֶ������ϰ� �ӵ��� ���� �̵� �ӵ��� ���
        velocity = new Vector2(inputX, inputY).normalized * speed;
        //x�� �Է°��� ���� ������ �ٶ󺸰� �ִ����� �Ǵ�
        if (inputX != 0)
            isLeft = inputX < 0;

        //�ִϸ��̼ǰ� ���� ���� �� ȿ���� �ٶ󺸴� ���⿡ ���� ����
        animationController.Flip(isLeft);
        playerWaterEffect.Flip(isLeft);

        return velocity;
    }

    void MovePlayer()
    {
        if (rigidbody == null)
            return;

        //�̵� �ӵ��� ����
        rigidbody.velocity = velocity;
        //�̵� �ӵ� ���� ���� �ִϸ��̼��� ����
        animationController.Move(velocity);
    }

    void JumpPlayer()
    {
        //���� ����� �ִϸ��̼��� ���� ����
        if (Input.GetKeyDown(KeyCode.Space))
            animationController.Jump();
    }

}
