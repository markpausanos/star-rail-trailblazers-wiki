import React, { useState } from 'react'
import './FilterBox.css';
import Filters from './Filters';

function FilterBox(props) {

    const [selectedRareFilter, setSelectedRareFilter] = useState('');
    const [selectedElementFilter, setSelectedElementFilter] = useState('');
    const [selectedPathFilter, setSelectedPathFilter] = useState('');

    const handleRareFilterChange = (alt) => {
        setSelectedRareFilter(selectedRareFilter => (selectedRareFilter === alt ? '' : alt));
        props.onRareFilterChange(alt);
    };

    const handleElementFilterChange = (alt) => {
        setSelectedElementFilter(selectedElementFilter => (selectedElementFilter === alt ? '' : alt));
        props.onElemFilterChange(alt);
    };

    const handlePathFilterChange = (alt) => {
        setSelectedPathFilter(selectedPathFilter => (selectedPathFilter === alt ? '' : alt));
        props.onPathFilterChange(alt);
    };


    const rarity = [
        {
            img: "CharacterListDashboardImg/rarity_3.png",
            alt: "3",
            filterId: 0
        },
        {
            img: "CharacterListDashboardImg/rarity_4.png",
            alt: "4",
            filterId: 1
        },
        {
            img: "CharacterListDashboardImg/rarity_5.png",
            alt: "5",
            filterId: 2
        }
    ];

    const element = [
        {
            img: "CharacterListDashboardImg/element_fire.png",
            alt: "Fire",
            filterId: 2
        },
        {
            img: "CharacterListDashboardImg/element_ice.png",
            alt: "Ice",
            filterId: 3
        },
        {
            img: "CharacterListDashboardImg/element_imaginary.png",
            alt: "Imaginary",
            filterId: 4
        },
        {
            img: "CharacterListDashboardImg/element_lightning.png",
            alt: "Lightning",
            filterId: 5
        },
        {
            img: "CharacterListDashboardImg/element_physical.png",
            alt: "Physical",
            filterId: 6
        },
        {
            img: "CharacterListDashboardImg/element_quantum.png",
            alt: "Quantum",
            filterId: 7
        },
        {
            img: "CharacterListDashboardImg/element_wind.png",
            alt: "Wind",
            filterId: 8
        }
    ];

    const pathType = [
        {
            img: "CharacterListDashboardImg/path_the_abundance.png",
            alt: "The Abundance",
            filterId: 9
        },
        {
            img: "CharacterListDashboardImg/path_the_destruction.png",
            alt: "The Destruction",
            filterId: 10
        },
        {
            img: "CharacterListDashboardImg/path_the_erudition.png",
            alt: "The Erudition",
            filterId: 11
        },
        {
            img: "CharacterListDashboardImg/path_the_harmony.png",
            alt: "The Harmony",
            filterId: 12
        },
        {
            img: "CharacterListDashboardImg/path_the_hunt.png",
            alt: "The Hunt",
            filterId: 13
        },
        {
            img: "CharacterListDashboardImg/path_the_nihility.png",
            alt: "The Nihility",
            filterId: 14
        },
        {
            img: "CharacterListDashboardImg/path_the_preservation.png",
            alt: "The Preservation",
            filterId: 15
        }
    ];

    function addFilter(){
        return (
            <>
                <li className='vertical'> </li>
                <Filters filter={element} onFilterChange={handleElementFilterChange} selectedFilter={selectedElementFilter}/>
            </>
        );
    }

    function rareFilterAdd(){
        const selectedRareObjects = [rarity[1], rarity[2]];

        return(
            <>
                {props.category === 'Light Cone' ?
                    (
                        <Filters filter={rarity} onFilterChange={handleRareFilterChange} selectedFilter={selectedRareFilter}/>
                    ) : (
                        <Filters filter={selectedRareObjects} onFilterChange={handleRareFilterChange} selectedFilter={selectedRareFilter}/>
                    )
                }
            </>
        );
    }

  return (
    <div className='filterbox'>
        <ul data-id = 'filter' className='table'>
        
            {rareFilterAdd()}

            {props.category === 'Character Page List' && addFilter()}

            <li className='vertical'> </li>

            <Filters filter={pathType} onFilterChange={handlePathFilterChange} selectedFilter={selectedPathFilter}/>

        </ul>
    </div>
  );
}

export default FilterBox;