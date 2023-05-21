import React, { useState } from 'react';
import TeamBuilder from './TeamBuilder';
import CreatedTeams from './CreatedTeams';
import TeamBuildShowcases from './TeamBuildShowcases';
import './TeamShowcase.css'

function TeamShowcase() {
    const [activeComponent, setActiveComponent] = useState('TeamBuilder');
    const handleComponentChange = (componentName) => {
        setActiveComponent(componentName);
      };

    return (
    <>
        <div className='bar'>
            <div className='tsChoice' onClick={() => handleComponentChange('TeamBuilder')}> Team Builder </div>
            <div className='tsChoice' onClick={() => handleComponentChange('CreatedTeams')}> Created Teams </div>
            <div className='tsChoice' onClick={() => handleComponentChange('TeamBuildShowcases')}> Team Showcases </div>
        </div>
        <hr className="my-hr"></hr>
        <div className='baseBox'>
            {activeComponent === 'TeamBuilder' && <TeamBuilder />}
            {activeComponent === 'CreatedTeams' && <CreatedTeams />}
            {activeComponent === 'TeamBuildShowcases' && <TeamBuildShowcases/>}
        </div>
    </>
    );
  }

export default TeamShowcase;
