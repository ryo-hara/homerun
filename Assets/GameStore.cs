using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class GameStore : MonoBehaviour
{
    private int rendaCount = 0;
    private float clickTiming = 0;

    private float MAX_REMAINING_TIME = 10.0f;
    private float timeCount = 0.0f;
    private float RemainingTime => MAX_REMAINING_TIME - timeCount;
    private Subject<float> remainingTimeSunject = new Subject<float>();
    public IObservable<float> RemainingTimeObservable => remainingTimeSunject;

    private IDisposable disposable = null;

    public void SetClickTiming(float timing)
    {
        clickTiming = timing;
    }

    public void SetRendaCount(int count)
    {
        rendaCount = count;
    }

    public float GetPowerMagnification()
    {
        return clickTiming * (float)rendaCount / 30;
    }

    public void StartTimerCount()
    {
        disposable?.Dispose();
        timeCount = 0.0f;
        remainingTimeSunject.OnNext(MAX_REMAINING_TIME);
        
        disposable = this.UpdateAsObservable().Subscribe(_ =>
        {
            timeCount += Time.deltaTime;
            remainingTimeSunject.OnNext(RemainingTime);
        });
    }

    public bool isTimeOver()
    {
        return RemainingTime <= 0.0f;
    }

    public void StopTimerCount()
    {
        disposable?.Dispose();
    }
}
