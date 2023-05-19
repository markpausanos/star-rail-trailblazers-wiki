import React, { useState } from "react";
import './AdminDashboard.css';
import CategoryTab from "./CategoryTab";
import ActionTab from "./ActionTab";
import CharacterCreatePage from './CharacterCreatePage'
import LightConeCreatePage from './LightConeCreatePage'
import RelicCreatePage from './RelicCreatePage'
import OrnamentCreatePage from './OrnamentCreatePage'
import CharacterPageList from "../CharacterListDashboard/CharacterPageList";
import LightConePage from "../CharacterListDashboard/LightConePage";
import Relics from "../CharacterListDashboard/Relics";
import Ornaments from "../CharacterListDashboard/Ornaments";

function AdminDashboard() {
    const [activeItem, setActiveItem] = useState('characters');
    const [isUpdating, setIsUpdating] = useState(false);

    const handleClick = (event) => {
        setActiveItem(event.target.textContent.toLowerCase());
    };

    const handleCreateUpdate = (action) => {
        setIsUpdating(action.target.textContent === 'Create' ? false : true);
    };

    return (
        <div>
            <ActionTab OnClickHandle={handleCreateUpdate} isUpdating={isUpdating}/>
            <CategoryTab OnClickHandle={handleClick} activeItem={activeItem}/>
            <div className='content'>
            {activeItem === 'characters' && isUpdating === false && <CharacterCreatePage />}
            {activeItem === 'light cones' && isUpdating === false && <LightConeCreatePage />}
            {activeItem === 'relics' && isUpdating === false && <Relics />}
            {activeItem === 'ornaments' && isUpdating === false && <Ornaments />}   
            {activeItem === 'characters' && isUpdating === true && <Ornaments />}
            {activeItem === 'light cones' && isUpdating === true && <Relics />}
            {activeItem === 'relics' && isUpdating === true && <LightConePage />}
            {activeItem === 'ornaments' && isUpdating === true && <CharacterPageList />}   
            <div className='spacer' />
            </div>
        </div>
      );
}

export default AdminDashboard;