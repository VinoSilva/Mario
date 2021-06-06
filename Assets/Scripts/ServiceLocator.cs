// ServiceLocator.cs
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : Singleton<ServiceLocator> {

    private IDictionary<Type, MonoBehaviour> serviceReferences;
    protected void Awake() {
        SingletonBuilder( this );
        serviceReferences = new Dictionary<Type, MonoBehaviour>();
    }

    public void AddService<T>(T reference) where T : MonoBehaviour, new() {
        bool serviceLocated = serviceReferences.ContainsKey( typeof( T ) );

        if(!serviceLocated){
            serviceReferences.Add(typeof(T),reference);
        }
        else
        {
            Debug.LogError(String.Concat("Cannot add type"," ",typeof(T).ToString()," called by gameObject ",reference.gameObject.name));
        }

        return;
    }

    public bool HasService<T>(){
        bool serviceLocated = serviceReferences.ContainsKey( typeof( T ) );

        return serviceLocated;
    }

    public bool RemoveService<T>(T reference) where T: MonoBehaviour,new(){
        bool serviceLocated = serviceReferences.ContainsKey(typeof(T));
        if(serviceLocated){
            MonoBehaviour check = null;
            serviceReferences.TryGetValue(typeof(T),out check);

            if(check == reference){
                serviceReferences.Remove(typeof(T));

                return true;
            }
        }

        return false;
    }

    public T GetService<T>() where T : MonoBehaviour, new() {
        UnityEngine.Assertions.Assert.IsNotNull( serviceReferences, "Someone has requested a service prior to the locator's intialization." );

        bool serviceLocated = serviceReferences.ContainsKey( typeof( T ) );
        if ( !serviceLocated ) {
            serviceReferences.Add( typeof( T ), FindObjectOfType<T>() );
        }

        UnityEngine.Assertions.Assert.IsTrue( serviceReferences.ContainsKey( typeof( T ) ), "Could not find service: " + typeof( T ) );
        var service = ( T ) serviceReferences [ typeof( T ) ];
        UnityEngine.Assertions.Assert.IsNotNull( service, typeof( T ).ToString() + " could not be found." );
        return service;
    }
}
