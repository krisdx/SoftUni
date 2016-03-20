namespace FarmersCreed.Simulator
{
    using FarmersCreed.Interfaces;
    using FarmersCreed.Units.Animals;
    using FarmersCreed.Units.Plants;
    using FarmersCreed.Units.Products;

    public class ExtendedFarmSimulator : FarmSimulator
    {
        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                    CherryTree cherryTree = new CherryTree(id);
                    this.farm.Plants.Add(cherryTree);
                    break;
                case "TobaccoPlant":
                    TobaccoPlant tobaccoPlant = new TobaccoPlant(id);
                    this.farm.Plants.Add(tobaccoPlant);
                    break;
                case "Cow":
                    Cow cow = new Cow(id);
                    this.farm.Animals.Add(cow);
                    break;
                case "Swine":
                    Swine swine = new Swine(id);
                    this.farm.Animals.Add(swine);
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }

        }

        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "feed":
                    string animalId = inputCommands[1];
                    string foodId = inputCommands[2];
                    int quantity = int.Parse(inputCommands[3]);

                    Animal animal = this.GetAnimalById(animalId);
                    var food = this.GetProductById(foodId) as IEdible;

                    this.farm.Feed(animal, food, quantity);
                    break;
                case "water":
                    string plantId = inputCommands[1];
                    Plant plant = this.GetPlantById(plantId);

                    plant.Water();
                    break;
                case "exploit":
                    string type = inputCommands[1];
                    string id = inputCommands[2];

                    if (type == "animal")
                    {
                        this.farm.AddProduct(this.GetAnimalById(id).GetProduct());
                    }
                    else
                    {
                        this.farm.AddProduct(this.GetPlantById(id).GetProduct());
                    }
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }
        }
    }
}