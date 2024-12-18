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
     * 飛ばしたいオブジェクトのプレハブを取得
     * Listで取得
     * foreachで、リストをとってきて、一個一個取り出す
     * 
     */

    public List<GameObject> textPrefab = new List<GameObject>();

    [SerializeField] float minAngle = 170f;// 最小角度

    [SerializeField] float maxAngle = 190f;// 最大角度


    [SerializeField] float intervel = 1.0f;//コルーチンの秒間

    public bool isShooting = true;

    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(shoot());//コルーチンでshootを制御
    }


    //ランダムな方向(limitAngle)に発射する関数
    public Vector2 RandomDirection()
    {
        //randomaAngleにlimitangleを入れる、RandomRangeでそれをランダムに発射
        float randomAngle = Random.Range(minAngle, maxAngle);

        //sinとcosの角度を求めている。Deg2Radで角度をラジアンに変換している。変換理由はUnityがラジアンを使用してるため
        float xDirection = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float yDirectiom = Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        //メソッドの戻り値の型がVector2なので、returnで角度を返す
        return new Vector2(xDirection, yDirectiom);
    }



    //コルーチンで時間制御を行うshoot
    IEnumerator shoot()
    {
        while (true)
        {
            if (isShooting == false)
            {
                yield break;
            }

            foreach (GameObject gameobject in textPrefab)//Listの内容を取得して
            {
                //GameObjectを参照するために、newObjectを作って、Instatiateで複製(複製するもの,位置,飛ばす方向)
                GameObject newObject = Instantiate(gameobject, transform.position, Quaternion.identity);

                //rigidbody2DをGetComponentする
                rb2D = newObject.GetComponent<Rigidbody2D>();

                //rigidbody2Dが入っていたら
                if (rb2D != null)
                {
                    //rigidbodyに力を加えたいため、addFoeceし、引数に力を加えたい方向(今回がランダムメソッド)、力の強さ
                    rb2D.AddForce(RandomDirection() * 500);
                }

                //コルーチンを使用した場合、yieldを使用する必要がある、WaitForSecondは何秒後にって意味
                yield return new WaitForSeconds(intervel);

            }
        }
    }
}
