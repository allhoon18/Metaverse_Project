using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //플레이어 이동 속도
    [SerializeField] public float speed;

    Rigidbody2D rigidbody;

    //카메라가 이동하도록 하는 스크립트
    FollowCamera followCamera;
    //플레이어 이동 속도
    [HideInInspector] public Vector2 velocity;

    //플레이어가 물에 들어갔을 때의 효과를 적용하는 스크립트
    PlayerInWater playerWaterEffect;
    //플레이어가 왼쪽을 향하는지
    [HideInInspector] public bool isLeft;
    [HideInInspector] public AnimationController animationController;
    //탑승물 탑승을 관리하는 스크립트
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
        //이동 입력을 Input.GetAxis통해 받아옴
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 velocity;
        //입력이 없을 때는 속도를 Vector2.zero로 바꿈
        if (inputX == 0 && inputY == 0)
            return velocity = Vector2.zero;
        //입력한 값을 노멀라이즈하고 속도를 곱해 이동 속도를 계산
        velocity = new Vector2(inputX, inputY).normalized * speed;
        //x축 입력값에 따라 왼쪽을 바라보고 있는지를 판단
        if (inputX != 0)
            isLeft = inputX < 0;

        //애니메이션과 물에 들어갔을 때 효과를 바라보는 방향에 따라 반전
        animationController.Flip(isLeft);
        playerWaterEffect.Flip(isLeft);

        return velocity;
    }

    void MovePlayer()
    {
        if (rigidbody == null)
            return;

        //이동 속도를 적용
        rigidbody.velocity = velocity;
        //이동 속도 값에 따라 애니메이션을 변경
        animationController.Move(velocity);
    }

    void JumpPlayer()
    {
        //점프 기능을 애니메이션을 통해 구현
        if (Input.GetKeyDown(KeyCode.Space))
            animationController.Jump();
    }

}
