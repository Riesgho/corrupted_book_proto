using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Code
{
    public class PlayerMove : MonoBehaviour
    {
        private const string FLOOR_TAG = "Floor";
        private const float WIDTH = 0.73f;
        private const float HEIGHT = 0.73f;

        [SerializeField] private float speed = 3;
        [SerializeField] private int jumpSpeed = 3;
        [SerializeField] private int gravity = -8;
        [SerializeField, Range(-1, 0)] private float tolerance = -0.2f;
        [SerializeField, Range(0, 1)] private float detectionSize = 0.2f;

        private float _airTimeCounter;
        private bool _isGrounded;
        private float _speedX;
        private float _speedY;
        private RaycastHit2D _hit;
        private CollisionDetector _collisionDetector;

        private Bounds _bounds;

        // Start is called before the first frame update
        void Start()
        {
            Application.targetFrameRate = 60;
            _isGrounded = false;
            _speedY = gravity;
            _bounds = GetComponent<SpriteRenderer>().bounds;
            _collisionDetector = new AabbCalculator();
        }

        // Update is called once per frame
        void Update()
        {
            _speedX = Input.GetAxis("Horizontal") * speed;
            if (!_isGrounded)
            {
                _hit = Physics2D.Raycast(transform.position - new Vector3(0, HEIGHT * 0.51f), Vector2.down,
                    detectionSize);
                if (_hit)
                {
                    var pos = transform.position;
                    var hitBound = _hit.transform.GetComponent<SpriteRenderer>().bounds;
                    _bounds = GetComponent<SpriteRenderer>().bounds;
                    _isGrounded = _collisionDetector.HasCollisionOnY(_bounds,
                        hitBound, tolerance);
                    if (_isGrounded)
                        transform.position = new Vector3(pos.x,
                            pos.y + _collisionDetector.GetLastDifference(_bounds, hitBound));
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                StartCoroutine(Jump2());
            }

            if (_isGrounded)
                _speedY = 0;
        }

        private void FixedUpdate()
        {
            if (Math.Abs(_speedX) <= 0 && Math.Abs(_speedY) <= 0) return;
            var velocity = new Vector3(_speedX, _speedY, 0);
            transform.position += (velocity * Time.deltaTime);
        }

        private IEnumerator Jump2()
        {
            _speedY = jumpSpeed;
            _isGrounded = false;
            while (!_isGrounded)
            {
                _speedY += gravity * Time.deltaTime;
                yield return null;
            }
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            var position = transform.position;
            Gizmos.DrawWireCube(position, new Vector2(WIDTH, HEIGHT));
            Gizmos.DrawRay(position - new Vector3(0, HEIGHT * 0.51f), Vector2.down * detectionSize);
        }
    }
}