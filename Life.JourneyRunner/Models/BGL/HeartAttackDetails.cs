using System.ComponentModel;

namespace Life.JourneyRunner.Models.BGL
{
    public class HeartAttackDetails 
    {
        public enum YearsSinceAttack
        {
            [Description("1 year or less")]
            OneOrLess,
            [Description("More than 1 year")]
            MoreThanOne
        }

        public YearsSinceAttack YearsSinceAttackValue { get; set; }
    }
}