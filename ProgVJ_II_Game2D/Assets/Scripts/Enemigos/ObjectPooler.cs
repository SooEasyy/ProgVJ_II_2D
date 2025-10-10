using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Header("Configuración del Pool")]
    [SerializeField] private GameObject pooledObject;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> objectPool;

    private void Awake()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObject, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // Si todos están activos, crea uno nuevo
        GameObject newObj = Instantiate(pooledObject, transform);
        newObj.SetActive(false);
        objectPool.Add(newObj);
        return newObj;
    }
}
