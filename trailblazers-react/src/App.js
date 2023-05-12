import './App.css';
import { Routes, Route } from 'react-router';
import Login from './Login-Signup/Login';
import Dashboard from './CharacterListDashboard/Dashboard';
function App() {
  return (
    <Routes>
      <Route path='/' element={<Login />}></Route>
      <Route path="dashboard" element={<Dashboard />}></Route>
    </Routes>
  );
}

export default App;
