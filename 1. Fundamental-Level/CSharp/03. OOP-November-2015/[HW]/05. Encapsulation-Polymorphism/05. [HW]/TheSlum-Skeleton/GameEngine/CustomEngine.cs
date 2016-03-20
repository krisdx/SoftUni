namespace TheSlum.GameEngine
{
    using System;
    using TheSlum.Items;

    public class CustomEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0].ToLower())
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            switch (inputParams[1].ToLower())
            {
                case "warrior":
                    {
                        Warrior newWarrior = new Warrior(
                        inputParams[2],
                        int.Parse(inputParams[3]), int.Parse(inputParams[4]),
                        200,
                        100,
                        150,
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        2);

                        this.characterList.Add(newWarrior);
                        break;
                    }
                case "mage":
                    {
                        Mage newMage = new Mage(
                        inputParams[2],
                        int.Parse(inputParams[3]), int.Parse(inputParams[4]),
                        150,
                        50,
                        300,
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        5);

                        this.characterList.Add(newMage);
                        break;
                    }
                case "healer":
                    {
                        Healer newHealer = new Healer(
                        inputParams[2],
                        int.Parse(inputParams[3]), int.Parse(inputParams[4]),
                        75,
                        50,
                        60,
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        6);

                        this.characterList.Add(newHealer);
                        break;
                    }
                default:
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            Character charecter = GetCharacterById(inputParams[1]);
            switch (inputParams[2].ToLower())
            {
                case "axe":
                    {
                        var axe = new Axe(inputParams[3]);

                        charecter.AddToInventory(axe);
                        break;
                    }
                case "shield":
                    {
                        var shield = new Shield(inputParams[3]);

                        charecter.AddToInventory(shield);
                        break;
                    }
                case "pill":
                    {
                        var pill = new Pill(inputParams[2]);

                        charecter.AddToInventory(pill);
                        break;
                    }
                case "injection":
                    {
                        var injection = new Injection(inputParams[2]);

                        charecter.AddToInventory(injection);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}