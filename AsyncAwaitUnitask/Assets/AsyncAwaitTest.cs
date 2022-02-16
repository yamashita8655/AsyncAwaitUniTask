using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncAwaitTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CoroutineTest();
    }

    // �R���[�`���̏ꍇ�̔񓯊�
    private void CoroutineTest()
    {
        Debug.Log("���C���֐��J�n");
        Debug.Log("�����҂��J�n");
        StartCoroutine(
            CoCoroutine(
                () => {
                    Debug.Log("�����I��");
                }
            )
        );
        Debug.Log("���C���֐��I��");
    }

    private IEnumerator CoCoroutine(Action endCallback)
    {
        for (int i = 0; i < 5; i++) {
            yield return new WaitForSeconds(1);
            Debug.Log("������:" + i);
        }
        endCallback();
    }
}
