import React from 'react';
import './CharacterBuilder.css';
import ChooseCharacter from './ChooseCharacter';

function CharacterBuilder() {
    return (
      <div className='teambuilderbase'>
        <div className='team'><ChooseCharacter /></div>
        <div className='options'>
          <div className='button'>Clear</div>
          <div className='button'>Save</div>
        </div>
      </div>
    );
  }

export default CharacterBuilder;
