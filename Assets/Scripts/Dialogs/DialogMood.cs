// this script defines the mood types for the dialog line

[System.Serializable]

public class DialogLineMood
{
  public enum MoodType
  {
    happy = 0,
    sad = 1,
    angry = 2,
    scared = 3,
    confused = 4,
    surprised = 5,
    disgusted = 6,
    neutral = 7
  }

  public MoodType value;
  public bool show = false;
}