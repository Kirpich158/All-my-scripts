using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIList : MonoBehaviour
{
    public delegate void DelegateP(GameObject spawnedPrefab);

    public T AddEntry<T>(GameObject prefab, DelegateP method)
    {
        GameObject tmpPrefab = Instantiate(prefab, gameObject.transform);

        method(tmpPrefab);

        return gameObject.GetComponent<T>();
    }
}
