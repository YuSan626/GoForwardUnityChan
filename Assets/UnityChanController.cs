using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネント①
    Animator animator;

    //Unityちゃんを移動させるコンポーネント②
    Rigidbody2D rigid2D;

    //地面の位置①
    private float groundLevel = -3.0f;

    //ジャンプの速度の減衰②
    private float dump = 0.8f;

    //ジャンプの速度②
    float jumpVelocity = 20;

    //ゲームオーバーになる位置③
    private float deadLine = -9;

   //Use this for initialization
    void Start()
    {
        //アニメーターのコンポ取得①
        this.animator = GetComponent<Animator>();

        //Rigidbosy2Dのコンポーネント取得②
        this.rigid2D = GetComponent<Rigidbody2D>();


    }

   
    void Update()
    {
        //走るアニメーションを再生するため、Animatorのパラメーターを調節する①
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうか調べる①
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // ジャンプ状態のときにはボリュームを0にする④
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合②
        if (Input.GetMouseButtonDown(0)&& isGround)
        {
            //上方向に力をかける②
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);

        }

        //クリックをやめたら上方向への速度を減速する②
        if(Input.GetMouseButton(0)==false)
        {
            if(this.rigid2D.velocity.y>0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする③
        if (transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する③
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //ユニティちゃんを破棄する③
            Destroy(gameObject);

        }


    }
}
