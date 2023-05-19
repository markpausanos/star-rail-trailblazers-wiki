import React from 'react'
import './RelicOrnament.css';

function RelicList(props) {
  return (
    <>
        {
            props.list.map(relic => {
            return (
                <div className='relic-OrnanemtItem'>
                    <img src={relic.img} className='picture' alt={relic.name}/>
                    <div>
                      <span className='relic-OrnanemtName'> {relic.name}</span>
                      <div className='relic-OrnanemtDetails'> 
                          <div className='relic-Ornanemt-Detail'>2</div>
                          <span className='relic-OrnanemtDesc'> {relic.description1} </span>
                      </div>
                      <div>
                      <div className='relic-OrnanemtDetails'> 
                          <div className='relic-Ornanemt-Detail'>4</div>
                          <span className='relic-OrnanemtDesc'> {relic.description2} </span>
                      </div>
                    </div>
                    </div>
                    
                </div>
            );
            })
        }
    </>
  );
}

export default RelicList