import React from 'react'
import './Search.css';
/**
 * 
 * @returns 
 */
function Search(props) {
  return (
    <div>
        <input type= "text" className='inpbox' placeholder={props.text}/>

    </div>
  );
}

export default Search