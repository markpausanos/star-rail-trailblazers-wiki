import React, { useState } from 'react';
import { useNavigate } from "react-router";
import './Dashboard.css';
import CategoryTab from './CategoryTab';
import CharacterPageList from './CharacterPageList';
import LightConePage from './LightConePage';
import Relics from './Relics';
import Ornaments from './Ornaments';
import NavBar from '../NavBar';

/**
 * 
 * @returns Renders the overall Content for the Character List Page along with the navigation tab
 */
function Dashboard() {
  const [activeItem, setActiveItem] = useState('characters');
  const[isOpen,setIsOpen]=useState(false);
    const navigate = useNavigate();
  const toggle=()=>{
    setIsOpen(!isOpen);
  }
  const handleClick = (event) => {
    setActiveItem(event.target.textContent.toLowerCase());
  };

  return (
    <div className='dashboard'>
        <CategoryTab OnClickHandle={handleClick} activeItem={activeItem}/>
        <div style={{width: isOpen ? "15%" : "0%"}} className="navbar">
              {isOpen && <div className='option' onClick={() => navigate('/dashboard')}>Dashboard</div>}
              {isOpen && <div className='option' onClick={() => navigate('/character-showcase')}>Character Showcase</div>}
              {isOpen && <div className='option' onClick={() => navigate('/')}>SignOut</div>}
          </div>
        <div className='menu'onClick={toggle}>Menu</div>
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