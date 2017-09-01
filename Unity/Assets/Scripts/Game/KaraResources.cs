using System;
using System.Collections.Generic;
using Contents;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Game
{
    static class KaraResources
    {
        private static readonly Dictionary<string, Object> Cache = new Dictionary<string, Object>();

        private static void ClearImage(Image image)
        {
            image.sprite = null;
            image.color = Color.clear;
        }

        public static void LoadSprite(Image image, Entity entity, Func<Entity, string> selectPath)
        {
            if (image == null)
            {
                return;
            }
            if (entity == null)
            {
                ClearImage(image);
                return;
            }

            var path = selectPath(entity);
            if (string.IsNullOrEmpty(path))
            {
                ClearImage(image);
                return;
            }

            if (!Cache.ContainsKey(path))
            {
                Debug.Log("Load Sprite " + path);
                Cache[path] = Resources.Load<Sprite>(path);
                Debug.Log("Load Complete " + Cache[path].name);
            }
            image.sprite = (Sprite)Cache[path];
            image.color = Color.white;
        }

        public static void ChangeSprite(Image image, Entity entity, Func<Entity, string> selectPath)
        {
            if (image == null)
            {
                return;
            }
            if (entity == null)
            {
                return;
            }

            var path = selectPath(entity);
            if (path == null)
            {
                return;
            }
            if (path == "")
            {
                ClearImage(image);
            }

            if (!Cache.ContainsKey(path))
            {
                Debug.Log("Load Sprite " + path);
                Cache[path] = Resources.Load<Sprite>(path);
                Debug.Log("Load Complete " + Cache[path].name);
            }
            image.sprite = (Sprite)Cache[path];
            image.color = Color.white;
        }
    }
}
