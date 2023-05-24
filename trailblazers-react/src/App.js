<<<<<<< HEAD
/* eslint-disable no-unused-vars */
import React, { useState } from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import Cookies from "universal-cookie";
import {
  Builds,
  Lightcones,
  Login,
  Ornaments,
  Relics,
  SignUp,
} from "./screens";
import "./styles/App.scss";
import Dashboard from "./screens/user/Dashboard";

const cookies = new Cookies();
=======
import './App.css';
import { Routes, Route } from 'react-router';
import Login from './Login-Signup/Login';
import Dashboard from './CharacterListDashboard/Dashboard';
import SignUp from './Login-Signup/SignUp';
import CharacterShowcasePage from './CharacterShowcaseFeature/CharacterShowcasePage';

import AdminDashboard from './AdminScreen/AdminDashboard';

>>>>>>> a44b32fff4f67009ce2cfd8923b5a2bc716b8585

function App() {
  return (
    <Routes>
<<<<<<< HEAD
      <Route path="/" exact element={<Login />} />
      <Route path="/login" element={<Login />} />
      <Route path="/sign-up" element={<SignUp />} />
      <Route path="/dashboard" element={<Dashboard />} />
      <Route path="/characters" element={<Dashboard />} />
      <Route path="/lightcones" element={<Lightcones />} />
      <Route path="/ornaments" element={<Ornaments />} />
      <Route path="/relics" element={<Relics />} />
      <Route path="/builds" element={<Builds />} />
      <Route path="*" element={<Navigate to="/" />} />
=======
      <Route path='/' element={<Login />}></Route>
      <Route path="sign-up" element={<SignUp />}></Route>
      <Route path="dashboard" element={<Dashboard />}></Route>
      <Route path ="character-showcase" element={<CharacterShowcasePage/>}/>
      <Route path="admindashboard" element={<AdminDashboard />}></Route>
>>>>>>> a44b32fff4f67009ce2cfd8923b5a2bc716b8585
    </Routes>
  );
}

export default App;
