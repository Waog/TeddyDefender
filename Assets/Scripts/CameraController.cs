using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform CameraFocus;
    public Vector2
        Margin, // area aroundthe play which wont move the camera(?)
        Smoothing;
    public BoxCollider2D Bounds;

    private Vector3
        _min,
        _max;

    public bool IsFollowing { get; set; }


    public void Start()
    {
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        IsFollowing = true;
    }

    public void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;

        if (IsFollowing)
        {
            if (Mathf.Abs(x - CameraFocus.position.x) > Margin.x)
            {
                x = Mathf.Lerp(x, CameraFocus.position.x, Smoothing.x * Time.deltaTime);
            }

            if (Mathf.Abs(y - CameraFocus.position.y) > Margin.y)
            {
                y = Mathf.Lerp(y, CameraFocus.position.y, Smoothing.y * Time.deltaTime);
            }
        }

        var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
