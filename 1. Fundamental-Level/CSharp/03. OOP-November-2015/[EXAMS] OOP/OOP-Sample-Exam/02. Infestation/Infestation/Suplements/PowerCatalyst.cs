namespace Infestation.Suplements
{
    public class PowerCatalyst : ISupplement
    {
        private const int DefaultPowerEffect = 3;

        public int PowerEffect
        {
            get { return DefaultPowerEffect; }
        }

        public int HealthEffect
        {
            get { throw new System.NotImplementedException(); }
        }

        public int AggressionEffect
        {
            get { throw new System.NotImplementedException(); }
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            throw new System.NotImplementedException();
        }
    }
}