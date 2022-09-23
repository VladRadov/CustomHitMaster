using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBullet : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;

    private static List<GameObject> _poolBullets = new List<GameObject>();

    private void Start()
    {
        _poolBullets.Clear();
    }

    public GameObject GetObject()
    {
        foreach (var bullet in _poolBullets)
        {
            if (bullet.gameObject.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        AddObject();
        return _poolBullets[_poolBullets.Count - 1];
    }

    private void AddObject()
    {
        var bullet = Instantiate(_prefabBullet, transform.position, Quaternion.identity);
        bullet.SetActive(true);
        _poolBullets.Add(bullet);
    }
}
