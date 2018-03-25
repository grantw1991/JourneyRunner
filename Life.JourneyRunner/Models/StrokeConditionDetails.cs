using System.Collections.Generic;
using System.ComponentModel;

namespace Life.JourneyRunner.Models
{
    public class StrokeConditionDetails
    {
        public List<StrokeConditionType> StrokeConditions { get; set; }
        public TransientIschaemicAttackDetails TransientIschaemicAttackDetails { get; set; }
        public BrainInjuryDetails BrainInjuryDetails { get; set; }
        public HeadInjuryDetails HeadInjuryDetails { get; set; }

        public enum StrokeConditionType
        {
            [Description("Brain bleed")]
            BrainBleed,
            [Description("Brain haemorrhage")]
            BrainHaemorrhage,
            [Description("brain injury")]
            BrainInjury,
            [Description("cerebral haemorrhage")]
            CerebralHaemorrhage,
            [Description("cerebrovascular accident")]
            CerebrovascularAccident,
            [Description("head injury")]
            HeadInjury,
            [Description("narrowing of the arteries")]
            NarrowingOfArteries,
            [Description("stroke")]
            Stroke,
            [Description("subarachnoid haemorrhage")]
            SubarachnoidHaemorrhage,
            [Description("transient ischaemic attack")]
            TransientIschaemicAttack,
            [Description("Other")]
            Other
        }
    }
}
