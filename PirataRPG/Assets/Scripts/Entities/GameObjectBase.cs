using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public abstract class GameObjectBase
    {
        public string UniqueObjectName;
        public float PosX;
        public float PosY;
        private GameObject _gObjectRef;

        public GameObjectBase()
        {
        }

        public GameObjectBase(GameObject prefab, string uniqueObjectName, float posX, float posY)
        {
            _gObjectRef = UnityEngine.Object.Instantiate(prefab, new Vector3(posX, posY), Quaternion.identity);
            _gObjectRef.name = uniqueObjectName;
        }

        ~GameObjectBase()
        {
            UnityEngine.Object.Destroy(_gObjectRef);
        }

        public void Activate()
        {
            _gObjectRef.SetActive(true);
        }

        public void Inactive()
        {
            _gObjectRef.SetActive(false);
        }

        public GameObject GetObject()
        {
            return _gObjectRef;
        }
    }
}
