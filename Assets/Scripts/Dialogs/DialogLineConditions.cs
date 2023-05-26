// this is the class that holds the conditions for a dialog line

[System.Serializable]

public class DialogLineConditions
{
  public enum ConditionType
  {
    questStarted,
    questCompleted,
    playerHasItem,
    playerStatValue
  }

  public ConditionType conditionType; // this is the type of condition and could be questStarted, questCompleted, playerHasItem, playerStatValue
  public string conditionName; // this could be the quest name, item name, or stat name
  public int conditionValue; // this could be the quest step, item quantity, or stat value
  public OperatorType operatorType; // this could be equal, greater than, less than, greater than or equal, less than or equal, not equal
}