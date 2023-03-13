using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g�@
    Animator animator;

    //Unity�������ړ�������R���|�[�l���g�A
    Rigidbody2D rigid2D;

    //�n�ʂ̈ʒu�@
    private float groundLevel = -3.0f;

    //�W�����v�̑��x�̌����A
    private float dump = 0.8f;

    //�W�����v�̑��x�A
    float jumpVelocity = 20;

    //�Q�[���I�[�o�[�ɂȂ�ʒu�B
    private float deadLine = -9;

   //Use this for initialization
    void Start()
    {
        //�A�j���[�^�[�̃R���|�擾�@
        this.animator = GetComponent<Animator>();

        //Rigidbosy2D�̃R���|�[�l���g�擾�A
        this.rigid2D = GetComponent<Rigidbody2D>();


    }

   
    void Update()
    {
        //����A�j���[�V�������Đ����邽�߁AAnimator�̃p�����[�^�[�𒲐߂���@
        this.animator.SetFloat("Horizontal", 1);

        //���n���Ă��邩�ǂ������ׂ�@
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // �W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���C
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //���n��ԂŃN���b�N���ꂽ�ꍇ�A
        if (Input.GetMouseButtonDown(0)&& isGround)
        {
            //������ɗ͂�������A
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);

        }

        //�N���b�N����߂��������ւ̑��x����������A
        if(Input.GetMouseButton(0)==false)
        {
            if(this.rigid2D.velocity.y>0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���B
        if (transform.position.x < this.deadLine)
        {
            //UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������B
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //���j�e�B������j������B
            Destroy(gameObject);

        }


    }
}
