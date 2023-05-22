import './App.css';
import { Routes, Route } from 'react-router';
import Login from './Login-Signup/Login';
import Dashboard from './CharacterListDashboard/Dashboard';
import SignUp from './Login-Signup/SignUp';
import CharacterShowcasePage from './CharacterShowcaseFeature/CharacterShowcasePage';

function App() {
  return (
    <Routes>
      <Route path='/' element={<Login />}></Route>
      <Route path="sign-up" element={<SignUp />}></Route>
      <Route path="dashboard" element={<Dashboard />}></Route>
      <Route path ="character-showcase" element={<CharacterShowcasePage/>}/>
    </Routes>
  );
}

export default App;
