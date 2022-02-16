using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwaitTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//        CoroutineTestFunction();
        AsyncAwaitTestFunction();
    }

    // �R���[�`���̏ꍇ�̔񓯊�
    private void CoroutineTestFunction()
    {
        Debug.Log("���C���֐��J�n");
        Debug.Log("�����҂��J�n");
        StartCoroutine(
            CoFunction(
                (returnString) => {
                    Debug.Log("�����I��:"+returnString);
                }
            )
        );
        Debug.Log("���C���֐��I��");
    }

    private IEnumerator CoFunction(Action<string> endCallback)
    {
        for (int i = 0; i < 5; i++) {
            yield return new WaitForSeconds(1);
            Debug.Log("������:" + i);
        }
        endCallback("returnStrings");
    }

    // Async/Await�̏ꍇ
    private async void AsyncAwaitTestFunction()
    {
        Debug.Log("���C���֐��J�n");
        Task<string> task = AsyncAwaitFunctionReturnString();
        Debug.Log("�����҂��J�n");
        await task;
        //        string returnString = await task;
        string returnString = "";
        Debug.Log("�����I��:" + returnString);
        Debug.Log("���C���֐��I��");
    }

    private async Task<string> AsyncAwaitFunctionReturnString()
    {
        for (int i = 0; i < 5; i++) {
            await Task.Delay(1000);
            Debug.Log("������:" + i);
        }

        return "returnStrings";
    }
}
