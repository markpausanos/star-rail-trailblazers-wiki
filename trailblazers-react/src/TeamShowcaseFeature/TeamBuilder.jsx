import React from 'react';
import './TeamBuilder.css';
import ChooseCharacter from './ChooseCharacter';

function TeamBuilder() {
    return (
      <div className='teambuilderbase'>
        <div className='team'><ChooseCharacter /><ChooseCharacter /><ChooseCharacter /><ChooseCharacter /></div>
        <div className='options'>
          <div className='button'>Clear</div>
          <div className='button'>Save</div>
        </div>
      </div>
    );
  }

export default TeamBuilder;
