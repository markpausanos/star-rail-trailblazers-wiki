import React from 'react'
import './CharacterList.css';
function CharacterList(props) {

  const element = [
    {
        img: "https://rerollcdn.com/STARRAIL/Elements/fire_sm.png",
        alt: "Fire",
        filterId: 2
    },
    {
        img: "https://rerollcdn.com/STARRAIL/Elements/ice_sm.png",
        alt: "Ice",
        filterId: 3
    },
    {
        img: "https://rerollcdn.com/STARRAIL/Elements/imaginary_sm.png",
        alt: "Imaginary",
        filterId: 4
    },
    {
        img: "https://rerollcdn.com/STARRAIL/Elements/lightning_sm.png",
        alt: "Lightning",
        filterId: 5
    },
    {
        img: "https://rerollcdn.com/STARRAIL/Elements/physical_sm.png",
        alt: "Physical",
        filterId: 6
    },
    {
        img: "https://rerollcdn.com/STARRAIL/Elements/quantum_sm.png",
        alt: "Quantum",
        filterId: 7
    },
    {
        img: "https://rerollcdn.com/STARRAIL/Elements/wind_sm.png",
        alt: "Wind",
        filterId: 8
    }
];

  return (
    <>
      {
        props.list.map(char => {
          const matchingElement = element.find(el => el.alt === char.elem);
            return (
              <div key= {char.charId} className='character-portrait'>
                 {matchingElement && (
                    <img className='character-element' src={matchingElement.img} alt={matchingElement.alt} />
                  )}
                  { char.rare === 4 ? 
                      ( 
                        <img className='character-portrait-rare4' src = {char.img} alt={char.name} ></img>             
                      ) : 
                      (
                        <img className='character-portrait-rare5' src = {char.img} alt={char.name} ></img>
                      )
                  }
                  <p> {char.name} </p>
              </div>
            );
        })
      } 
    </>
  );
}

export default CharacterList