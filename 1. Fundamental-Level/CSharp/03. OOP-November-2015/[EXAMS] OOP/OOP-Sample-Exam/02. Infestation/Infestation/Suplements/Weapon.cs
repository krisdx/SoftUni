namespace Infestation.Suplements
{
    public class Weapon : ISupplement
    {
        public void ReactTo(ISupplement otherSupplement)
        {
            throw new System.NotImplementedException();
        }

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
            get { throw new System.NotImplementedException(); }
        }
    }
}
