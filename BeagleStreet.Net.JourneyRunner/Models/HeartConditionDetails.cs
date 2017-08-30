using System.Collections.Generic;
using System.Linq;

namespace BeagleStreet.Net.JourneyRunner.Models
{
    public class HeartConditionDetails
    {
        public List<HeartConditionType> HeartConditions { get; set; }

        public enum HeartConditionType
        {
            Angina,
            Cardiomyopathy,
            ChestPain,
            CoronaryArteryDisease,
            HeartAttack,
            HeartRhythmDisorder,
            HeartValveDisorder,
            IrregularHeartbeat,
            RaisedBloodPressure,
            RaisedCholesterol,
            Other
        }

        public static Dictionary<HeartConditionType, string> Conditions = new Dictionary<HeartConditionType, string>
        {
            {HeartConditionType.Angina, "Angina"},
            {HeartConditionType.Cardiomyopathy, "Cardiomyopathy"},
            {HeartConditionType.ChestPain, "Chest pain"},
            {HeartConditionType.CoronaryArteryDisease, "Coronary artery disease"},
            {HeartConditionType.HeartAttack, "Heart attack"},
            {HeartConditionType.HeartRhythmDisorder, "Heart rhythm disorder"},
            {HeartConditionType.HeartValveDisorder, "Heart valve disorder"},
            {HeartConditionType.IrregularHeartbeat, "Irregular heartbeat"},
            {HeartConditionType.RaisedBloodPressure, "Raised blood pressure"},
            {HeartConditionType.RaisedCholesterol, "Raised cholesterol"},
            {HeartConditionType.Other, "Other"}
        };

        public int GetIndexOfHeartCondition(HeartConditionType heartConditionType)
        {
            return Conditions.ToList().IndexOf(Conditions.Single(s => s.Key == heartConditionType));
        }

        public string GetValueFromEnum(HeartConditionType condition)
        {
            return Conditions.Single(s => s.Key == condition).Value;
        }
    }
}
