import React from 'react'
import './CharacterPageList.css';
import Search from './Search';
import FilterBox from './FilterBox';


/**
 * Displays the content box for Character Page List
 * @returns renders the search bar, list of characters and filter
 */
function CharacterPageList() {
  return (
    <div>
      <ul className='headerbar'>
          <li className='searchbar'> <Search text={'Search character'}/> </li>
          <li> <FilterBox category={'Character Page List'}/> </li>
      </ul>
    </div>
  );
}

export default CharacterPageList;