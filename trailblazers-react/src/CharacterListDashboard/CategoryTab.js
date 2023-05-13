import React from 'react';
import './CategoryTab.css';

/**
 * Displays sa navigation tab for Characters, Light Cones, Relics and Ornaments
 * Everytime the user hovers to them, it creates an underline
 * the " data-id="nav" " is only used to give unique identification that it is a different <span> 
 * @returns renders the navigation tab
 */
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
