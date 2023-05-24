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

function App() {
  return (
    <Routes>
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
    </Routes>
  );
}

export default App;
