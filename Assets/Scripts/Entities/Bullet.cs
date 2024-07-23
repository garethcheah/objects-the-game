using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    private string targetTag;

    public void SetBullet(float damage, string targetTag, float speed = 15)
    {
        this._damage = damage;
        this._speed = speed;
        this.targetTag = targetTag;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void Damage(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.GetDamage(_damage);
            Debug.Log("Something damaged!");

            // TODO: Add score here
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag(targetTag))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            Damage(damageable);
        }
    }
}
