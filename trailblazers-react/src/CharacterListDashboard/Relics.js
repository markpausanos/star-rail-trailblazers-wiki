import React from 'react'
import Search from './Search';
function Relics() {
  return (
    <div>
        <ul className='headerbar'>
          <li className='searchbar'> <Search text={'Search relics'}/> </li>
        </ul>
    </div>
  );
}

export default Relics