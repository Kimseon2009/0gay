using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    [System.Serializable]
    
    public enum ItemStatus
    {
        hp,
        upgrade,
        bomb
    }
    public class item : MonoBehaviour
    {
        public float itemSpeed = 0.25f;

        public ItemStatus itemStatus = ItemStatus.hp;

        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * itemSpeed);
        }
    }
}
