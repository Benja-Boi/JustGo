using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableLobbyPuzzle : MonoBehaviour
{
    public GameObject puzzle;

    public void EnablePuzzle()
    {
        puzzle.SetActive(true);
    }

    public void DisablePuzzle()
    {
        puzzle.SetActive(false);
    }
}
