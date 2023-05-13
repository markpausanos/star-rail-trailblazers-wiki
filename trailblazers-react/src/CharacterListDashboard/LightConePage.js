import React from 'react'
import Search from './Search';
import FilterBox from './FilterBox';
import './LightConePage.css';

function LightConePage() {
  return (
    <div>
        <ul className='headerbar'>
          <li data-id = 'header' className='searchbar'> <Search text={'Search light cone'}/> </li>
          <li data-id = 'header' > <FilterBox category={'Light Cone'}/> </li>
        </ul>
    </div>
  );
}

export default LightConePage