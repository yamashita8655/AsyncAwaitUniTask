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

    // コルーチンの場合の非同期
    private void CoroutineTestFunction()
    {
        Debug.Log("メイン関数開始");
        Debug.Log("処理待ち開始");
        StartCoroutine(
            CoFunction(
                (returnString) => {
                    Debug.Log("処理終了:"+returnString);
                }
            )
        );
        Debug.Log("メイン関数終了");
    }

    private IEnumerator CoFunction(Action<string> endCallback)
    {
        for (int i = 0; i < 5; i++) {
            yield return new WaitForSeconds(1);
            Debug.Log("処理中:" + i);
        }
        endCallback("returnStrings");
    }

    // Async/Awaitの場合
    private async void AsyncAwaitTestFunction()
    {
        Debug.Log("メイン関数開始");
        Task<string> task = AsyncAwaitFunctionReturnString();
        Debug.Log("処理待ち開始");
        await task;
        //        string returnString = await task;
        string returnString = "";
        Debug.Log("処理終了:" + returnString);
        Debug.Log("メイン関数終了");
    }

    private async Task<string> AsyncAwaitFunctionReturnString()
    {
        for (int i = 0; i < 5; i++) {
            await Task.Delay(1000);
            Debug.Log("処理中:" + i);
        }

        return "returnStrings";
    }
}
