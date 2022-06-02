using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;

    private float horizontal;

    public string inputAxis = "Horizontal";

    public bool waxed;

    public float waxSpeedMultiplier;
    public float waxRotationSpeedMultiplier;
    public float waxDuration;

    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        waxed = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw(inputAxis);
    }

    private void FixedUpdate()
    {
        if (!waxed)
        {
            transform.Translate(speed * Time.fixedDeltaTime * Vector2.up, Space.Self);
            transform.Rotate(-horizontal * rotationSpeed * Time.fixedDeltaTime * Vector3.forward);
        }

        else
        {
            transform.Translate(speed * waxSpeedMultiplier * Time.fixedDeltaTime * Vector2.up, Space.Self);

            float horizontal = Random.Range(-1f, 1f);
            transform.Rotate(-horizontal * rotationSpeed * waxRotationSpeedMultiplier * Time.fixedDeltaTime * Vector3.forward);

        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wax"))
        {
            StartCoroutine(nameof(GetWaxed));
        }

        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Player"))
        {
            Crashed();
        }
    }

    private void Crashed()
    {
        speed = 0;
        particle.Play();
        Invoke(nameof(StartNextRound), particle.main.duration + 0.5f);
        
        
    }

    private void StartNextRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator GetWaxed()
    {
        waxed = true;
        yield return new WaitForSeconds(waxDuration);
        waxed = false;
    }
}
