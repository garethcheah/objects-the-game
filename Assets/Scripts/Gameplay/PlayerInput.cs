using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player _player;
    private float _horizontal, _vertical;
    private Vector2 _lookTarget;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && GameManager.instance.isStarted)
        {
            if (GameManager.instance.isPaused)
            {
                GameManager.instance.UnpauseGame();
            }
            else
            {
                GameManager.instance.PauseGame();
            }
        }

        if (!GameManager.instance.isPaused)
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _lookTarget = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {
                _player.Shoot();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _player.UseNuke();
            }
        }
    }

    private void FixedUpdate()
    {
        _player.Move(new Vector2(_horizontal, _vertical), _lookTarget);
    }
}
