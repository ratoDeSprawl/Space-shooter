using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("move")]
    [Range(0f, 5f)]
    [SerializeField]
    private float moveSpeed = 1f;

    private bool _canMove = true;
    
    [Header("Bounds")]
    [SerializeField]
    private BoxCollider2D playerBounds;

    [Header("Shoot")]
    [SerializeField]
    private Transform shootPivot;

    [SerializeField]
    private GameObject shootPrefab;

    [SerializeField]
    public int vidaMaxima;
    public int vidaAtual;

    [Header("Death")]
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private Transform deathPosition;

    private Vector3 _initialDeathPosition;

    [SerializeField]
    private float returnSpeed = 0.2f;

    
    private Vector3 _initialPosition;

    

    private void Awake()
    {
        _initialPosition = transform.position;
        _initialDeathPosition = deathPosition.position;
    }
    private void Start()
    {
        vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        ApplyBounds();

        Shoot();

    }

    private void Shoot()
    {
        if (!Input.GetButtonDown("Fire1"))
        {
            return;
        }
        Instantiate(shootPrefab, shootPivot.position, shootPivot.rotation);
    }

    private void Move()
    {
        if (!_canMove)
        {
            return;
        }

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var move = new Vector3(
            h * moveSpeed * Time.deltaTime,
            v * moveSpeed * Time.deltaTime,
            0f

        );

        transform.Translate(move);
    }

     private void ApplyBounds(){

        var minX = -playerBounds.bounds.extents.x + playerBounds.offset.x + playerBounds.transform.position.x;
        var maxX = playerBounds.bounds.extents.x + playerBounds.offset.x + playerBounds.transform.position.x;

        var minY = -playerBounds.bounds.extents.y + playerBounds.offset.y + playerBounds.transform.position.y;
        var maxY = playerBounds.bounds.extents.y + playerBounds.offset.y + playerBounds.transform.position.y;

        //Debug.Log($"Size: {playerBounds.size}; {playerBounds.bounds.extents}");
        //y-1.107

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        ); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation); 
            Destroy(other.gameObject);
            StartCoroutine(Die());
        }
        if (other.CompareTag("ShootEnemy"))
        {
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            StartCoroutine(Die());
        }
        //if (other.CompareTag("ShootEnemy"))
        //{
        //    vidaAtual--;
        //    if (vidaAtual <= 0)
        //    {
        //        Destroy(gameObject);
        //        Debug.Log("Game Over");
        //    }
        //}
        
    }

    private IEnumerator Die()
    {
        Score.instance.ResetPoint();
        _canMove = false;
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        transform.position = _initialDeathPosition;

        yield return new WaitForSeconds(1f);

        yield return null;

        transform.position = deathPosition.position;

        while(transform.position.x < _initialPosition.x)
        {
            var direction = (deathPosition.position - transform.position).normalized;
            transform.Translate(direction * (returnSpeed * Time.deltaTime));

            yield return null;

        }

        //yield return new WaitForSeconds(1f);

        _canMove = true;
    }

    public void Inalvejavel()
    {

    }
}
