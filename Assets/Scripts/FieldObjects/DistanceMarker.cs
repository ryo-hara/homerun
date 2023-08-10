using TMPro;
using UnityEngine;

// TODO: 注視方向を最初に決めたりしてもよい

public class DistanceMarker : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro distanceText = null;
    [SerializeField]
    private Transform textTransform = null;

    private Vector3 textRotate = new Vector3(0, 180, 0);

    public void SetText(string text)
    {
        distanceText.text = text;
    }
    
    // Update is called once per frame
    void Update()
    {
        var position = Camera.main.transform.position;
        position.y = transform.position.y;
        textTransform.LookAt (position);
        transform.Rotate(textRotate);
        // textTransform.rotation = textRotateQuaternion;
        // カメラよりも後ろに行ったら非表示
    }
}
