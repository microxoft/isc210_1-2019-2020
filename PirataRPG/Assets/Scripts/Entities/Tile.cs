using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Tile : GameObjectBase
    {
        public Tile(GameObject prefab, string uniqueObjectName, float posX, float posY) : base(prefab, uniqueObjectName, posX, posY)
        {

        }
    }
}
