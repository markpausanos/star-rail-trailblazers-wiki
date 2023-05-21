import React from 'react'
import { useState } from 'react';
import Search from './Search';
import './RelicOrnament.css';
import RelicList from './RelicList';


function Relics() {
  const [searchTerm, setSearchTerm] = useState('');
  const searchOnChangeHandler = (event) => {
    setSearchTerm(event.target.value);
  };


  const relics = [
    {
      name: "Band of Sizzling Thunder",
      img: "https://rerollcdn.com/STARRAIL/Relics/band_of_sizzling_thunder.png",
      description1: "Increases Physical DMG by 10%.",
      description2: "After the wearer attacks or is hit, their ATK increases by 5% for the rest of the battle. This effect can stack up to 5 time(s)."
    },
    {
      name: "Eagle of Twilight Line",
      img: "https://rerollcdn.com/STARRAIL/Relics/eagle_of_twilight_line.png",
      description1: "Increases Wind DMG by 10%.",
      description2: "After the wearer uses their Ultimate, their action is Advanced Forward by 25%."
    },
    {
      name: "Band of Sizzling Thunder",
      img: "https://rerollcdn.com/STARRAIL/Relics/band_of_sizzling_thunder.png",
      description1: "Increases Physical DMG by 10%.",
      description2: "After the wearer attacks or is hit, their ATK increases by 5% for the rest of the battle. This effect can stack up to 5 time(s)."
    },
    {
      name: "Eagle of Twilight Line",
      img: "https://rerollcdn.com/STARRAIL/Relics/eagle_of_twilight_line.png",
      description1: "Increases Wind DMG by 10%.",
      description2: "After the wearer uses their Ultimate, their action is Advanced Forward by 25%."
    }
  ]

  let searchedRelic = relics.filter(item => 
    item.name
    .toLocaleLowerCase()
    .includes(searchTerm.toLocaleLowerCase()));

  return (
    <div>
        <div className='headerbar'>
            <Search text={'Search relics'} onSearchTermChange={searchOnChangeHandler}/>   
        </div>
      <div className='contentAdjust'>
      <RelicList list={searchedRelic} />
      </div>
      
    </div>
  );
}

export default Relics