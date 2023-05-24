import { useNavigate } from "react-router";
function NavBar() {
    const navigate = useNavigate();
  return (
    <div className='nav'>
        <div className='option' onClick={() => navigate('/dashboard')}>Dashboard</div>
        <div className='option' onClick={() => navigate('/character-showcase')}>Character Showcase</div>
        <div className='option' onClick={() => navigate('/')}>SignOut</div>
    </div>
  );
}

export default NavBar;