using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性があるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverTest;

    //得点
    private int point = 0;

    //得点を表示するテキスト
    private GameObject pointText;

	// Use this for initialization
	void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverTest = GameObject.Find("GameOverText");
        this.pointText = GameObject.Find("PointText");

        this.pointText.GetComponent<Text>().text = point.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverTest.GetComponent<Text>().text = "Game Over";
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SmallCloudTag") || collision.gameObject.CompareTag("SmallStarTag"))
        {
            point += 10;
            this.pointText.GetComponent<Text>().text = point.ToString();
        }else if(collision.gameObject.CompareTag("LargeCloudTag") || collision.gameObject.CompareTag("LargeStarTag"))
        {
            point += 20;
            this.pointText.GetComponent<Text>().text = point.ToString();
        }
    }
}
