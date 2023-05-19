import React from 'react'
import './Filters.css';

function Filters(props) {

    return (
    <>
            {props.filter.map(item => {
                return (
                    <div key= {item.filterId}>
                        <li data-id="button">  
                        <button
                            className={`imgbutton ${item.alt === props.selectedFilter ? 'active' : ''}`}
                            onClick={() => props.onFilterChange(item.alt)}
                        >
                                <img src={item.img} alt={item.alt}/>
                                <div class="label">{item.alt}</div>
                            </button>
                        </li>
                    </div>

                );
            })}
    
    </>
    );
}

export default Filters