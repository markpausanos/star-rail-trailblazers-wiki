import React, { useState } from 'react';
import './Dashboard.css';
import NavigationTab from './NavigationTab';
import CharacterPageList from './CharacterPageList';
import LightConePage from './LightConePage';
import Relics from './Relics';
import Ornaments from './Ornaments';

/**
 * 
 * @returns Renders the overall Content for the Character List Page along with the navigation tab
 */
function Dashboard() {
  const [activeItem, setActiveItem] = useState('characters');

  const handleClick = (event) => {
    setActiveItem(event.target.textContent.toLowerCase());
  };

  return (
    <div>
        <NavigationTab OnClickHandle={handleClick} activeItem={activeItem}/>
        <div className='content'>
          {activeItem === 'characters' && <CharacterPageList />}
          {activeItem === 'light cones' && <LightConePage />}
          {activeItem === 'relics' && <Relics />}
          {activeItem === 'ornaments' && <Ornaments />}
        </div>
    </div>
  );
}

export default Dashboard;