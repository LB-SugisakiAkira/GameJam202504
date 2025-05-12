using System;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class SingletonMonoBehaviour<TYpe> : MonoBehaviour, IDisposable where TYpe : MonoBehaviour
{
    private static TYpe _instance;

    public static TYpe Instance
    {
        get
        {
            Assert.IsNotNull(_instance, "There is no object attached " + typeof(TYpe).Name);
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance && _instance.gameObject)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this as TYpe;
        OnAwakeProcess();
    }


    /// <summary>
    ///     Destroy時処理
    ///     派生先で実行漏れが無いように意図的にPrivate
    /// </summary>
    private void OnDestroy()
    {
        // 自身以外のインスタンスが作成→即時破棄されるときに間違って実行されないようにブロック
        if (_instance != this as TYpe) return;
        OnDestroyProcess();
        Dispose();
    }

    public virtual void Dispose()
    {
        if (IsExist()) _instance = null;
    }

    /// <summary>
    ///     存在チェック
    /// </summary>
    /// <returns>True:存在, False:インスタンスが無い</returns>
    public static bool IsExist()
    {
        return _instance != null;
    }

    /// <summary>
    ///     派生先でも初期化処理を書くためのAPI
    /// </summary>
    protected virtual void OnAwakeProcess()
    {
    }

    /// <summary>
    ///     Destroy時処理
    /// </summary>
    protected virtual void OnDestroyProcess()
    {
    }
}