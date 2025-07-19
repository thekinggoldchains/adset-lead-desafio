using Flunt.Notifications;
using Flunt.Validations;

namespace Common.Validation
{
    public class ValidationContract : Contract<Notification>
    {
        public void Add(string error)
        {
            this.AddNotification("ERROR", error);
        }

    }
}
