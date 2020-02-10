using System;
using System.Text;
using System.IO;

namespace CharacterLibrary
{
    public class Character
    {
        public string CharacterName { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Charisma { get; set; }
        public int MaxHitPoints { get; set; }
        public int HitPoints { get; set; }
        public int ExperiencePoints { get; set; }

        private Random rnd = new Random();
        private string[] RandomNames;

        public Character()
        {
            CharacterName = string.Empty;
            Strength = 0;
            Intelligence = 0;
            Wisdom = 0;
            Dexterity = 0;
            Constitution = 0;
            Charisma = 0;
            HitPoints = 0;
            ExperiencePoints = 0;

            RandomNames = new string[5] { "Frodo", "Bilbo", "Dori", "Nori", "Gandalf" };
        }

        public void GenerateCharacter()
        {

            CharacterName = GetRandomName();
            Strength = RollAttributeScore();
            Intelligence = RollAttributeScore();
            Wisdom = RollAttributeScore();
            Dexterity = RollAttributeScore();
            Constitution = RollAttributeScore();
            Charisma = RollAttributeScore();
        }

        private string GetRandomName()
        {
            var randomIndex = rnd.Next(0, RandomNames.Length);
            return RandomNames[randomIndex];
        }

        private int RollAttributeScore()
        {
            int score = 0;
            int highest = 0;

            //roll three times and take the best score
            for (var i = 0; i < 3; i++)
            {
                //roll three six sided dice to get the score
                score = rnd.Next(3, 18); // creates a number between 3 and 18
                if(score > highest){
                    highest = score;
                }
            }

            return highest;
        }

        public override string ToString()
        {
            var characterString = new StringBuilder();
            characterString.AppendLine("Character Name: " + this.CharacterName);
            characterString.AppendLine("Strength: " + Strength);
            characterString.AppendLine("Intelligence: " + Intelligence);
            characterString.AppendLine("Wisdom: " + Wisdom);
            characterString.AppendLine("Dexterity: " + Dexterity);
            characterString.AppendLine("Constitution: " + Constitution);
            characterString.AppendLine("Charisma: " + Charisma);
            characterString.AppendLine("Max Hit Points: " + MaxHitPoints);
            characterString.AppendLine("Current Hit Points: " + HitPoints);
            characterString.AppendLine("-------------------------------------------------");
            characterString.Append(RecommendClass());

            return characterString.ToString();
        }

        private string RecommendClass()
        {
            var recommendation = new StringBuilder();
            if (Strength > 12) recommendation.AppendLine(CharacterName + " would make a good fighter.");

            if (Intelligence > 12)
            {
                recommendation.AppendLine(CharacterName + " would make a good mage.");
            }

            if (Wisdom >= 12)
            {
                recommendation.AppendLine(CharacterName + " would make a good cleric.");
            }
            else
            {
                recommendation.AppendLine(CharacterName + " would make a terrible cleric.");
            }

            if (Intelligence > 12 && Wisdom > 12)
            {
                recommendation.AppendLine(CharacterName + " would make a good Cleric / Mage!");
            }

            if (Wisdom >= 12 || Intelligence >= 12)
            {
                recommendation.AppendLine("This character should probably wield magic of some sort.");
            }

            return recommendation.ToString();
        }

    }
}
