using System.Collections;
using UnityEngine;

public class Exit : MonoBehaviour
{
    LevelManager levelManager;
    private Rocket rocket;
    public GameObject confetti;

    private void Start()
    {
        rocket = FindObjectOfType<Rocket>();
        if (!rocket)
        {
            print("No rocket found");
        }

        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Victory!");
        rocket.GetComponent<Rocket>().gameFinished = true;
        Instantiate(confetti, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
        StartCoroutine(ReloadScene(2f));
    }

    IEnumerator ReloadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        levelManager.GetComponent<LevelManager>().LoadNextLevel();
    }

}
