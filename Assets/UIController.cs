using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //③

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト①
    private GameObject gameOverText;

    //走行距離テキスト①
    private GameObject runLengthText;

    //走った距離①
    private float len = 0;

    //走る速度①
    private float speed = 0.03f;

    //ゲームオーバーの判定①
    private bool isGameOver = false;

 

    // Start is called before the first frame update
    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する①
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame①
    void Update()
    {
        if (this.isGameOver == false)
        {
            //走った距離を更新する①
            this.len += this.speed;

            //走った距離を表示する①
            this.runLengthText.GetComponent<Text>().text = "Distance:" + len.ToString("F2") + "m";

        }

        // ゲームオーバーになった場合③
        if (this.isGameOver == true)
        {
            // クリックされたらシーンをロードする③
            if (Input.GetMouseButtonDown(0))
            {
                //GoForwardを読み込む③
                SceneManager.LoadScene("GoForward");

            }

        }

    }

    public void GameOver()
    {
        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する①
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;

    }
}
