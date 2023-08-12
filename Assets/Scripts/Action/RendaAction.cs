using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class RendaAction : MonoBehaviour, IGamePlayAction
{
    private Input input = null;
    private CompositeDisposable disposables = new CompositeDisposable();
    


    public void Prepare()
    {
        input = GameObject.Find("Input").GetComponent<Input>();
        input.GetKeyPressedObservable(Key.Space).Subscribe(_ =>
        {
            Debug.Log("InputSpaceS");
        }).AddTo(disposables);

    }

    public void Disable()
    {
        disposables.Dispose();
    }

    public IEnumerator Execute()
    {
        // Note: 連打処理を入れる
        Debug.Log("RendaAction");
        yield return new WaitForSeconds(100);
    }

}
