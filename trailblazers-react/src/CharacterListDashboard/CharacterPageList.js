import React, { useState } from 'react'
import './CharacterPageList.css';
import Search from './Search';
import FilterBox from './FilterBox';


/**
 * Displays the content box for Character Page List
 * @returns renders the search bar, list of characters and filter
 */
function CharacterPageList() {

  const [searchTerm, setSearchTerm] = useState('');
  const [rarity, setRarity] = useState('');

  const searchOnChangeHandler = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleRarityChange = (alt) => {
    if(rarity === alt){
      setRarity('');
    }else{
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


  let filterRareChar = characters.filter(item =>
    item.rare.toString()
    .includes(rarity.toString()));

  let searchedChar = filterRareChar.filter(item => 
    item.name
    .toLocaleLowerCase()
    .includes(searchTerm.toLocaleLowerCase()));


  return (
    <div>
      <ul className='headerbar'>
          <li data-id = 'header' className='searchbar'> <Search text={'Search character'} onSearchTermChange={searchOnChangeHandler}/> </li>
          <li data-id = 'header'> <FilterBox category={'Character Page List'} onFilterChange={handleRarityChange}/></li>
      </ul>

      <div className='contents'>

          {
            searchedChar.map(char => {
                return (
                  <div key= {char.charId} className='character-portrait'>
                      { char.rare === 4 ? 
                          ( 
                            <img className='character-portrait-rare4' src = {char.img} alt={char.name} ></img>
                          ) : 
                          (
                            <img className='character-portrait-rare5' src = {char.img} alt={char.name} ></img>
                          )
                      }
                      <p> {char.name} </p>
                  </div>
                );
            })
          }
      </div>
    </div>
  );
}

export default CharacterPageList;