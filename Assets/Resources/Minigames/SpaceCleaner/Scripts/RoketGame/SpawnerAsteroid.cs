using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAsteroid : MonoBehaviour
{
    private float x_Min;
    private float x_Max;
    private float startPoint;
    [SerializeField]private List<GameObject> spawnObjects;
    [SerializeField]private GameObject[] asteroid;
    

    private void Awake()
    {
        x_Min = -3;
        x_Max = 3;
        startPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        //Random.InitState(1);

        for (int i = 0; i< asteroid.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject newObject = Instantiate(asteroid[i]);
                newObject.gameObject.SetActive(false); 
                spawnObjects.Add(newObject);
                newObject.transform.SetParent(this.transform);
                
            }
        }
    }

    public GameObject GetSpawnObject(List<GameObject> objects)
    {
        var i = Random.Range(0, spawnObjects.Count);
        if (!objects[i].activeSelf)
        {
            return objects[i];
        }
        return null;
    }

    public void AddObject()
    {
        GameObject newObject = GetSpawnObject(spawnObjects);
        if (newObject!=null)
        {
            newObject.transform.position = new Vector2(Random.Range(x_Min, x_Max), startPoint + 1);
            newObject.SetActive(true);
        }

    }
    void Start()
    {
       StartCoroutine(Spawn());
    }




    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            AddObject();
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
