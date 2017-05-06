using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //画面サイズ
    private float screenWidthSize = 1080.0f;
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        //HinjiJointコンポーネントの取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
        //左矢印キーを押したとき左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押したとき右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //左矢印キーが離されたとき左フリッパーを動かす
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        //右矢印キーが離されたとき右フリッパーを動かす
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //タップ
        foreach(Touch t in Input.touches)
        {
            var id = t.fingerId;

            switch(t.phase)
            {
                case TouchPhase.Began:
                    //画面左側をタップしたとき左フリッパを動かす
                    if (t.position.x < (screenWidthSize / 2) && tag == "LeftFripperTag")
                    {
                        
                        SetAngle(this.flickAngle);
                    }
                    //画面右側をタップしたとき右フリッパを動かす
                    if (t.position.x >= (screenWidthSize / 2) && tag == "RightFripperTag")
                    {

                        SetAngle(this.flickAngle);
                    }
                    
                    
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    //画面左側をタップしたとき左フリッパを動かす
                    if (t.position.x < (screenWidthSize / 2) && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    //画面右側をタップしたとき右フリッパを動かす
                    if (t.position.x >= (screenWidthSize / 2) && tag == "RightFripperTag")
                    {

                        SetAngle(this.defaultAngle);
                    }
                    break;
            }
                
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
