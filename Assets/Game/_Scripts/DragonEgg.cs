using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    private static float bottomY = -40f;
    private DragonPicker dragonPicker;
    private ParticleSystem particles;
    private Renderer rend;
    private AudioSource audioSource;

    public bool IsDestroyed { get; private set; }

    private void Start()
    {
        dragonPicker = Camera.main.GetComponent<DragonPicker>();
        particles = GetComponent<ParticleSystem>();
        rend = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IsDestroyed = true;
        audioSource.Play();
        var em = particles.emission;
        em.enabled = true;
        rend.enabled = false;
        dragonPicker.DragonEggDestroyedWithoutOne(this.gameObject);
    }
}
