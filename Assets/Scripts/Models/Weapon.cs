using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolBullet))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;

    [SerializeField] private PoolBullet _poolBulet;

    public string Name => _name;

    public void Shot(Vector3 start, Vector3 target)
    {
        var bullet = _poolBulet.GetObject().GetComponent<Bullet>();
        var offsetY = new Vector3(0, 0.2f, 0);
        bullet.transform.position = start + offsetY;
        bullet.TargetPosition = target;
    }
}
