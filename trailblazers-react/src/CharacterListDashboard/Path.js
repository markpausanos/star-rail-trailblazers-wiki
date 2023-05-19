import React from 'react'
import './Path.css';


function Path(props) {
    const pathType = [
        {
            img: "CharacterListDashboardImg/path_the_abundance.png",
            alt: "The Abundance",
            filterId: 0
        },
        {
            img: "CharacterListDashboardImg/path_the_destruction.png",
            alt: "The Destruction",
            filterId: 1
        },
        {
            img: "CharacterListDashboardImg/path_the_erudition.png",
            alt: "The Erudition",
            filterId: 2
        },
        {
            img: "CharacterListDashboardImg/path_the_harmony.png",
            alt: "The Harmony",
            filterId: 3
        },
        {
            img: "CharacterListDashboardImg/path_the_hunt.png",
            alt: "The Hunt",
            filterId: 4
        },
        {
            img: "CharacterListDashboardImg/path_the_nihility.png",
            alt: "The Nihility",
            filterId: 5
        },
        {
            img: "CharacterListDashboardImg/path_the_preservation.png",
            alt: "The Preservation",
            filterId: 6
        }
    ];
    const selectedPath = pathType.find((path) => path.alt === props.type);

  return (
    <div>
      {selectedPath && (
        <div className='path'>
          <img src={selectedPath.img} alt={selectedPath.alt} />
          <span>The {selectedPath.alt}</span>
        </div>
      )}
    </div>
  );
}

export default Path;