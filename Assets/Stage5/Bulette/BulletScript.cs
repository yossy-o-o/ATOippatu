using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

//�I�u�W�F�N�g�𔭎˂��鏈��
public class BulletScript : MonoBehaviour
{
    /*
     * ��邱��
     * ��΂������I�u�W�F�N�g�̃v���n�u�����X�g�Ŏ擾
     * �ЂƂÂo��(�R���[�`��)
     * foreach�ŁA���X�g���Ƃ��Ă��āA�����o��
     * �ő�p�x�A�ŏ��p�x���o��(Deg2Rad)
     * �����_���ȕ����ɔ�΂�
     * ������܂ł̊Ԋu
     * 
     */

    public List<GameObject> textPrefab = new List<GameObject>();

    [SerializeField] float minAngle = 170f;// �ŏ��p�x

    [SerializeField] float maxAngle = 190f;// �ő�p�x


    [SerializeField] float intervel = 1.0f;//�R���[�`���̕b��

    public bool isShooting = true;

    Rigidbody2D rb2D;

    AudioSource audio;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        audio = GetComponent<AudioSource>();

        StartCoroutine(shoot());//�R���[�`����shoot�𐧌�
    }


    //�����_���ȕ���(limitAngle)�ɔ��˂���֐�
    public Vector2 RandomDirection()
    {
        //randomaAngle��limitangle�������
        float randomAngle = Random.Range(minAngle, maxAngle);

        //sin��cos�̊p�x�����߂Ă���BDeg2Rad�Ŋp�x�����W�A���ɕϊ����Ă���B�ϊ����R��Unity�����W�A�����g�p���Ă邽��
        float xDirection = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float yDirectiom = Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        //���\�b�h�̖߂�l�̌^��Vector2�Ȃ̂ŁAreturn�Ŋp�x��Ԃ�
        return new Vector2(xDirection, yDirectiom);
    }



    //�R���[�`���Ŏ��Ԑ�����s������
    IEnumerator shoot()
    {
        while (true)
        {
            //�N���A����̎��Ƀt���O�g��
            //isShotting��false�̏ꍇ�A���[�v������
            if (isShooting == false)
            {
                yield break;
            }

            //textprefab�̃��X�g�擾
            foreach (GameObject gameobject in textPrefab)
            {
                //Instantiate�Ő���
                GameObject newObject = Instantiate(gameobject, transform.position, Quaternion.identity);

                audio.Play();

                //�������ꂽ�I�u�W�F�N�g��rigidbody��t����
                rb2D = newObject.GetComponent<Rigidbody2D>();


                if (rb2D != null)
                {
                    //rigidbody�ɗ͂������������߁AaddFoece���A�����ɗ͂�������������(���񂪃����_�����\�b�h)�A�͂̋���
                    rb2D.AddForce(RandomDirection() * 500);
                }

                //�R���[�`����intervel�b�x��
                yield return new WaitForSeconds(intervel);

            }
        }
    }
}
