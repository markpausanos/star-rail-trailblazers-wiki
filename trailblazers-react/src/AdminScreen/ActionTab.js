import React from 'react';
import './ActionTab.css';

function ActionTab(props) {

  const activeNameLine = (item) => {
    return props.isUpdating === item ? 'active' : null;
  };

  return (
    <div className='ActionTab'>
      <ul className='list'>
        <li data-id="nav" onClick={props.OnClickHandle} className={activeNameLine('Create')}>Create</li>
        <li data-id="nav" onClick={props.OnClickHandle} className={activeNameLine('Update')}>Update</li>  
      </ul>
      <hr/>
    </div>
  );
}

export default ActionTab;
