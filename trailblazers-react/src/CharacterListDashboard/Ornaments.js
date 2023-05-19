import React from 'react'
import { useState } from 'react';
import Search from './Search';
import './RelicOrnament.css';

function Ornaments() {

  const [searchTerm, setSearchTerm] = useState('');
  const searchOnChangeHandler = (event) => {
    setSearchTerm(event.target.value);
  };

  const ornaments = [
    {
      name: "Belobog of the Architects",
      img: "https://rerollcdn.com/STARRAIL/Relics/belobog_of_the_architects.png",
      description: "Increases the wearer's DEF by 15%. When the wearer's Effect Hit Rate is 50% or higher, the wearer gains an extra 15% DEF..",
    },
    {
      name: "Celestial Differentiator",
      img: "https://rerollcdn.com/STARRAIL/Relics/celestial_differentiator.png",
      description: "Increases the wearer's CRIT DMG by 16%. When the wearer's current CRIT DMG reaches 120% or higher, after entering battle, the wearer's CRIT Rate increases by 60% until the end of their first attack.",
    }
  ]

  let searchedOrnaments = ornaments.filter(item => 
    item.name
    .toLocaleLowerCase()
    .includes(searchTerm.toLocaleLowerCase()));


  return (
    <div>
        <ul className='headerbar'>
          <li className='searchbar'> <Search text={'Search ornaments'} onSearchTermChange={searchOnChangeHandler}/> </li>
        </ul>

        {
            searchedOrnaments.map(orn => {
            return (
                <div className='relic-OrnanemtItem'>
                    <img src={orn.img} className='picture' alt={orn.name}/>
                    <div>
                      <span className='relic-OrnanemtName'> {orn.name}</span>
                      <div className='relic-OrnanemtDetails'> 
                          <div className='relic-Ornanemt-Detail'>2</div>
                          <span className='relic-OrnanemtDesc'> {orn.description} </span>
                      </div>
                    </div>
                    
                </div>
            );
            })
        }
    </div>
  );
}

export default Ornaments