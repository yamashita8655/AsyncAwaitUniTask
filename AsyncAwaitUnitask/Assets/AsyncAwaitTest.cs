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

    // コルーチンの場合の非同期
    private void CoroutineTest()
    {
        Debug.Log("メイン関数開始");
        Debug.Log("処理待ち開始");
        StartCoroutine(
            CoCoroutine(
                () => {
                    Debug.Log("処理終了");
                }
            )
        );
        Debug.Log("メイン関数終了");
    }

    private IEnumerator CoCoroutine(Action endCallback)
    {
        for (int i = 0; i < 5; i++) {
            yield return new WaitForSeconds(1);
            Debug.Log("処理中:" + i);
        }
        endCallback();
    }
}
