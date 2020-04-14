using GamePrototype;
using ModTool.Interface;
using System.Collections.Generic;
using UnityEngine;

public class CylinderButton : ModBehaviour
{
    [SerializeField]
    private GameObject _cylinder = null;

    private List<GameObject> _instances = new List<GameObject>();
    private bool _isPlacingNewItem = false;

    private void Start()
    {
        GameManager.Instance.ItemPlacer.OnItemPlaced += OnItemPlaced;
        GameManager.Instance.ItemPlacer.OnItemChanged += OnItemChanged;
    }

    private void OnItemChanged(string itemName)
    {
        _isPlacingNewItem = false;
    }

    private void OnItemPlaced(GameObject instance)
    {
        if(_isPlacingNewItem)
        {
            _instances.Add(instance);
        }
    }

    public void OnClick()
    {
        GameManager.Instance.SetItem(_cylinder);
        _isPlacingNewItem = true;
    }

    private void OnDestroy()
    {
        foreach (GameObject instance in _instances)
        {
            Destroy(instance.gameObject);
        }
    }
}
