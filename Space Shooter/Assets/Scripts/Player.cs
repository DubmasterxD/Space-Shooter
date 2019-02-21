using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] int health = 500;
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] float laserSpeed = 5f;
    [SerializeField] float projectileFiringPeriod = 0.2f;
    bool isFiring = false;
    float xMin;
    float xMax;

    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Destroy(damageDealer.gameObject);
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1") && !isFiring)
        {
            StartCoroutine(FireContinuously());
        }
    }

    private IEnumerator FireContinuously()
    {
        isFiring = true;
        while (Input.GetButton("Fire1"))
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
        isFiring = false;
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}
