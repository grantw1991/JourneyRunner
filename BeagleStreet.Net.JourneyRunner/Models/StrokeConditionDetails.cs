using System.Collections.Generic;
using System.Linq;

namespace BeagleStreet.Net.JourneyRunner.Models
{
    public class StrokeConditionDetails
    {
        public List<StrokeConditionType> StrokeConditions { get; set; }

        public enum StrokeConditionType
        {
            BrainBleed,
            BrainHaemorrhage,
            BrainInjury,
            CerebralHaemorrhage,
            CerebrovascularAccident,
            HeadInjury,
            NarrowingOfArteries,
            Stroke,
            SubarachnoidHaemorrhage,
            TransientIschaemicAttack,
            Other
        }

        public static Dictionary<StrokeConditionType, string> Conditions = new Dictionary<StrokeConditionType, string>
        {
            {StrokeConditionType.BrainBleed, "Brain bleed"},
            {StrokeConditionType.BrainHaemorrhage, "Brain haemorrhage"},
            {StrokeConditionType.BrainInjury, "brain injury"},
            {StrokeConditionType.CerebralHaemorrhage, "cerebral haemorrhage"},
            {StrokeConditionType.CerebrovascularAccident, "cerebrovascular accident"},
            {StrokeConditionType.HeadInjury, "head injury"},
            {StrokeConditionType.NarrowingOfArteries, "narrowing of the arteries"},
            {StrokeConditionType.Stroke, "stroke"},
            {StrokeConditionType.SubarachnoidHaemorrhage, "subarachnoid haemorrhage"},
            {StrokeConditionType.TransientIschaemicAttack, "transient ischaemic attack"},
            {StrokeConditionType.Other, "Other"}
        };

        public string GetValueFromEnum(StrokeConditionType strokeConditionType)
        {
            return Conditions.Single(s => s.Key == strokeConditionType).Value;
        }

        public int GetIndexOfStrokeCondition(StrokeConditionType heartConditionType)
        {
            return Conditions.ToList().IndexOf(Conditions.Single(s => s.Key == heartConditionType));
        }
    }
}
