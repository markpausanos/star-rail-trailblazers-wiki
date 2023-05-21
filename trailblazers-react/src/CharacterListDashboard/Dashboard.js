import React, { useState } from 'react';
import { useNavigate } from "react-router";
import './Dashboard.css';
import CategoryTab from './CategoryTab';
import CharacterPageList from './CharacterPageList';
import LightConePage from './LightConePage';
import Relics from './Relics';
import Ornaments from './Ornaments';

/**
 * 
 * @returns Renders the overall Content for the Character List Page along with the navigation tab
 */
function Dashboard() {
  const navigate = useNavigate();
  const [activeItem, setActiveItem] = useState('characters');

  const handleClick = (event) => {
    setActiveItem(event.target.textContent.toLowerCase());
  };

  return (
    <div className='dashboard'>
        <CategoryTab OnClickHandle={handleClick} activeItem={activeItem}/>
        <div className='contentDashboard'>
          {activeItem === 'characters' && <CharacterPageList />}
          {activeItem === 'light cones' && <LightConePage />}
          {activeItem === 'relics' && <Relics />}
          {activeItem === 'ornaments' && <Ornaments />}
        </div>
    </div>
  );
}

export default Dashboard;