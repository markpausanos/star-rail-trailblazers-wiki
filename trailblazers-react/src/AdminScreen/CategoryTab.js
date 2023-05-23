import React from 'react';
import './CategoryTab.css';

function CategoryTab(props) {

  const activeNameLine = (item) => {
    return props.activeItem === item.toLowerCase() ? 'active' : null;
  };

  return (
    <div className='CategoryTab'>
      <ul className='list'>
        <li data-id="nav" onClick={props.OnClickHandle} className={activeNameLine('Characters')}>Characters</li>
        <li data-id="nav" onClick={props.OnClickHandle} className={activeNameLine('Light Cones')}>Light Cones</li>
        <li data-id="nav" onClick={props.OnClickHandle} className={activeNameLine('Relics')}>Relics</li>
        <li data-id="nav" onClick={props.OnClickHandle} className={activeNameLine('Ornaments')}>Ornaments</li>     
      </ul>
      <hr/>
    </div>
  );
}

export default CategoryTab;
