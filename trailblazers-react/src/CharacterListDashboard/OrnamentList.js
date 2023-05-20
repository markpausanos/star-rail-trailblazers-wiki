import React from 'react'

function OrnamentList(props) {
  return (
    <>
        {
            props.list.map(orn => {
            return (
                <div className='relic-OrnanemtItem'>
                    <img src={orn.img} className='picture' alt={orn.name}/>
                    <div>
                      <span className='relic-OrnanemtName'> {orn.name}</span>
                      <div className='relic-OrnanemtDetails'> 
                          <div className='relic-Ornanemt-Detail'>2</div>
                          <span className='relic-OrnanemtDesc'> {orn.description} </span>
                      </div>
                    </div>
                    
                </div>
            );
            })
        }
    </>
  );
}

export default OrnamentList