using System;
using UnityEngine;

namespace Loading
{
    class Bundle
    {
        public JSONObject Packs { get; }

        public Bundle(JSONObject packs)
        {
            Packs = packs;
        }

        public Pack GetPack(string key)
        {
            if (Packs.HasField(key) == false)
            {
                Debug.Log("Bundle Packs Key " + key);
                throw new Exception("번들 구성에 문제가 있습니다.");
            }
            return new Pack(Packs[key]);
        }
    }
}
