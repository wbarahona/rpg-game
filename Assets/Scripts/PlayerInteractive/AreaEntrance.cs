// this script is used to determine where the player will spawn when entering a new area
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
  // public variables
  public string transitionName; // the transition name
  // Start is called before the first frame update
  void Start()
  {
    if (transitionName == PlayerManager.instance.areaTransitionName)
    {
      PlayerManager.instance.transform.position = transform.position;
    }
    UIFade.instance.FadeFromBlackScreen();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
