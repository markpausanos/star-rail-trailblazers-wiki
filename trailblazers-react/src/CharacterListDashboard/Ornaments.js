import React from 'react'
import Search from './Search';
function Ornaments() {
  return (
    <div>
        <ul className='headerbar'>
          <li className='searchbar'> <Search text={'Search ornaments'}/> </li>
        </ul>
    </div>
  );
}

export default Ornaments