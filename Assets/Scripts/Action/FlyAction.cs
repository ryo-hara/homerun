using System.Collections;
using UnityEngine;

public class FlyAction : MonoBehaviour, IGamePlayAction
{
    public IEnumerator Execute()
    {
        // Note: ボールを飛ばす処理を入れる
        Debug.Log("FlyAction");
        yield return null;
    }
}
