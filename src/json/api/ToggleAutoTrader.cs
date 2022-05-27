namespace Nasfaq.JSON
{
    //api/toggleAutoTrader
    public class ToggleAutoTrader
    {
        public bool active { get; set; }

        public ToggleAutoTrader()
        {

        }

        public ToggleAutoTrader(bool active)
        {
            this.active = active;
        }
    }
}