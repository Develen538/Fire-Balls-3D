using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Color[] _color;

    private List<Block> _listBlock;


    public List<Block> Build()
    {
        _listBlock = new List<Block>();

        Transform CurrenPoint = _buildPoint;

        for (int i = 0; i < Random.Range(5,100); i++)
        {
            Block newBlock = BuildBlock(CurrenPoint);
            newBlock.SetColor(_color[Random.Range(0,_color.Length)]);
            _listBlock.Add(newBlock);
            CurrenPoint = newBlock.transform;
        }
        return _listBlock;
    }

    private Block BuildBlock(Transform CurrentBuild)
    {
        return Instantiate(_block, GetBuild(CurrentBuild), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuild(Transform CurrentSigment)
    {
        return new Vector3(_buildPoint.position.x, CurrentSigment.position.y + CurrentSigment.localScale.y / 2 + _block.transform.localScale.y / 2  , _buildPoint.position.z);    
    }

    private void Update()
    {
        if (_buildPoint.childCount == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(1);
        }
    }
}
