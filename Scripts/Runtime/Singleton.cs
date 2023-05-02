using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodySource
{
    namespace Singleton
    {
        public class Singleton<T> : MonoBehaviour where T : Component
        {
            private static T _instance;
            public static T instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<T>();
                        if (_instance != null) return _instance;
                        GameObject obj = new GameObject();
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        _instance = obj.AddComponent<T>();
                    }
                    return _instance;
                }
            }
        }

        public class SingletonPersistent <T> : MonoBehaviour where T : Component
        {
            public static T instance { get; private set; }
            public virtual void Awake()
            {
                if (instance == null)
                {
                    instance = this as T;
                    DontDestroyOnLoad(this);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}