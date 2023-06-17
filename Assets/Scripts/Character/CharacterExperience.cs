// this script will handle the character experience and its calculations
// its also going to handle the character leveling up

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterExperience
{
  public static CharacterExperience instance;

  public int experience = 0;
  public int experienceToNextLevel = 100;
  public int level = 1;
  public int maxLevel = 100;

  public void AddExperience(int experienceToAdd)
  { 
    experience += experienceToAdd;
    if (experience >= experienceToNextLevel)
    {
      LevelUp();
    }
  }

  public void LevelUp()
  {
    if (level < maxLevel)
    {
      level++;
      experience -= experienceToNextLevel;
      experienceToNextLevel = experienceToNextLevel * 2;
    }
  }
}