import React from 'react';

function App() {
  return <h1>Hello, React + Vite + TS!</h1>;
}
//devo mostare l'ora e i secondi
function DateTime(){
    const date = new Date();
    const hours = date.getHours(); //0-23
    const minutes = date.getMinutes();//0-59
    const seconds = date.getSeconds();
    return (
        <div>
           {date.toDateString()}, {hours}:{minutes}:{seconds}
        </div>
    );
}
export default App;
export {DateTime};
