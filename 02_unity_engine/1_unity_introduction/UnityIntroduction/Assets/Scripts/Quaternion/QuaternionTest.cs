using UnityEngine;
using UnityEngine.UI;

public class QuaternionTest : MonoBehaviour
{
    public Button btnRotate;

    private void Start()
    {
        btnRotate.onClick.AddListener(RotateByQuaternion);
    }

    private void RotateByQuaternion()
    {
        // 旋转45度
        var rotation = new Quaternion(0, Mathf.Sin(45 * Mathf.Deg2Rad / 2), 0, Mathf.Cos(45 * Mathf.Deg2Rad / 2));
        transform.rotation *= rotation;
    }
}