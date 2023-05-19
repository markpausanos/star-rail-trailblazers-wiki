import React, { useState } from 'react'
import './CharacterPageList.css';
import Search from './Search';
import FilterBox from './FilterBox';
import CharacterList from './CharacterList';


/**
 * Displays the content box for Character Page List
 * @returns renders the search bar, list of characters and filter
 */
function CharacterPageList() {

  const [searchTerm, setSearchTerm] = useState('');
  const [rarity, setRarity] = useState('');
  const [element, setElement] = useState('');
  const [pathType, setPathType] = useState('');


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

  const handleElementChange = (alt) => {
    if(element === alt){
      setElement('');
    }else{
      setElement(alt);
    }
  };

  const handlePathChange = (alt) => {
    if(pathType === alt){
      setPathType('');
    }else{
      setPathType(alt);
    }
  };

  const characters = [
    {
      name: "Arlan",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1008.png",
      elem: "Lightning",
      path: "The Destruction",
      rare: 4,
      charId: 0
    },
    {
      name: "Asta",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1009.png",
      elem: "Fire",
      path: "The Harmony",
      rare: 4,
      charId: 1
    },
    {
      name: "Bailu",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1211.png",
      elem: "Lightning",
      path: "The Abundance",
      rare: 5,
      charId: 2
    },
    {
      name: "Bronya",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1101.png",
      elem: "Wind",
      path: "The Harmony",
      rare: 5,
      charId: 3
    },
    {
      name: "Clara",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1107.png",
      elem: "Physical",
      path: "The Destruction",
      rare: 5,
      charId: 4
    },
    {
      name: "Dan Heng",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1002.png",
      elem: "Wind",
      path: "The Hunt",
      rare: 4,
      charId: 5
    },
    {
      name: "Gepard",
      img: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1104.png",
      elem: "Ice",
      path: "The Reservation",
      rare: 5,
      charId: 6
    }
  ]


  let filterRareChar = characters.filter(item =>
    item.rare.toString()
    .includes(rarity.toString()));

  let filterElemChar = filterRareChar.filter(item =>
    item.elem.toString()
    .includes(element.toString()));

  let filterPathChar = filterElemChar.filter(item =>
    item.path.toString()
    .includes(pathType.toString()));

  let searchedChar = filterPathChar.filter(item => 
    item.name
    .toLocaleLowerCase()
    .includes(searchTerm.toLocaleLowerCase()));


  return (
    <div>
      <ul className='headerbar'>
          <li data-id = 'header' className='searchbar'> <Search text={'Search character'} onSearchTermChange={searchOnChangeHandler}/> </li>
          <li data-id = 'header'> <FilterBox category={'Character Page List'} onRareFilterChange={handleRarityChange}  onElemFilterChange={handleElementChange} onPathFilterChange={handlePathChange}/></li>
      </ul>

      <div className='contents'>
        <CharacterList list={searchedChar} />
          
      </div>
    </div>
  );
}

export default CharacterPageList;