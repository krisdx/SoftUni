namespace Blobs.Data
{
    using System;
    using System.Collections.Generic;

    using Blobs.Interfaces;
    using Blobs.Interfaces.Data;

    public class Data : IData
    {
        private IList<IBlob> blobs = new List<IBlob>();

        public void AddUnit(IBlob blob)
        {
            if (this.blobs.Contains(blob))
            {
                throw new ArgumentException("The blob already exists.");
            }

            this.blobs.Add(blob);
        }

        ICollection<IBlob> IData.Blobs
        {
            get { return this.blobs; }
        }
    }
}