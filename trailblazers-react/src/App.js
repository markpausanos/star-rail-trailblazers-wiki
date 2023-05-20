import './App.css';
import { Routes, Route } from 'react-router';
import Login from './Login-Signup/Login';
import Dashboard from './CharacterListDashboard/Dashboard';
import SignUp from './Login-Signup/SignUp';
import TeamShowcase from './TeamShowcaseFeature/TeamShowcase';

function App() {
  return (
    <Routes>
      <Route path='/' element={<Login />}></Route>
      <Route path="sign-up" element={<SignUp />}></Route>
      <Route path="dashboard" element={<Dashboard />}></Route>
      <Route path ="teamshowcase" element={<TeamShowcase/>}/>
    </Routes>
  );
}

export default App;
