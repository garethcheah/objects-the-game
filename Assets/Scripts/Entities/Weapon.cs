using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    private string _name;
    private float _damage;
    private float _bulletSpeed;

    public Weapon()
    {

    }

    public Weapon(string name, float damage, float bulletSpeed)
    {
        _name = name;
        _damage = damage;
        _bulletSpeed = bulletSpeed;
    }

    public void Shoot(Bullet bullet, PlayableObject player, string targetTag, float timeToDie = 5.0f)
    {
        Bullet tempBullet = GameObject.Instantiate(bullet, player.transform.position, player.transform.rotation);

        tempBullet.SetBullet(_damage, targetTag, _bulletSpeed);
        GameObject.Destroy(tempBullet.gameObject, timeToDie);
    }

    public float GetDamage()
    {
        return _damage;
    }
}
