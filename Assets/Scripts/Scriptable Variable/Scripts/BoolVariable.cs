using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Variable/Bool Variable")]
public class BoolVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public bool InitialValue;

    [NonSerialized]
    public bool RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
