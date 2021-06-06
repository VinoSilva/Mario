using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Object to be pooled")]
    private GameObject pooledObject = null;

    [SerializeField]
    [Tooltip("The amount instantiated and added on initialization/awake")]
    [Range(1,1000)]
    private int initPoolAmount = 30;

    [SerializeField]
    [Tooltip("The amount to instantiate and add to the list if there are insufficient gameobjects")]
    [Range(0,100)]
    private int incrAmount = 5;

    [SerializeField]
    [Tooltip("The parent of the pooled gameobjects. If nothing is set, an empty gameobject will be created as the parent")]
    private GameObject parent = null; 

    private List<GameObject> poolList = new List<GameObject>();

    private void Awake() {
        CreateGameObjects(initPoolAmount);
    }

    private void CreateGameObjects(int amount){

        GameObject poolParent = GetParent();

        for(int i = 0;i < amount;i++){
            GameObject newPoolObject = Instantiate(pooledObject,Vector3.zero,pooledObject.transform.rotation) as GameObject;

            newPoolObject.transform.parent = poolParent.transform;

            newPoolObject.gameObject.SetActive(false);

            poolList.Add(newPoolObject);
        }
    }

    private GameObject GetPooledObject(){
        int count = poolList.Count;

        GameObject returnObject = null;

        for(int i = 0;i < count;i++){
            if(!poolList[i].gameObject.activeSelf){
                returnObject = poolList[i].gameObject;
                break;
            }
        }

        // If all the pooled object is active currently then create more
        if(!returnObject){
            int newIndex = poolList.Count;

            CreateGameObjects(incrAmount);

            returnObject = poolList[newIndex];
        }

        if(!returnObject){
            Debug.LogError("Get Pooled Object returned null");
            Debug.Break();
        }

        return returnObject;
    }

    private GameObject GetParent(){
        if(parent){
            return parent;
        }

        parent = CreateParent();

        return parent;
    }

    private GameObject CreateParent(){
        GameObject newParent = new GameObject("Pool Parent");

        return newParent;
    }
}
