using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    public class player : MonoBehaviour
    {
        public float bulletTime = 0.1f;

        public float reloadTime = 0f;
        Rigidbody thisRigi;

        public float speed = 2.0f;

        public GameObject objBullet;

        public Transform BulletPoint;

        public float hp = 1.0f;
        private void Start()
        {
            thisRigi = this.GetComponent<Rigidbody>();
        }


        private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveV = new Vector3(moveX, 0, moveZ);
            thisRigi.velocity = moveV * speed;

            Vector3 poslnWorld = Camera.main.WorldToScreenPoint(this.transform.position);

            float posX = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
            float posY = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);

            Vector3 poslnScreen = Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, 0));
        }

        void Update()
        {
            Move();
            fireBullet();
        }

        void fireBullet()
        {
            reloadTime += Time.deltaTime;
            if (Input.GetButton("Fire1") && (bulletTime <= reloadTime))
            {
                reloadTime = 0f;
                GameObject Bullet = Instantiate(objBullet, BulletPoint.position, this.transform.rotation);
                Bullet.GetComponent<Bullet>().setBullet(BulletPoint.position + Vector3.forward);

            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                hp -= 1f;
                if (hp < 1.0f)
                {
                    Destroy(gameObject);
                }
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                hp -= 1f;
            }

        }
    }
}
