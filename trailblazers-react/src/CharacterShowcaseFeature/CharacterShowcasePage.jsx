import React, { useState } from 'react';
import { useNavigate } from "react-router";
import BuiltCharacters from './BuiltCharacters';
import CharacterBuilder from './CharacterBuilder';
import CharacterBuildShowcases from './CharacterBuildShowcases';
import './CharacterShowcasePage.css'

function CharacterShowcasePage() {
    const [activeComponent, setActiveComponent] = useState('CharacterBuilder');
    const[isOpen,setIsOpen]=useState(false);
    const navigate = useNavigate();
    const toggle=()=>{
      setIsOpen(!isOpen);
    }
    const handleComponentChange = (componentName) => {
        setActiveComponent(componentName);
      };

    return (
    <div className='content'>
        <div style={{width: isOpen ? "15%" : "0%"}} className="navbar">
              {isOpen && <div className='option' onClick={() => navigate('/dashboard')}>Dashboard</div>}
              {isOpen && <div className='option' onClick={() => navigate('/character-showcase')}>Character Showcase</div>}
              {isOpen && <div className='option' onClick={() => navigate('/')}>SignOut</div>}
          </div>
        <div className='menu'onClick={toggle}>Menu</div>
        
        <div className='bar'>
            <div className='tsChoice' onClick={() => handleComponentChange('CharacterBuilder')}> Character Builder </div>
            <div className='tsChoice' onClick={() => handleComponentChange('BuiltCharacters')}> Built Characters </div>
            <div className='tsChoice' onClick={() => handleComponentChange('CharacterBuildShowcases')}> Character Build Showcases </div>
        </div>
        <hr className="my-hr"></hr>
        <div className='baseBox'>
            {activeComponent === 'CharacterBuilder' && <CharacterBuilder />}
            {activeComponent === 'BuiltCharacters' && <BuiltCharacters />}
            {activeComponent === 'CharacterBuildShowcases' && <CharacterBuildShowcases/>}
        </div>
    </div>
    );
  }

export default CharacterShowcasePage;
