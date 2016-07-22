using Blobs.Data;
using Blobs.Engine;
using Blobs.Engine.Factories;
using Blobs.IO;

public class BlobsMain
{
    public static void Main()
    {
        var blobFactory = new BlobFactory();
        var attackFactory = new AttackFactory();
        var behaviorFactory = new BehaviorFactory();

        var data = new Data();

        var reader = new InputReader();
        var writer = new OutputWriter();

        var engine = new Engine(blobFactory, attackFactory, behaviorFactory, data, reader, writer);
        engine.Run();
    }
}