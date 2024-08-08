using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.SizeUpdate += OnSizeUpdat;
    }

    private void OnDisable()
    {
        _tower.SizeUpdate -= OnSizeUpdat;
    }

    private void OnSizeUpdat(int size)
    {
        _sizeView.text = size.ToString();
    }
}
