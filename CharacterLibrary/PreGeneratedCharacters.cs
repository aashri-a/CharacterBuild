using System;
using System.Collections.Generic;

namespace CharacterLibrary
{
    public class PreGeneratedCharacters
    {
        private List<Character> Characters { get; set; }

        public PreGeneratedCharacters()
        {
            Characters = new List<Character>();
        }

        public void ClearCharacters(){
            Characters.Clear();
        }

        public void GenerateCharacters(int quantity){
            for (var i = 0; i < quantity; i++){
                var thisCharacter = new Character();
                thisCharacter.GenerateCharacter();
                Characters.Add(thisCharacter);
            }
        }

        public void ResetCharacters(){
            foreach(var character in Characters){
                character.HitPoints = character.MaxHitPoints;
            }
        }
    }
}
