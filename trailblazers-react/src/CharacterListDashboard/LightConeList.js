import React from 'react'
import './LightConeList.css';
import Path from './Path';
function LightConeList(props) {
  return (
    <>
        {
            props.list.map(cone => {
            return (
                <div className='lightconeItem'>
                    { cone.rarity === 3 ? (
                        <img className='lightcone-rare3' src={cone.img} alt={cone.name} />
                    ) : cone.rarity === 4 ? (
                        <img className='lightcone-rare4' src={cone.img} alt={cone.name} />
                    ) : (
                        <img className='lightcone-rare5' src={cone.img} alt={cone.name} />
                    )
                    }
                    <div className='details'>
                    <span className='name'> {cone.name}</span>
                    <Path type={cone.path} />
                    <span className='title'> {cone.title}</span>
                    <br></br>
                    <span className='description'> {cone.description}</span>
                    </div>
                </div>
            );
            })
        }
    
    </>
  );
}

export default LightConeList