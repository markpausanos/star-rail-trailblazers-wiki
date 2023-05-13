import React, { useState } from "react";
import { useNavigate } from "react-router";
import "./Login.css";

export const Login = (props) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();


    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(username)
    }
    
    return (
        <div className="background-image">
            <div className="container1">
                <h2>Login</h2>
                <form onSubmit={handleSubmit}>
                    <label htmlFor="username">Username</label>
                    <input value ={username} onChange={(e) => setUsername(e.target.value)}type="username" placeholder="Enter username" id="usernameid" name="username" />
                    <br />
                    <label htmlFor="password">Password</label>
                    <input value ={password} onChange={(e) => setPassword(e.target.value)}type="password" placeholder="Enter password" id="passwordid" name="password" />
                    <br />
                    <button className= "button-login" type="submit" onClick={() => navigate('dashboard')}>Login</button>
                    <br />
                </form>
                <p>New to Trailblazers? 
                    <button className="link-button" onClick={() => navigate('sign-up')}>Create an account.</button>
                </p>
            </div>
        </div>
    )
}

export default Login;