using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一人称カメラのシステム、マウスによってカメラを動かす、
public class Stage1CameraScript : MonoBehaviour
{
    /*
     * 動かしたいカメラを取得する
     * カメラの座標を取得する
     * マウスを取得する
     * マウスの速度を取得する
     * マウスのXの回転累積を取得
     * マウスのYの回転累積を取得
     * 取得したX,Yの累積角度をカメラ入れる
     * 
     * 
     */

    [SerializeField] GameObject player;

    private UnityEngine.Vector3 playerPos;//プレイヤーの位置の変数

    private float speed = 100f; //カメラのスピードを取得

    private float mouseInputX;

    private float mouseInputY;

    void Start()
    {
        playerPos = player.transform.position;

        // カメラの向きをプレイヤーの向きに合わせる
        transform.rotation = player.transform.rotation;
    }

    void Update()
    {
        CameraSystem();
    }

    private void CameraSystem()
    {
        //playerPos = player.transform.position;で取得した位置を
        //transform.position += player.transform.position - playerPos;で引いて、その差分をplayerPos = player.transform.position;ここでまた取得している
        //カメラ位置をプレイヤーの位置に合わせる
        //カメラの移動 = 移動後座標-移動前座標　
        transform.position += player.transform.position - playerPos;
        //移動前座標 = 移動後座標
        playerPos = player.transform.position;

        //マウスのX軸とY軸の入力を取得
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = -Input.GetAxis("Mouse Y");

        //カメラを回転させる
        transform.RotateAround(playerPos, UnityEngine.Vector3.up, mouseInputX * Time.deltaTime * speed);
        transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * speed);
    }

}

