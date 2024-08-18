using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    // Reference: https://pressstart.vip/tutorials/2018/06/28/41/keep-object-in-bounds.html

    private Vector2 _screenBoundary;

    // Start is called before the first frame update
    private void Start()
    {
        _screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void LateUpdate()
    {
        // Keep player object within the boundaries of the screen for orthographic cameras
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, _screenBoundary.x * -1, _screenBoundary.x);
        viewPosition.y = Mathf.Clamp(viewPosition.y, _screenBoundary.y * -1, _screenBoundary.y);
        transform.position = viewPosition;
    }
}
