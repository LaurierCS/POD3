using UnityEngine;

[CreateAssetMenu(fileName = "New QuestionData", menuName = "QuestionData")]
public class Qtsdata : ScriptableObject
{
    [System.Serializable]
    public struct Question
    {
        public string questionsText;
        public string[] replies;
        public int correctReplyIndex;
    }

    public Question[] questions;

}
