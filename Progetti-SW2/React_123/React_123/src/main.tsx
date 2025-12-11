import React from 'react';
import ReactDOM from 'react-dom/client';
import App, { DateTime } from './App';
import Intro from './intro';
import Ciao from './ciao';

import Card from 'react-bootstrap/Card';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
    <DateTime />
    <Intro />
    <Ciao />
    <Card />
  </React.StrictMode>
  
);
