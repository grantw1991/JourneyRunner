using System.Collections.Generic;
using System.ComponentModel;

namespace Life.JourneyRunner.Models.BGL
{
    public class HeartConditionDetails
    {
        public List<HeartConditionType> HeartConditions { get; set; }
        public AnginaDetails AnginaDetails { get; set; }
        public ChestPainDetails ChestPainDetails { get; set; }
        public CoronaryArteryDetails CoronaryArteryDetails { get; set; }
        public HeartAttackDetails HeartAttackDetails { get; set; }
        public HeartRhythmDisorderDetails HeartRhythmDisorderDetails { get; set; }
        public HeartValveDisorderDetails HeartValveDisorderDetails { get; set; }
        public BloodPressureDetails BloodPressureDetails { get; set; }

        public enum HeartConditionType
        {
            [Description("Angina")]
            Angina,
            [Description("Cardiomyopathy")]
            Cardiomyopathy,
            [Description("Chest pain")]
            ChestPain,
            [Description("Coronary artery disease")]
            CoronaryArteryDisease,
            [Description("Heart attack")]
            HeartAttack,
            [Description("Heart rhythm disorder")]
            HeartRhythmDisorder,
            [Description("Heart valve disorder")]
            HeartValveDisorder,
            [Description("Irregular heartbeat")]
            IrregularHeartbeat,
            [Description("Raised blood pressure")]
            RaisedBloodPressure,
            [Description("Raised cholesterol")]
            RaisedCholesterol,
            [Description("Other")]
            Other
        }
    }
}
