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
     * ��΂������I�u�W�F�N�g�̃v���n�u���擾
     * List�Ŏ擾
     * foreach�ŁA���X�g���Ƃ��Ă��āA�����o��
     * 
     */

    public List<GameObject> textPrefab = new List<GameObject>();

    [SerializeField] float minAngle = 170f;// �ŏ��p�x

    [SerializeField] float maxAngle = 190f;// �ő�p�x


    [SerializeField] float intervel = 1.0f;//�R���[�`���̕b��

    public bool isShooting = true;

    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(shoot());//�R���[�`����shoot�𐧌�
    }


    //�����_���ȕ���(limitAngle)�ɔ��˂���֐�
    public Vector2 RandomDirection()
    {
        //randomaAngle��limitangle������ARandomRange�ł���������_���ɔ���
        float randomAngle = Random.Range(minAngle, maxAngle);

        //sin��cos�̊p�x�����߂Ă���BDeg2Rad�Ŋp�x�����W�A���ɕϊ����Ă���B�ϊ����R��Unity�����W�A�����g�p���Ă邽��
        float xDirection = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float yDirectiom = Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        //���\�b�h�̖߂�l�̌^��Vector2�Ȃ̂ŁAreturn�Ŋp�x��Ԃ�
        return new Vector2(xDirection, yDirectiom);
    }



    //�R���[�`���Ŏ��Ԑ�����s��shoot
    IEnumerator shoot()
    {
        while (true)
        {
            if (isShooting == false)
            {
                yield break;
            }

            foreach (GameObject gameobject in textPrefab)//List�̓��e���擾����
            {
                //GameObject���Q�Ƃ��邽�߂ɁAnewObject������āAInstatiate�ŕ���(�����������,�ʒu,��΂�����)
                GameObject newObject = Instantiate(gameobject, transform.position, Quaternion.identity);

                //rigidbody2D��GetComponent����
                rb2D = newObject.GetComponent<Rigidbody2D>();

                //rigidbody2D�������Ă�����
                if (rb2D != null)
                {
                    //rigidbody�ɗ͂������������߁AaddFoece���A�����ɗ͂�������������(���񂪃����_�����\�b�h)�A�͂̋���
                    rb2D.AddForce(RandomDirection() * 500);
                }

                //�R���[�`�����g�p�����ꍇ�Ayield���g�p����K�v������AWaitForSecond�͉��b��ɂ��ĈӖ�
                yield return new WaitForSeconds(intervel);

            }
        }
    }
}