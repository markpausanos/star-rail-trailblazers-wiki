import React, { useState } from "react";
import './AdminDashboard.css';
import CategoryTab from "./CategoryTab";
import ActionTab from "./ActionTab";
import CharacterCreatePage from './CharacterCreatePage'
import LightConeCreatePage from './LightConeCreatePage'
import RelicCreatePage from './RelicCreatePage'
import OrnamentCreatePage from './OrnamentCreatePage'
import CharacterUpdatePage from "./CharacterUpdatePage";
import LightConeUpdatePage from "./LightConeUpdatePage";
import RelicUpdatePage from "./RelicUpdatePage";
import OrnamentUpdatePage from "./OrnamentUpdatePage";

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
            {activeItem === 'relics' && isUpdating === false && <RelicCreatePage />}
            {activeItem === 'ornaments' && isUpdating === false && <OrnamentCreatePage />}   
            {activeItem === 'characters' && isUpdating === true && <CharacterUpdatePage />}
            {activeItem === 'light cones' && isUpdating === true && <LightConeUpdatePage />}
            {activeItem === 'relics' && isUpdating === true && <RelicUpdatePage />}
            {activeItem === 'ornaments' && isUpdating === true && <OrnamentUpdatePage />}   
            <div className='spacer' />
            </div>
        </div>
      );
}

export default AdminDashboard;