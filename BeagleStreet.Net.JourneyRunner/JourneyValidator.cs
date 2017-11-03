using BeagleStreet.Net.JourneyRunner.CustomExceptions;
using BeagleStreet.Net.JourneyRunner.Models;

namespace BeagleStreet.Net.JourneyRunner
{
    public class JourneyValidator
    {
        public bool IsJourneyValid(Journey journey)
        {
            if(journey == null)
                throw new InvalidJourneyException("Invalid!!!!!");

            

            return true;
        }
    }
}
