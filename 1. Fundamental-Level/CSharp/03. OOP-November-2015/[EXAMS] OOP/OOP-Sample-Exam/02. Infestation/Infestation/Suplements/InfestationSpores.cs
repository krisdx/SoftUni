namespace Infestation.Suplements
{
    public class InfestationSpores : ISupplement
    {
        private const int DefaultAggressionEffect = 20;
        private const int DefaultPowerEffect = 1;

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
            get { return DefaultAggressionEffect; }
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            throw new System.NotImplementedException();
        }
    }
}