import React from 'react';
import logo from './logo.svg';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import {AdminLogin, Landing} from './pages';

function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<Landing />} />
        <Route path='/admin-login' element={<AdminLogin />} />
      </Routes>
    </Router>
  );
}

export default App;
