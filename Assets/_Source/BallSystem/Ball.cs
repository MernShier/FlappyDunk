using System;
using UnityEngine;

namespace BallSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float upForce;
        [SerializeField] private float speed;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MoveHorizontal();
        }

        public void MoveHorizontal()
        {
            var position = transform.position;
            transform.position = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z);
        }
        
        public void MoveUp()
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
        }
    }
}