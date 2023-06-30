using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectionScript : MonoBehaviour
{
    public void Ruins()
    {
        SceneManager.LoadScene("RocksideRuins");
    }

    public void Greenwoods()
    {
        SceneManager.LoadScene("Greenwoods");
    }

    public void MegaCity()
    {
        SceneManager.LoadScene("MegaCity");
    }
}
