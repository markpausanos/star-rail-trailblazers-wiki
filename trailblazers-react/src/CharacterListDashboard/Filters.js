import React from 'react'
import './Filters.css';

function Filters(props) {
  return (
   <>
        {props.filter.map(item => {
            return (
                <div key= {item.filterId}>
                     <li data-id="button">  
                        <button className='imgbutton'>
                            <img src={item.img} alt={item.alt} />
                        </button>
                    </li>
                </div>

            );
        })}
   
   </>
  );
}

export default Filters