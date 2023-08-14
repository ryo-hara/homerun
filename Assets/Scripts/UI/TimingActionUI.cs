using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class TimingActionUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform timingBarRectTransform = null;

    private CompositeDisposable disposables = new CompositeDisposable();

    private Vector3 moveDistance = new Vector3(1.3f, 0, 0);
    private int direction = 1; // 1 ~ -1

    private const float BAR_SIZE = 300.0f;
    public const float HALF_BAR_SIZE = BAR_SIZE / 2;
    private const float HALF_BAR_SIZE_SQUARE = HALF_BAR_SIZE * HALF_BAR_SIZE;

    public float GetBarPositionFromLeftEdge()
    {
        var posX = timingBarRectTransform.localPosition.x;
        if (posX < 0f)
        {
            return HALF_BAR_SIZE - posX * -1;
        }
        else
        {
            return HALF_BAR_SIZE + posX;
        }
    }
    
    public void Initialize()
    {
        this.FixedUpdateAsObservable().Subscribe(_ =>
        {
            timingBarRectTransform.localPosition += moveDistance * direction;
            var posX = timingBarRectTransform.localPosition.x;
            var posXSquare = posX * posX;

            if (HALF_BAR_SIZE_SQUARE < posXSquare)
            {
                direction *= -1;
            }
        });

        
    }

    public void Finalize()
    {
        disposables.Dispose();
    }
}
