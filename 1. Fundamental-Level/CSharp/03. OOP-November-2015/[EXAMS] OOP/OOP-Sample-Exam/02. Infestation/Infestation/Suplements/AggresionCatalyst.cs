namespace Infestation.Suplements
{
    public class AggresionCatalyst : ISupplement
    {
        private const int DeafultAggresionEffect = 3;     

        public int PowerEffect
        {
            get { throw new System.NotImplementedException(); }
        }

        public int HealthEffect
        {
            get { throw new System.NotImplementedException(); }
        }

        public int AggressionEffect
        {
            get { return DeafultAggresionEffect; }
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            throw new System.NotImplementedException();
        }
    }
}
