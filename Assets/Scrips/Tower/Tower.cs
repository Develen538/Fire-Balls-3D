using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuild))]
public class Tower : MonoBehaviour
{
    private TowerBuild _towerBuild;

    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdate;

    private void Start()
    {
        _towerBuild = GetComponent<TowerBuild>();
       _blocks = _towerBuild.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        SizeUpdate?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block block)
    {
        block.BulletHit -= OnBulletHit;

        _blocks.Remove(block);

        foreach (var blockin in _blocks)
        {
            blockin.transform.position = new Vector3(blockin.transform.position.x,blockin.transform.position.y - blockin.transform.localScale.y,blockin.transform.position.z);
        }
        SizeUpdate?.Invoke(_blocks.Count);
    }
}
