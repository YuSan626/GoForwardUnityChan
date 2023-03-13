using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //�B

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト�@
    private GameObject gameOverText;

    //走行距離テキスト�@
    private GameObject runLengthText;

    //走った距離�@
    private float len = 0;

    //走る速度�@
    private float speed = 0.03f;

    //ゲームオーバーの判定�@
    private bool isGameOver = false;

 

    // Start is called before the first frame update
    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する�@
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame�@
    void Update()
    {
        if (this.isGameOver == false)
        {
            //走った距離を更新する�@
            this.len += this.speed;

            //走った距離を表示する�@
            this.runLengthText.GetComponent<Text>().text = "Distance:" + len.ToString("F2") + "m";

        }

        // ゲームオーバーになった場合�B
        if (this.isGameOver == true)
        {
            // クリックされたらシーンをロードする�B
            if (Input.GetMouseButtonDown(0))
            {
                //GoForwardを読み込む�B
                SceneManager.LoadScene("GoForward");

            }

        }

    }

    public void GameOver()
    {
        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する�@
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;

    }
}
