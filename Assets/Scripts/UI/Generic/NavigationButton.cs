using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class
NavigationButton
: MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    Action<GameObject> selectCallback = null;

    private Selectable selectable = null;

    private void OnEnable()
    {
        if (!selectable)
        {
            selectable = GetComponent<Selectable>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectable.Select();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (selectCallback != null)
        {
            selectCallback (gameObject);
        }
    }

    public void SetCallback(Action<GameObject> callback)
    {
        selectCallback = callback;
    }
}
