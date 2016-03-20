namespace MusicShopManager.Engine.Factories
{
    using System;
    using MusicShopManager.Interfaces;
    using MusicShopManager.Interfaces.Engine;
    using MusicShopManager.Models;

    public class ArticleFactory : IArticleFactory
    {
        public IMicrophone CreateMirophone(string make, string model, decimal price, bool hasCable)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public IDrums CreateDrums(string make, string model, decimal price, string color, int width, int height)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public IElectricGuitar CreateElectricGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public IAcousticGuitar CreateAcousticGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public IBassGuitar CreateBassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
