import React, { useState } from 'react'
import Search from './Search';
import FilterBox from './FilterBox';
import './LightConePage.css';
import LightConeList from './LightConeList';

function LightConePage() {
  const [searchTerm, setSearchTerm] = useState('');
  const [rarity, setRarity] = useState('');
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

  const handlePathChange = (alt) => {
    if(pathType === alt){
      setPathType('');
    }else{
      setPathType(alt);
    }
  };


  const lightcone = [
    {
      title: "Before Dawn",
      name: "Long Night",
      path: "The Erudition",
      rarity: 5,
      description: "Increases the wearer's CRIT DMG by 36/42/48/54/60%.\n" + 
      "Increases the wearer's Skill and Ultimate DMG by 18/21/24/27/30%.\n" + 
      "After the wearer uses their Skill or Ultimate, they gain Somnus Corpus.\n" +
      "Upon triggering a follow-up attack, Somnus Corpus will be consumed and the follow-up attack DMG increases by 48/56/64/72/80%.",
      img: "https://rerollcdn.com/STARRAIL/LightCones/before_dawn_sm.png"
    
    },
    {
      title: "Spare No Effort",
      name: "A Secret Vow",
      path: "The Destruction",
      rarity: 4,
      description: "Increases DMG dealt by the wearer by 20/25/30/35/40%.\n" + 
      "The wearer also deals an extra 20/25/30/35/40% of DMG to enemies with a higher HP percentage than the wearer.",
      img: "https://rerollcdn.com/STARRAIL/LightCones/a_secret_vow_sm.png"
    
    },
    {
      title: "Alliance",
      name: "Adversarial",
      path: "The Hunt",
      rarity: 3,
      description: "When the wearer defeats an enemy, increases SPD by 10/12/14/16/18% for 2 turn(s).",
      img: "https://rerollcdn.com/STARRAIL/LightCones/adversarial_sm.png"
    
    }
  ]

  let filterRareCone = lightcone.filter(item =>
    item.rarity.toString()
    .includes(rarity.toString()));

  let filterPathChar = filterRareCone.filter(item =>
    item.path.toString()
    .includes(pathType.toString()));

  let searchedCone = filterPathChar.filter(item => 
    item.name
    .toLocaleLowerCase()
    .includes(searchTerm.toLocaleLowerCase()));

  return (
      <div>
          <div className='headerbar'>
              <Search text={'Search light cone'} onSearchTermChange={searchOnChangeHandler}/>
              <div className='filterBox'>
            <FilterBox category={'Light cone'} onRareFilterChange={handleRarityChange}  onPathFilterChange={handlePathChange}/>

            </div>
          </div>

         <div className='contentAdjust'>
          <LightConeList list = {searchedCone} />
         </div>
      </div>
  );
}

export default LightConePage