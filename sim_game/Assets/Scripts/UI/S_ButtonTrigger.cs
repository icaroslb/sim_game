using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_ButtonTrigger : MonoBehaviour
{
    [SerializeField] private bool openObject;
    [SerializeField] private bool closeObject;
    [SerializeField] private GameObject objectChange;
    
    // Activate or deactivate the game object
    public void OnClick ()
    {
        if (objectChange.activeSelf == false)
        {
            if (openObject)
                objectChange.SetActive(true);
        }
        else
        {
            if (closeObject)
                objectChange.SetActive(false);
        }

    }
}
