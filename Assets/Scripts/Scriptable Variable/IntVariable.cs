using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Variable/Int Variable")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public int InitialValue;

    [NonSerialized]
    public int RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
