namespace Nasfaq.JSON
{
    //api/updateAutoTraderRules
    public class UpdateAutoTraderRules
    {
        public UserAutoTraderRules_Rule[] rules { get; set; }

        public UpdateAutoTraderRules()
        {

        }

        public UpdateAutoTraderRules(UserAutoTraderRules_Rule[] rules)
        {
            this.rules = rules;
        }
    }
}