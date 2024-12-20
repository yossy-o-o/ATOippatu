using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

//オブジェクトを発射する処理
public class BulletScript : MonoBehaviour
{
    /*
     * やること
     * 飛ばしたいオブジェクトのプレハブをリストで取得
     * ひとつづつ出す(コルーチン)
     * foreachで、リストをとってきて、一個一個取り出す
     * 最大角度、最小角度を出す(Deg2Rad)
     * ランダムな方向に飛ばす
     * 投げるまでの間隔
     * 
     */

    public List<GameObject> textPrefab = new List<GameObject>();

    [SerializeField] float minAngle = 170f;// 最小角度

    [SerializeField] float maxAngle = 190f;// 最大角度


    [SerializeField] float intervel = 1.0f;//コルーチンの秒間

    public bool isShooting = true;

    Rigidbody2D rb2D;

    AudioSource audio;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        audio = GetComponent<AudioSource>();

        StartCoroutine(shoot());//コルーチンでshootを制御
    }


    //ランダムな方向(limitAngle)に発射する関数
    public Vector2 RandomDirection()
    {
        //randomaAngleにlimitangleをいれる
        float randomAngle = Random.Range(minAngle, maxAngle);

        //sinとcosの角度を求めている。Deg2Radで角度をラジアンに変換している。変換理由はUnityがラジアンを使用してるため
        float xDirection = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float yDirectiom = Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        //メソッドの戻り値の型がVector2なので、returnで角度を返す
        return new Vector2(xDirection, yDirectiom);
    }



    //コルーチンで時間制御を行う処理
    IEnumerator shoot()
    {
        while (true)
        {
            //クリア判定の時にフラグ使う
            //isShottingがfalseの場合、ループ抜ける
            if (isShooting == false)
            {
                yield break;
            }

            //textprefabのリスト取得
            foreach (GameObject gameobject in textPrefab)
            {
                //Instantiateで生成
                GameObject newObject = Instantiate(gameobject, transform.position, Quaternion.identity);

                audio.Play();

                //生成されたオブジェクトにrigidbodyを付ける
                rb2D = newObject.GetComponent<Rigidbody2D>();


                if (rb2D != null)
                {
                    //rigidbodyに力を加えたいため、addFoeceし、引数に力を加えたい方向(今回がランダムメソッド)、力の強さ
                    rb2D.AddForce(RandomDirection() * 500);
                }

                //コルーチンでintervel秒遅延
                yield return new WaitForSeconds(intervel);

            }
        }
    }
}
