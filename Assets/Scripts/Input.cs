using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    private Subject<Keyboard> keyboardSubject = new Subject<Keyboard>();
    private IObservable<Keyboard> keyboardObservable => keyboardSubject;

    // Note: 指定したkey入力が入った時にUnitを流すObservableを返すメソッド
    public IObservable<Unit> GetKeyPressedObservable(Key key)
    {
        return keyboardObservable.Where(keyboard => keyboard[key: key].wasPressedThisFrame).AsUnitObservable();
    }
    
    private void FixedUpdate()
    {
        var keyboard = Keyboard.current;
        
        if (keyboard != null) {
            keyboardSubject.OnNext(keyboard);
        }
        else
        {
            Debug.LogError("Keyboard.current is null");
        }

    }
}
