using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime); //  Œ ›Ì »⁄œ Êﬁ 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Õ–› «·“Ê„»Ì
        }

        Destroy(gameObject); // Õ–› «·ÿ·ﬁ… ‰›”Â«
    }
}
