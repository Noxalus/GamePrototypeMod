using ModTool.Interface;
using UnityEngine;
using UnityEngine.UI;

public class GamePrototypeMod : ModBehaviour
{
    [SerializeField]
    private string _buttonsName = "Buttons";

    [SerializeField]
    private Button _button = null;

    void Start()
    {
        GameObject buttons = FindInActiveObjectByName(_buttonsName);

        if (buttons == null)
        {
            Debug.LogError($"Can't find object with name \"{_buttonsName}\"");
        }
        else
        {
            if (_button == null)
            {
                Debug.LogError("New item button is null");
            }
            else
            {
                _button.transform.SetParent(buttons.transform, false);
            }
        }
    }

    private void OnDestroy()
    {
        Destroy(_button.gameObject);
    }

    private GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];

        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }

        return null;
    }
}
