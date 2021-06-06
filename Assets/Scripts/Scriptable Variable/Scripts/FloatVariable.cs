using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Variable/Float Variable")]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    [NonSerialized]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
