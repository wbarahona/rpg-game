// this script handles the way the player exits an area
// the player will be teleported to the next area
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
  // public variables
  public string areaToLoad; // the name of the area to load
  public string areaTransitionName; // the area transition name
  public AreaEntrance theEntrance; // the area entrance
  // Start is called before the first frame update
  void Start()
  {
    theEntrance.transitionName = areaTransitionName;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      SceneManager.LoadScene(areaToLoad);
      PlayerController.instance.areaTransitionName = areaTransitionName;
    }
  }

}
