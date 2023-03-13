using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    //地面の位置・追加
    private float groundLevel = -3.0f;


    //既に置かれたキューブの位置・追加


    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
       

        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);


        //画面外にでたら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground Tag" || collision.gameObject.tag=="Cube Tag")
        {
            //接触時に音を鳴らす・追加
            GetComponent<AudioSource>().Play();

            Debug.Log("OK");

        }
        


    }

    void OnCollisionEnter(Collision other)
    {
        //接触時に音を鳴らす・追加
        GetComponent<AudioSource>().Play();

        Debug.Log("OK");
    }
        

    
}
