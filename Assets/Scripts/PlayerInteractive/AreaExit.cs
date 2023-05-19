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
  public float waitToLoad = 1f; // the time to wait to load the next area
  private bool shouldLoadAfterFade; // should load after fade

  // Start is called before the first frame update
  void Start()
  {
    theEntrance.transitionName = areaTransitionName;
  }

  // Update is called once per frame
  void Update()
  {
    // if should load after fade
    if (shouldLoadAfterFade)
    {
      // decrease the wait to load
      waitToLoad -= Time.deltaTime;
      // if the wait to load is less than or equal to 0
      if (waitToLoad <= 0)
      {
        // load the next area
        shouldLoadAfterFade = false;
        SceneManager.LoadScene(areaToLoad);
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      // SceneManager.LoadScene(areaToLoad);
      shouldLoadAfterFade = true;
      UIFade.instance.FadeToBlackScreen();
      PlayerController.instance.areaTransitionName = areaTransitionName;
    }
  }

}
