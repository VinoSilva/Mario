using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StaticEventSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static void Select(GameObject selected)
    {
        selected.gameObject.SetActive(true);
        selected.GetComponent<Selectable>().Select();
        EventSystem.current.SetSelectedGameObject(null);    
        EventSystem.current.SetSelectedGameObject(selected,null);
    }
}
