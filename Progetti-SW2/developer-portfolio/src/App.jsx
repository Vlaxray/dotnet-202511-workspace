// App.js
import React from 'react';
import './App.css';
import Hero from './components/Hero';
import TechStack from './components/TechStack';
import Projects from './components/Projects';
import Footer from './components/Footer';

function App() {
  return (
    <div className="App">
      <Hero />
      <TechStack />
      <Projects />
      <Footer />
    </div>
  );
}

export default App;