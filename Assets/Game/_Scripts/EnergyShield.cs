using System;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    [NonSerialized] public Collider Collider;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = Camera.main.transform.position.z;
        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        var pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collided = collision.gameObject;
        if(collided.tag == "Dragon Egg")
        {
            if (collided.GetComponent<DragonEgg>().IsDestroyed)
                return;

            Destroy(collided);
            audioSource.Play();
            OnCollidedEgg.Invoke();
        }
    }

    public event Action OnCollidedEgg;
}
