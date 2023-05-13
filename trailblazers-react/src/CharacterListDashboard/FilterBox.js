import React from 'react'
import './FilterBox.css';
import Filters from './Filters';

function FilterBox(props) {

    const rarity = [
        {
            img: "CharacterListDashboardImg/rarity_4.png",
            alt: "rare1",
            filterId: 0
        },
        {
            img: "CharacterListDashboardImg/rarity_5.png",
            alt: "rare2",
            filterId: 1
        }
    ];

    const element = [
        {
            img: "CharacterListDashboardImg/element_fire.png",
            alt: "fire",
            filterId: 2
        },
        {
            img: "CharacterListDashboardImg/element_ice.png",
            alt: "ice",
            filterId: 3
        },
        {
            img: "CharacterListDashboardImg/element_imaginary.png",
            alt: "imaginary",
            filterId: 4
        },
        {
            img: "CharacterListDashboardImg/element_lightning.png",
            alt: "lightning",
            filterId: 5
        },
        {
            img: "CharacterListDashboardImg/element_physical.png",
            alt: "physical",
            filterId: 6
        },
        {
            img: "CharacterListDashboardImg/element_quantum.png",
            alt: "quantum",
            filterId: 7
        },
        {
            img: "CharacterListDashboardImg/element_wind.png",
            alt: "wind",
            filterId: 8
        }
    ];

    const pathType = [
        {
            img: "CharacterListDashboardImg/path_the_abundance.png",
            alt: "abundance",
            filterId: 9
        },
        {
            img: "CharacterListDashboardImg/path_the_destruction.png",
            alt: "destruction",
            filterId: 10
        },
        {
            img: "CharacterListDashboardImg/path_the_erudition.png",
            alt: "erudition",
            filterId: 11
        },
        {
            img: "CharacterListDashboardImg/path_the_harmony.png",
            alt: "harmony",
            filterId: 12
        },
        {
            img: "CharacterListDashboardImg/path_the_hunt.png",
            alt: "hunt",
            filterId: 13
        },
        {
            img: "CharacterListDashboardImg/path_the_nihility.png",
            alt: "nihility",
            filterId: 14
        },
        {
            img: "CharacterListDashboardImg/path_the_preservation.png",
            alt: "preservation",
            filterId: 15
        }
    ];

    function addFilter(){
        return (
            <>
                <li className='vertical'> </li>
                <Filters filter={element} />
            </>
        );
    }


  return (
    <div className='filterbox'>
        <ul data-id = 'filter' className='table'>
        
            <Filters filter={rarity} />

            {props.category === 'Character Page List' && addFilter()}

            <li className='vertical'> </li>

            <Filters filter={pathType} />

        </ul>
    </div>
  );
}

export default FilterBox;