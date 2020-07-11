using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{

    LevelManager levelManager;
    public GameObject explosion;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("End");
        Instantiate(explosion, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
        StartCoroutine(ReloadScene(1.5f));
    }

    IEnumerator ReloadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        levelManager.GetComponent<LevelManager>().ReloadCurrentLevel();
    }
}
