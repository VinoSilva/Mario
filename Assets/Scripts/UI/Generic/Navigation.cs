using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buttonList = new List<GameObject>();

    [SerializeField]
    private Image pointerImage;

    [SerializeField]
    private Vector3 pointerOffset = new Vector3(-215.0f,0.0f,0.0f);

    private bool isInitialize = false;

    private void OnEnable() {
        int count = buttonList.Count; 

        if(isInitialize == false){            
            for(int i = 0;i < count;i++){
                buttonList[i].AddComponent<NavigationButton>().SetCallback(OnSelected);
            }

            isInitialize = true;
        }

        if(isInitialize && count > 0){
            buttonList[0].GetComponent<Selectable>().Select();
        }
    }

    private void OnSelected(GameObject selectedGameObject){
        Vector3 newPointerPosition = selectedGameObject.GetComponent<RectTransform>().localPosition;

        RectTransform pointerRect = pointerImage.GetComponent<RectTransform>();

        newPointerPosition.x = pointerOffset.x;
        newPointerPosition.y += pointerRect.rect.height/2;

        pointerImage.GetComponent<RectTransform>().localPosition  = newPointerPosition;
    }
}
