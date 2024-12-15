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

    private Vector3 playerPosition;//現在地取得

    private float speed = 200f; //カメラのスピードを取得

    private float mouseInputX;

    private float mouseInputY;

    void Start()
    {
        playerPosition = player.transform.position; //playerの位置を取得

        // カメラの向きをプレイヤーの向きに合わせる
        transform.rotation = player.transform.rotation;
    }

    void Update()
    {
        CameraSystem();
    }

    private void CameraSystem()
    {　
        transform.position += player.transform.position - playerPosition;
        playerPosition = player.transform.position;

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = -Input.GetAxis("Mouse Y");

        //カメラを回転させる
        transform.RotateAround(playerPosition, Vector3.up, mouseInputX * Time.deltaTime * speed);
        transform.RotateAround(playerPosition, transform.right, mouseInputY * Time.deltaTime * speed);
    }

}

