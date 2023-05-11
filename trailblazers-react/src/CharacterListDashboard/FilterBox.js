import React from 'react'
import './FilterBox.css';

function FilterBox(props) {

    function addFilter(){
        return (
            <>
            <li className='vertical'> </li>

            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/element_fire.png" alt="fire" />
                </button>
            </li>
            <li data-id="button"> 
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/element_ice.png" alt="ice" />
                </button>
            </li>
            <li data-id="button"> 
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/element_imaginary.png" alt="imaginary" />
                </button>
            </li>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/element_lightning.png" alt="lightning" />
                </button>
            </li>
            <li data-id="button"> 
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/element_physical.png" alt="physical" />
                </button>
            </li>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/element_quantum.png" alt="quantum" />
                </button>
            </li>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/element_wind.png" alt="wind" />
                </button>
            </li>
            </>
        );
    }


  return (
    <div className='filterbox'>
        <ul data-id = 'filter' className='table'>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/rarity_4.png" alt="rare1" />
                </button>
            </li>
            <li data-id="button"> 
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/rarity_5.png" alt="rare2" />
                </button>
            </li>

            {props.category === 'Character Page List' && addFilter()}

            <li className='vertical'> </li>

            <li data-id="button"> 
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/path_the_abundance.png" alt="abundance" />
                </button>
            </li>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/path_the_destruction.png" alt="destruction" />
                </button>
            </li>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/path_the_erudition.png" alt="erudition" />
                </button>
            </li>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/path_the_harmony.png" alt="harmony" />
                </button>
            </li>
            <li data-id="button"> 
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/path_the_hunt.png" alt="hunt" />
                </button>
            </li>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/path_the_nihility.png" alt="nihility" />
                </button>
            </li>
            <li data-id="button">  
                <button className='imgbutton'>
                    <img src="CharacterListDashboardImg/path_the_preservation.png" alt="preservation" />
                </button>
            </li>
        </ul>
    </div>
  );
}

export default FilterBox;