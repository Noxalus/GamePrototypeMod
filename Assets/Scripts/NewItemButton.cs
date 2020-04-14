using GamePrototype;
using ModTool.Interface;
using System.Collections.Generic;
using UnityEngine;

public class NewItemButton : ModBehaviour
{
    [SerializeField]
    private GameObject _newItem = null;

    private List<GameObject> _instances = new List<GameObject>();
    private bool _isPlacingNewItem = false;

    private void Start()
    {
        GameManager.Instance.ItemPlacer.OnItemPlaced += OnItemPlaced;
        GameManager.Instance.ItemPlacer.OnItemChanged += OnItemChanged;
    }

    private void OnItemChanged(string itemName)
    {
        Debug.Log("Item selection changed");
        _isPlacingNewItem = false;
    }

    private void OnItemPlaced(GameObject instance)
    {
        if(_isPlacingNewItem)
        {
            Debug.Log("Add instance to the list");
            _instances.Add(instance);
            Debug.Log($"Instance list size: {_instances.Count}");
        }
        else
        {
            Debug.Log("It's not a new item");
        }
    }

    public void OnClick()
    {
        GameManager.Instance.SetItem(_newItem);
        _isPlacingNewItem = true;
        Debug.Log("Is placing new item");
    }

    private void OnDestroy()
    {
        foreach (GameObject instance in _instances)
        {
            Destroy(instance.gameObject);
        }
    }
}
