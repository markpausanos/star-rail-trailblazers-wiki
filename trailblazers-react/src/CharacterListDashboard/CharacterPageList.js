import React, { useState } from 'react';
import './CharacterPageList.css';
import Search from './Search';
import FilterBox from './FilterBox';
import CharacterDetailsPopup from './CharacterDetailsPopup';

function CharacterPageList() {
  const [searchTerm, setSearchTerm] = useState('');
  const [rarity, setRarity] = useState('');
  const [selectedCharacter, setSelectedCharacter] = useState(null);

  const handleCharacterClick = (character) => {
    setSelectedCharacter(character);
  };

  const searchOnChangeHandler = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleRarityChange = (alt) => {
    if (rarity === alt) {
      setRarity('');
    } else {
      setRarity(alt);
    }
  };

  const characters = [
    {
      name: "Arlan",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1008.png",
      rare: 4,
      charId: 0
    },
    {
      name: "Asta",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1009.png",
      rare: 4,
      charId: 1
    },
    {
      name: "Bailu",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1211.png",
      rare: 5,
      charId: 2
    },
    {
      name: "Bronya",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1101.png",
      rare: 5,
      charId: 3
    },
    {
      name: "Clara",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1107.png",
      rare: 5,
      charId: 4
    },
    {
      name: "Dan Heng",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1002.png",
      rare: 4,
      charId: 5
    },
    {
      name: "Gepard",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1104.png",
      rare: 5,
      charId: 6
    }
  ]

  let filterRareChar = characters.filter((item) =>
    item.rare.toString().includes(rarity.toString())
  );

  let searchedChar = filterRareChar.filter((item) =>
    item.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="character-page-list">
      <ul className="headerbar">
        <li className="searchbar">
          <Search
            text="Search character"
            onSearchTermChange={searchOnChangeHandler}
          />
        </li>
        <li>
          <FilterBox
            category="Character Page List"
            onFilterChange={handleRarityChange}
          />
        </li>
      </ul>

      <div className="contents">
        {searchedChar.map((char) => (
          <div
            key={char.charId}
            className="character-portrait"
            onClick={() => handleCharacterClick(char)}
          >
            <img
              className={
                char.rare === 4
                  ? 'character-portrait-rare4'
                  : 'character-portrait-rare5'
              }
              src={char.img}
              alt={char.name}
            />
            <p>{char.name}</p>
          </div>
        ))}
      </div>

      {selectedCharacter && (
        <div className="popup-container">
          <CharacterDetailsPopup
            character={selectedCharacter}
            onClose={() => setSelectedCharacter(null)}
          />
        </div>
      )}
    </div>
  );
}

export default CharacterPageList;