using UnityEngine;

namespace Shop
{
    [System.Serializable]
    public class ItemInfo
    {
        public string Name;
        public bool canOverlap;
        public Sprite ItemImage;
        public int price;
    }
}
