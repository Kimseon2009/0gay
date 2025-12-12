using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;
        [UnityEngine.SerializeField]
        private bool isThrown = false;
        public float speed = 1.0f;

        public Vector3 dir;

        void Update()
        {
            if (isThrown)
            {
                this.transform.position += dir.normalized * Time.deltaTime * speed;
            }
        }

        public void setBullet(Vector3 _destination)
        {
            destination = _destination;
            isThrown = true;

            dir = destination - this.transform.position;
        }
    }
}
