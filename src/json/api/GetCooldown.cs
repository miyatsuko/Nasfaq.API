namespace Nasfaq.JSON
{
    //api/getCooldown
    public class GetCooldown
    {
        public bool success { get; set; } = true;
        public Cooldown cooldown { get; set; }
    }

    public class Cooldown
    {
        public long room { get; set; }
        public long post { get; set; }
        public long superchat { get; set; }
    }
}