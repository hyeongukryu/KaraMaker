using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Main
{
    partial class MainSceneManager
    {
        public GameObject GetChildGameObject(GameObject parent, string name)
        {
            var transforms = parent.transform.GetComponentsInChildren<Transform>();
            return (from t in transforms
                where t.gameObject.name == name
                select t.gameObject).First();
        }

        private readonly Dictionary<string, object> _componentCache = new Dictionary<string, object>();

        private T GetComponent<T>(string objectName)
        {
            var dictionaryKey = objectName + "$" + typeof(T).FullName;
            object value;
            if (!_componentCache.TryGetValue(dictionaryKey, out value))
            {
                _componentCache[dictionaryKey] = value = GameObject.Find(objectName).GetComponent<T>();
            }
            return (T) value;
        }

        private T GetComponent<T>(GameObject gameObject, string objectName)
        {
            var dictionaryKey = gameObject.GetInstanceID() + "$" + objectName + "$" + typeof(T).FullName;
            object value;
            if (!_componentCache.TryGetValue(dictionaryKey, out value))
            {
                _componentCache[dictionaryKey] = value = GetChildGameObject(gameObject, objectName).GetComponent<T>();
            }
            return (T) value;
        }
    }
}