using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Item : GameObjectBase
    {
        public int Id;
        public string PrefabName;
        public string Tag;

        public Item(int id, string prefabName, string tag, GameObject prefab, string uniqueObjectName, float posX, float posY) : base(prefab, uniqueObjectName, posX, posY)
        {
            Id = id;
            PrefabName = prefabName;
            Tag = tag;
        }
    }
}
