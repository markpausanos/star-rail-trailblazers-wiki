import React, { useState } from "react";
import './AdminDashboard.css';
import CategoryTab from "./CategoryTab";
import ActionTab from "./ActionTab";
import CharacterCreatePage from './CharacterCreatePage'
import LightConeCreatePage from './LightConeCreatePage'
import RelicCreatePage from './RelicCreatePage'
import OrnamentCreatePage from './OrnamentCreatePage'

function AdminDashboard() {
    const [activeItem, setActiveItem] = useState('characters');
    const [isUpdating, setIsUpdating] = useState(false);

    const handleClick = (event) => {
        setActiveItem(event.target.textContent.toLowerCase());
    };

    const handleCreateUpdate = (action) => {
        setIsUpdating(action === 'Create' ? false : true);
    };

    return (
        <div>
            <div className="tabs">
                <ActionTab OnClickHandle={handleCreateUpdate} isUpdating={isUpdating}/>
                <CategoryTab OnClickHandle={handleClick} activeItem={activeItem} isUpdating={isUpdating}/>
            </div>
            <div className='content'>
                          {/*
            {activeItem === 'characters' && isUpdating === false && <CharacterCreatePage />}
            {activeItem === 'light cones' && isUpdating === false && <LightConeCreatePage />}
            {activeItem === 'relics' && isUpdating === false && <RelicCreatePage />}
            {activeItem === 'ornaments' && isUpdating === false && <OrnamentCreatePage />}   
                      */}
            <div className='spacer' />
            </div>
        </div>
      );
}

export default AdminDashboard;