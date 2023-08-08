using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class FlyAction : MonoBehaviour, IGamePlayAction
{
    
    // TODO: クラス図を書く
    [SerializeField]
    private FlyActionUI flyActionUI = null;
    
    [SerializeField]
    private Sphere sphere = null;


    private void Awake()
    {
        sphere.GetPositionObservable().Subscribe(position =>
        {
            flyActionUI.SetDistance(position.z);
        }).AddTo(this);
    }

    public IEnumerator Execute()
    {
        // Note: ボールを飛ばす処理を入れる
        Debug.Log("FlyAction");
        yield return new WaitForSeconds(100);
    }
}
