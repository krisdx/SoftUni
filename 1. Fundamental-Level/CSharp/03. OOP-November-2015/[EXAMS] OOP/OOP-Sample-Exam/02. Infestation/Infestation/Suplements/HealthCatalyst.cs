namespace Infestation.Suplements
{
    public class HealthCatalyst : ISupplement
    {
        private const int DefaultHealthEffect = 3;
       
        public int PowerEffect
        {
            get { throw new System.NotImplementedException(); }
        }

        public int HealthEffect
        {
            get { return DefaultHealthEffect; }
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
