import React from "react";
import Back from '../../Images/479706089.jpg';
import Logo1 from '../../Images/mm.jpg';
function Home(){
  const imgWidth = "800vw"
    return ( 
      <div>
       <img width={imgWidth} src={Back}/>
       <div></div>
        <img src={Logo1} width={imgWidth} />
      </div>
      );
}
export default Home;

