using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float _timeToLive = 15.0f;

    public virtual void OnPicked()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        _timeToLive -= Time.deltaTime;

        if (_timeToLive <= 0)
        {
            Destroy(gameObject);
        }
    }
}
