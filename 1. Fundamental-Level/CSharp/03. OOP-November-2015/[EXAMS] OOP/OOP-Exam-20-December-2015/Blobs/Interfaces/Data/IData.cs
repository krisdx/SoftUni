namespace Blobs.Interfaces.Data
{
    using System.Collections.Generic;

    using Blobs.Models;

    public interface IData
    {
        ICollection<IBlob> Blobs { get; }

        void AddUnit(IBlob blob);
    }
}