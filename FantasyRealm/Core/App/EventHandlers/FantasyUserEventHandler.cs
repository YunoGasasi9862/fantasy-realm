
namespace Core.App.EventHandlers
{
    public class FantasyUserEventHandler
    {
        public EventHandler FantasyUserEvent { get; set; }
        public FantasyUserEventHandler() { }

        public void DelegateFantasyUserDequeuedData()
        {
           // FantasyUserEvent.Invoke(this, fantasyUser);
        }

    }
}
