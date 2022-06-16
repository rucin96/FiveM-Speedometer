namespace Speedometer.Factory
{
    public class MultiplierFactory
    {
        private string _value;

        public MultiplierFactory(string value)
        {
            this._value = value;
        }

        public double Get()
        {
            switch (_value.ToLower())
            {
                case "kph":
                    return 3.6;
                case "mph":
                    return 2.236936;
            }

            return 0;
        }
    }
}