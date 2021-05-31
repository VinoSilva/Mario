using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    private GameEvent mTarget;

    private void OnEnable()
    {
        mTarget = (GameEvent)target;
    }

    private void DisplayListeners()
    {
        List<GameEventListener> listeners = mTarget.GetListeners();

        int count = listeners.Count;

        for (int i = count - 1; i >= 0; i--)
        {
            EditorGUILayout.ObjectField(string.Concat("Listener ",(i + 1).ToString()), listeners[i].gameObject, typeof(GameObject), true);
        }
    }

    public override void OnInspectorGUI()
    {
        if (mTarget.listenerCount > 0)
        {
            DisplayListeners();

            if (GUILayout.Button("Raise"))
            {
                mTarget.Raise();
            }
        }
        else
        {
            GUILayout.Label("No listeners");
        }
    }
}
