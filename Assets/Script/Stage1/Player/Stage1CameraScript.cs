using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一人称カメラのシステム、マウスによってカメラを動かす
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
     */

    public Camera playerCamera; //カメラ

    private float mouseSpeed = 2.0f; //カメラ速度

    private float mouseX; //マウス座標X

    private float mouseY; //マウス座標Y

    private float carrentXAngle; //Xの累積角度保持

    private float carrentYAngle; //Yの累積角度保持
    

   
    void Start()
    {
        playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        CameraAngle();
    }

    //カメラの処理
    void CameraAngle()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        Debug.Log("Current X Angle: " + carrentXAngle);

        carrentXAngle += mouseY * mouseSpeed; //回転してた時のXの角度を保持
        carrentYAngle += mouseX * mouseSpeed; //回転してた時のYの角度を保持


        playerCamera.transform.localRotation = Quaternion.Euler(carrentXAngle, 0, 0); //X軸の回転


        transform.localRotation = Quaternion.Euler(0, carrentYAngle, 0); //Y軸回転


        carrentXAngle = Mathf.Clamp(carrentXAngle, -90f, 90f);
    }

}
