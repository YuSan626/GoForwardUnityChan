using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //�L���[�u�̈ړ����x
    private float speed = -12;

    //���ňʒu
    private float deadLine = -10;

    //�n�ʂ̈ʒu�E�ǉ�
    private float groundLevel = -3.0f;


    //���ɒu���ꂽ�L���[�u�̈ʒu�E�ǉ�


    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
       

        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);


        //��ʊO�ɂł���j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground Tag" || collision.gameObject.tag=="Cube Tag")
        {
            //�ڐG���ɉ���炷�E�ǉ�
            GetComponent<AudioSource>().Play();

            Debug.Log("OK");

        }
        


    }

    void OnCollisionEnter(Collision other)
    {
        //�ڐG���ɉ���炷�E�ǉ�
        GetComponent<AudioSource>().Play();

        Debug.Log("OK");
    }
        

    
}
