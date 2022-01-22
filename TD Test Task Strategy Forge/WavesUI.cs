using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WavesUI : MonoBehaviour
{    
    public TextMeshProUGUI textMP;

    private EnemySpawner spawn;
    private int _waves, _maxWaves;

    private void Start()
    {
        spawn = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        _waves = spawn.wave;
        _waves--;
        _maxWaves = spawn.numberOfWaves;
        textMP.text = "Waves: " + _waves.ToString() + " / " + _maxWaves.ToString();
    }
}
